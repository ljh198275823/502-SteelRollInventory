﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.Resource;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.BLL;
using LJH.GeneralLibrary;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.UI;

namespace LJH.Inventory.UI.Forms.Financial
{
    public partial class FrmSupplierPaymentAssign : Form
    {
        public FrmSupplierPaymentAssign()
        {
            InitializeComponent();
        }

        #region 公共属性
        public AccountRecord AccountRecord { get; set; }
        #endregion

        #region 私有方法
        private void ShowReceivables(string customerID, CustomerPaymentType PaymentType)
        {
            CompanyBLL bll = new CompanyBLL(AppSettings.Current.ConnStr);
            CustomerReceivableSearchCondition con = new CustomerReceivableSearchCondition();
            con.CustomerID = customerID;
            con.ReceivableTypes = new List<CustomerReceivableType>();
            if (PaymentType == CustomerPaymentType.客户收款)
            {
                con.ReceivableTypes.Add(CustomerReceivableType.CustomerReceivable);
            }
            else if (PaymentType == CustomerPaymentType.供应商付款)
            {
                con.ReceivableTypes.Add(CustomerReceivableType.SupplierReceivable);
            }
            else if (PaymentType == CustomerPaymentType.客户增值税发票)
            {
                con.ReceivableTypes.Add(CustomerReceivableType.CustomerTax);
            }
            else if (PaymentType == CustomerPaymentType.供应商增值税发票)
            {
                con.ReceivableTypes.Add(CustomerReceivableType.SupplierTax);
            }
            else if (PaymentType == CustomerPaymentType.公账)
            {
                con.ReceivableTypes.Add(CustomerReceivableType.公账应收款);
            }
            con.Settled = false;
            List<CustomerReceivable> items = (new CustomerReceivableBLL(AppSettings.Current.ConnStr)).GetItems(con).QueryObjects;
            if (items != null && items.Count > 0)
            {
                items = (from item in items orderby item.CreateDate ascending, item.SheetID ascending select item).ToList();
                foreach (CustomerReceivable cr in items)
                {
                    if (cr.Remain > 0)  //只核销金额为正的应收或应付
                    {
                        int row = GridView.Rows.Add();
                        ShowItemInGridViewRow(GridView.Rows[row], cr);
                    }
                }
            }
        }

        private void ShowItemInGridViewRow(DataGridViewRow row, CustomerReceivable cr)
        {
            row.Tag = cr;
            row.Cells["colSheetID"].Value = cr.SheetID;
            var gg = cr.GetProperty("规格");
            if (!string.IsNullOrEmpty(gg)) row.Cells["colSheetID"].Value = gg;
            row.Cells["colOrderID"].Value = cr.OrderID;
            row.Cells["colCreateDate"].Value = cr.CreateDate.ToString("yyyy-MM-dd");
            //row.Cells["colClassID"].Value = CustomerReceivableTypeDescription.GetDescription(cr.ClassID);
            row.Cells["colRemain"].Value = cr.Remain;
            row.Cells["colAssign"].Value = 0;
            row.Cells["colCheck"].Value = "全部核销";
            row.Cells["col申请人"].Value = cr.GetProperty("申请人");
            row.Cells["col购货单位"].Value = cr.GetProperty("购货单位");
            row.Cells["col类别"].Value = cr.GetProperty("费用类别");
            row.Cells["col车皮号"].Value = cr.GetProperty("车皮号");
            row.Cells["colMemo"].Value = cr.Memo;
        }

        private decimal GetAssignsFromGrid()
        {
            decimal ret = 0;
            foreach (DataGridViewRow row in GridView.Rows)
            {
                decimal temp = Convert.ToDecimal(row.Cells["colAssign"].Value);
                ret += temp;
            }
            return ret;
        }
        #endregion

        #region 事件处理程序
        private void FrmPaymentAssign_Load(object sender, EventArgs e)
        {
            if (AccountRecord != null)
            {
                txtID.Text = AccountRecord.SheetID;
                txtAmount.DecimalValue = AccountRecord.Remain.Trim();
                txtRemain.DecimalValue = AccountRecord.Remain.Trim();
                ShowReceivables(AccountRecord.CustomerID, AccountRecord.ClassID);
            }
        }

        private void GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GridView.Columns[e.ColumnIndex].Name == "colCheck")
            {
                decimal other = GetAssignsFromGrid() - Convert.ToDecimal(GridView.Rows[e.RowIndex].Cells["colAssign"].Value);
                decimal max = txtAmount.DecimalValue - other;
                CustomerReceivable cr = GridView.Rows[e.RowIndex].Tag as CustomerReceivable;
                GridView.Rows[e.RowIndex].Cells["colAssign"].Value = cr.Remain <= max ? cr.Remain : max;
                GridView.Rows[e.RowIndex].Cells["colAssign"].Selected = true;
                txtRemain.DecimalValue = txtAmount.DecimalValue - GetAssignsFromGrid();
            }
        }

        private void GridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && GridView.Columns[e.ColumnIndex].Name == "colAssign")
            {
                if (GridView.Rows[e.RowIndex].Cells["colAssign"].Value == null)
                {
                    GridView.Rows[e.RowIndex].Cells["colAssign"].Value = 0;
                    return;
                }
                string temp = GridView.Rows[e.RowIndex].Cells["colAssign"].Value.ToString().Trim('¥');
                decimal t = 0;
                if (decimal.TryParse(temp, out t))
                {
                    decimal allAssigned = GetAssignsFromGrid();
                    if (allAssigned > txtAmount.DecimalValue)
                    {
                        GridView.Rows[e.RowIndex].Cells["colAssign"].Value = 0;
                        txtRemain.DecimalValue = txtAmount.DecimalValue - GetAssignsFromGrid();
                        MessageBox.Show("分配的金额已经超出客户收款未分配额度");
                    }
                    else
                    {
                        txtRemain.DecimalValue = txtAmount.DecimalValue - allAssigned;
                    }
                }
                else
                {
                    MessageBox.Show("输入的内容不能转换成金额,请重新输入");
                    GridView.Rows[e.RowIndex].Cells["colAssign"].Value = 0;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            bool allSuccess = true;
            foreach (DataGridViewRow row in GridView.Rows)
            {
                if (row.Cells["colAssign"].Value == null) continue;
                decimal temp = Convert.ToDecimal(row.Cells["colAssign"].Value);
                if (temp > 0)
                {
                    AccountRecordAssign item = new AccountRecordAssign()
                    {
                        ID = Guid.NewGuid(),
                        PaymentID = AccountRecord.ID,
                        ReceivableID = (row.Tag as CustomerReceivable).ID,
                        Amount = temp,
                    };
                    CommandResult ret = (new AccountRecordAssignBLL(AppSettings.Current.ConnStr)).Assign(item);
                    row.Cells["colMemo"].Value = ret.Result == ResultCode.Successful ? "成功" : "失败";
                    if (ret.Result != ResultCode.Successful) allSuccess = false;
                }
            }
            if (allSuccess) this.DialogResult = DialogResult.OK;
        }
        #endregion

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            var items = new List<CustomerReceivable>();
            for (int i = 0; i < GridView.Rows.Count - 1; i++)
            {
                GridView.Rows[i].Visible = ContainText(GridView.Rows[i], txtKeyword.Text);
            }
        }

        private bool ContainText(DataGridViewRow row, string key)
        {
            if (string.IsNullOrEmpty(key)) return true;
            foreach (DataGridViewCell cell in row.Cells)
            {
                if (cell.Visible && cell.Value != null && cell.Value.ToString().Contains(key)) return true;
            }
            return false;
        }
    }
}