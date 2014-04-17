﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BLL;
using LJH.GeneralLibrary.DAL;
using LJH.GeneralLibrary.UI;

namespace LJH.Inventory.UI.Forms.Financial
{
    public partial class FrmExpenditureRecordDetail : FrmInventoryDetailBase 
    {
        public FrmExpenditureRecordDetail()
        {
            InitializeComponent();
        }

        #region 公共属性
        /// <summary>
        /// 获取或设置客户类别
        /// </summary>
        public ExpenditureType Category { get; set; }
        #endregion 

        #region 重写基类方法
        protected override bool CheckInput()
        {
            if (txtAmount.DecimalValue <= 0)
            {
                MessageBox.Show("付款金额不正确");
                txtAmount.Focus();
                return false;
            }
            return true;
        }

        protected override void InitControls()
        {
            dtPaidDate.Value = DateTime.Today;
            this.txtCategory.Text = Category != null ? Category.Name : string.Empty;
        }

        protected override void ItemShowing()
        {
            ExpenditureRecord item = UpdatingItem as ExpenditureRecord;
            if (item != null)
            {
                txtSheetNo.Text = item.ID;
                dtPaidDate.Value = item.ExpenditureDate;
                rdTransfer.Checked = (item.PaymentMode == PaymentMode.Transfer);
                rdCash.Checked = item.PaymentMode == PaymentMode.Cash;
                rdCheck.Checked = item.PaymentMode == PaymentMode.Check;
                txtAmount.DecimalValue = item.Amount;
                if (!string.IsNullOrEmpty(item.Category))
                {
                    Category = (new ExpenditureTypeBLL(AppSettings.Current.ConnStr)).GetByID(item.Category).QueryObject;
                }
                txtCategory.Text = Category != null ? Category.Name : string.Empty;
                txtCheckNum.Text = item.CheckNum;
                txtRequest.Text = item.Request;
                txtPayee.Text = item.Payee;
                txtOrderID.Text = item.OrderID;
                txtMemo.Text = item.Memo;
                List<DocumentOperation> items = (new DocumentOperationBLL(AppSettings.Current.ConnStr)).GetHisOperations(item.ID, item.DocumentType).QueryObjects;
                ShowOperations(items, dataGridView1);
                List<AttachmentHeader> headers = (new AttachmentBLL(AppSettings.Current.ConnStr)).GetHeaders(item.ID, item.DocumentType).QueryObjects;
                ShowAttachmentHeaders(headers, this.gridAttachment);
            }
        }

        protected override object GetItemFromInput()
        {
            ExpenditureRecord info = null;
            if (UpdatingItem == null)
            {
                info = new ExpenditureRecord();
                if (txtSheetNo.Text == _AutoCreate) txtSheetNo.Text = string.Empty;
            }
            else
            {
                info = UpdatingItem as ExpenditureRecord;
            }
            info.ExpenditureDate = dtPaidDate.Value;
            if (rdTransfer.Checked) info.PaymentMode = PaymentMode.Transfer;
            if (rdCheck.Checked) info.PaymentMode = PaymentMode.Check;
            if (rdCash.Checked) info.PaymentMode = PaymentMode.Cash;
            info.Amount = txtAmount.DecimalValue;
            info.Category = Category != null ? Category.ID : null;
            info.CheckNum = txtCheckNum.Text;
            info.Request = txtRequest.Text;
            info.Payee = txtPayee.Text;
            info.OrderID = txtOrderID.Text;
            info.Memo = txtMemo.Text;
            return info;
        }

        protected override CommandResult AddItem(object item)
        {
            ExpenditureRecordBLL bll = new ExpenditureRecordBLL(AppSettings.Current.ConnStr);
            return bll.Add(item as ExpenditureRecord, Operator.Current.Name);
        }

        protected override CommandResult UpdateItem(object item)
        {
            throw new Exception("资金支出不支持修改");
        }

        protected override void ShowButtonState()
        {
            btnOk.Enabled = IsAdding;
        }
        #endregion

        #region 与附件操作相关的方法和事件处理程序
        private void mnu_AttachmentAdd_Click(object sender, EventArgs e)
        {
            ExpenditureRecord item = UpdatingItem as ExpenditureRecord;
            if (item != null) PerformAddAttach(item.ID, item.DocumentType, gridAttachment);
        }

        private void mnu_AttachmentDelete_Click(object sender, EventArgs e)
        {
            PerformDelAttach(gridAttachment);
        }

        private void mnu_AttachmentSaveAs_Click(object sender, EventArgs e)
        {
            PerformAttachSaveAs(gridAttachment);
        }

        private void mnu_AttachmentOpen_Click(object sender, EventArgs e)
        {
            PerformAttachOpen(gridAttachment);
        }

        private void gridAttachment_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            PerformAttachOpen(gridAttachment);
        }
        #endregion

        private void btnNullify_Click(object sender, EventArgs e)
        {
            if (UpdatingItem != null)
            {
                if (MessageBox.Show("是否要取消此项?", "询问", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ExpenditureRecord item = UpdatingItem as ExpenditureRecord;
                    CommandResult ret = (new ExpenditureRecordBLL(AppSettings.Current.ConnStr)).Cancel(item, Operator.Current.Name);
                    if (ret.Result == ResultCode.Successful)
                    {
                        ExpenditureRecord item1 = (new ExpenditureRecordBLL(AppSettings.Current.ConnStr)).GetByID(item.ID).QueryObject;
                        this.UpdatingItem = item1;
                        ItemShowing();
                        ShowButtonState();
                        this.OnItemUpdated(new ItemUpdatedEventArgs(item1));
                    }
                    else
                    {
                        MessageBox.Show(ret.Message);
                    }
                }
            }
        }

        private void lnkCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmExpenditureTypeMaster frm = new FrmExpenditureTypeMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Category = frm.SelectedItem as ExpenditureType;
                txtCategory.Text = Category != null ? Category.Name : string.Empty;
            }
        }

        private void lnkRequest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmOperatorMaster frm = new FrmOperatorMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Operator item = frm.SelectedItem as Operator;
                txtRequest.Text = item.Name;
            }
        }
    }
}
