﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.Resource;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.BLL;
using LJH.GeneralLibrary;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.UI;
using LJH.Inventory.UI.Forms.Sale;
using LJH.Inventory.UI.Forms.Purchase;

namespace LJH.Inventory.UI.Forms.Financial
{
    public partial class FrmCustomerPaymentDetail : FrmSheetDetailBase
    {
        public FrmCustomerPaymentDetail()
        {
            InitializeComponent();
        }

        #region 公共属性
        /// <summary>
        /// 获取或设置收款或付款的客户
        /// </summary>
        public CompanyInfo Customer { get; set; }
        /// <summary>
        /// 获取或设置收款或付款类型
        /// </summary>
        public CustomerPaymentType PaymentType { get; set; }

        public string StackSheetID { get; set; }

        public decimal Amount { get; set; }
        #endregion

        #region 私有方法
        private void ShowAssigns()
        {
            ItemsGrid.Rows.Clear();
            if (UpdatingItem == null) return;
            List<CustomerPaymentAssign> assigns = (new CustomerPaymentBLL(AppSettings.Current.ConnStr)).GetAssigns((UpdatingItem as CustomerPayment).ID).QueryObjects;
            if (assigns != null && assigns.Count > 0)
            {
                CustomerReceivableSearchCondition con = new CustomerReceivableSearchCondition();
                con.ReceivableIDS = assigns.Select(it => it.ReceivableID).ToList();
                List<CustomerReceivable> crs = (new CustomerReceivableBLL(AppSettings.Current.ConnStr)).GetItems(con).QueryObjects;
                if (crs != null && crs.Count > 0)
                {
                    foreach (CustomerPaymentAssign assign in assigns)
                    {
                        CustomerReceivable cr = crs.FirstOrDefault(it => it.ID == assign.ReceivableID);
                        int row = ItemsGrid.Rows.Add();
                        ItemsGrid.Rows[row].Tag = assign;
                        ItemsGrid.Rows[row].Cells["colSheetID"].Value = cr.SheetID;
                        ItemsGrid.Rows[row].Cells["colClassID"].Value = CustomerReceivableTypeDescription.GetDescription(cr.ClassID);
                        ItemsGrid.Rows[row].Cells["colAssign"].Value = assign.Amount.Trim();
                    }
                }
                int rowTotal = ItemsGrid.Rows.Add();
                ItemsGrid.Rows[rowTotal].Cells["colSheetID"].Value = "合计";
                ItemsGrid.Rows[rowTotal].Cells["colAssign"].Value = assigns.Sum(item => item.Amount).Trim();
            }
        }

        private void InittxtxBank()
        {
            this.txtBank.Items.Clear();
            this.txtBank.Items.Add(string.Empty);
            List<string> banks = new CustomerPaymentBLL(AppSettings.Current.ConnStr).GetAllBanks();
            if (banks != null && banks.Count > 0)
            {
                foreach (var bank in banks)
                {
                    this.txtBank.Items.Add(bank);
                }
            }
        }
        #endregion

        #region 重写基类方法
        protected override void InitControls()
        {
            base.InitControls();
            txtCustomer.Text = Customer != null ? Customer.Name : string.Empty;
            txtBank.Enabled = rdTransfer.Checked;
            InittxtxBank();
            this.Text = (PaymentType == CustomerPaymentType.Customer) ? "客户付款流水" : "供应商付款流水";
            this.lnkCustomer.Text = (PaymentType == CustomerPaymentType.Customer) ? "客户" : "供应商";
            if (Amount != 0)
            {
                txtAmount.DecimalValue = Amount;
                txtAmount.ForeColor = System.Drawing.Color.Red;
                txtAmount.Focus();
            }
            if (IsForView)
            {
                toolStrip1.Enabled = false;
                ItemsGrid.ReadOnly = true;
                ItemsGrid.ContextMenu = null;
                ItemsGrid.ContextMenuStrip = null;
            }
        }

        protected override bool CheckInput()
        {
            if (Customer == null)
            {
                MessageBox.Show(PaymentType == CustomerPaymentType.Customer ? "客户不能为空" : "供应商不能为空");
                txtCustomer.Focus();
                return false;
            }
            if (txtAmount.DecimalValue <= 0)
            {
                MessageBox.Show("金额不正确");
                txtAmount.Focus();
                return false;
            }
            return true;
        }

        protected override void ItemShowing()
        {
            CustomerPayment item = UpdatingItem as CustomerPayment;
            if (item != null)
            {
                this.txtID.Text = item.ID;
                this.txtID.Enabled = false;
                dtSheetDate.Value = item.SheetDate;
                rdTransfer.Checked = (item.PaymentMode == PaymentMode.Transfer);
                rdCash.Checked = item.PaymentMode == PaymentMode.Cash;
                rd转公账.Checked = item.PaymentMode == PaymentMode.转公账;
                rd付承兑.Checked = item.PaymentMode == PaymentMode.付承兑;
                rd退货.Checked = item.PaymentMode == PaymentMode.退货;
                txtAmount.DecimalValue = item.Amount;
                txtCheckNum.Text = item.CheckNum;
                txtBank.Text = item.Bank;
                Customer = (new CompanyBLL(AppSettings.Current.ConnStr)).GetByID(item.CustomerID).QueryObject;
                txtCustomer.Text = Customer != null ? Customer.Name : string.Empty;
                txtMemo.Text = item.Memo;
                ShowAssigns();
                ShowOperations(item.ID, item.DocumentType, dataGridView1);
                ShowAttachmentHeaders(item.ID, item.DocumentType, this.gridAttachment);
                ShowButtonState();
            }
        }

        protected override object GetItemFromInput()
        {
            CustomerPayment info = null;
            if (UpdatingItem == null)
            {
                info = new CustomerPayment();
                info.ClassID = PaymentType;
                info.ID = txtID.Text == _AutoCreate ? string.Empty : txtID.Text.Trim();
            }
            else
            {
                info = UpdatingItem as CustomerPayment;
            }
            info.SheetDate = dtSheetDate.Value;
            if (rdTransfer.Checked) info.PaymentMode = PaymentMode.Transfer;
            if (rd转公账.Checked) info.PaymentMode = PaymentMode.转公账;
            if (rdCash.Checked) info.PaymentMode = PaymentMode.Cash;
            if (rd付承兑.Checked) info.PaymentMode = PaymentMode.付承兑;
            if (rd退货.Checked) info.PaymentMode = PaymentMode.退货;
            info.Amount = txtAmount.DecimalValue;
            info.CheckNum = txtCheckNum.Text;
            info.Bank = txtBank.Text;
            info.CustomerID = Customer != null ? Customer.ID : null;
            if (!string.IsNullOrEmpty(StackSheetID)) info.StackSheetID = StackSheetID;
            info.Memo = txtMemo.Text;
            return info;
        }

        protected override CommandResult AddItem(object item)
        {
            CustomerPaymentBLL bll = new CustomerPaymentBLL(AppSettings.Current.ConnStr);
            return bll.ProcessSheet(item as CustomerPayment, SheetOperation.Create, Operator.Current.Name, Operator.Current.ID);
        }

        protected override CommandResult UpdateItem(object item)
        {
            CustomerPaymentBLL bll = new CustomerPaymentBLL(AppSettings.Current.ConnStr);
            return bll.ProcessSheet(item as CustomerPayment, SheetOperation.Modify, Operator.Current.Name, Operator.Current.ID);
        }

        protected override void ShowButtonState()
        {
            base.ShowButtonState(this.toolStrip1);
            CustomerPayment cp = UpdatingItem != null ? UpdatingItem as CustomerPayment : null;

            if (PaymentType == CustomerPaymentType.Customer)
            {
                btnSave.Enabled = btnSave.Enabled && Operator.Current.Permit(Permission.CustomerPayment, PermissionActions.Edit);
                btnAssign.Enabled = cp != null && (cp.State == SheetState.Add || cp.State == SheetState.Approved) && cp.Remain > 0;
                btnApprove.Enabled = btnApprove.Enabled && Operator.Current.Permit(Permission.CustomerPayment, PermissionActions.Approve);
                btnUndoApprove.Enabled = btnUndoApprove.Enabled && Operator.Current.Permit(Permission.CustomerPayment, PermissionActions.UndoApprove);
                btnNullify.Enabled = btnNullify.Enabled && Operator.Current.Permit(Permission.CustomerPayment, PermissionActions.Nullify);
            }
            else if (PaymentType == CustomerPaymentType.Supplier)
            {
                btnSave.Enabled = btnSave.Enabled && Operator.Current.Permit(Permission.SupplierPayment, PermissionActions.Edit);
                btnAssign.Enabled = cp != null && (cp.State == SheetState.Add || cp.State == SheetState.Approved) && cp.Remain > 0;
                btnApprove.Enabled = btnApprove.Enabled && Operator.Current.Permit(Permission.SupplierPayment, PermissionActions.Approve);
                btnUndoApprove.Enabled = btnUndoApprove.Enabled && Operator.Current.Permit(Permission.SupplierPayment, PermissionActions.UndoApprove);
                btnNullify.Enabled = btnNullify.Enabled && Operator.Current.Permit(Permission.SupplierPayment, PermissionActions.Nullify);
            }
            else
            {
                btnSave.Enabled = false;
                btnAssign.Enabled = false;
                btnApprove.Enabled = false;
                btnUndoApprove.Enabled = false;
                btnNullify.Enabled = false;
            }
        }
        #endregion

        #region 与附件操作相关的方法和事件处理程序
        private void mnu_AttachmentAdd_Click(object sender, EventArgs e)
        {
            CustomerPayment item = UpdatingItem as CustomerPayment;
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

        #region 工具栏事件处理
        private void btnSave_Click(object sender, EventArgs e)
        {
            CustomerPaymentBLL processor = new CustomerPaymentBLL(AppSettings.Current.ConnStr);
            SheetOperation so = IsAdding ? SheetOperation.Create : SheetOperation.Modify;
            PerformOperation<CustomerPayment>(processor, so);
            if (so == SheetOperation.Create && !string.IsNullOrEmpty(StackSheetID)) //如果已经是确定收款是用于哪个出入库单了, 新建时直接核销
            {
                new CustomerPaymentBLL(AppSettings.Current.ConnStr).PaymentAssign(UpdatingItem as CustomerPayment);
                this.Close();
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            CustomerPaymentBLL processor = new CustomerPaymentBLL(AppSettings.Current.ConnStr);
            PerformOperation<CustomerPayment>(processor, SheetOperation.Approve);
        }

        private void btnUndoApprove_Click(object sender, EventArgs e)
        {
            List<CustomerPaymentAssign> assigns = (new CustomerPaymentBLL(AppSettings.Current.ConnStr)).GetAssigns((UpdatingItem as CustomerPayment).ID).QueryObjects;
            if (assigns != null && assigns.Count > 0)
            {
                string msg = "\"取消审核\"的操作会删除此单的所有核销项删除，是否继续?";
                if (MessageBox.Show(msg, "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            }
            CustomerPaymentBLL processor = new CustomerPaymentBLL(AppSettings.Current.ConnStr);
            PerformOperation<CustomerPayment>(processor, SheetOperation.UndoApprove);

            UpdatingItem = (new CustomerPaymentBLL(AppSettings.Current.ConnStr)).GetByID((UpdatingItem as CustomerPayment).ID).QueryObject;
            ItemShowing();
            OnItemUpdated(new ItemUpdatedEventArgs(UpdatingItem));
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (UpdatingItem != null)
            {
                string paymentID = (UpdatingItem as CustomerPayment).ID;
                FrmPaymentAssign frm = new FrmPaymentAssign();
                frm.CustomerPaymentID = paymentID;
                this.Close();
                frm.ShowDialog();
            }
        }

        private void btnNullify_Click(object sender, EventArgs e)
        {
            List<CustomerPaymentAssign> assigns = (new CustomerPaymentBLL(AppSettings.Current.ConnStr)).GetAssigns((UpdatingItem as CustomerPayment).ID).QueryObjects;
            if (assigns != null && assigns.Count > 0)
            {
                string msg = "\"作废\"的操作会删除此单的所有核销项删除，是否继续?";
                if (MessageBox.Show(msg, "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            }
            CustomerPaymentBLL processor = new CustomerPaymentBLL(AppSettings.Current.ConnStr);
            PerformOperation<CustomerPayment>(processor, SheetOperation.Nullify);

            UpdatingItem = (new CustomerPaymentBLL(AppSettings.Current.ConnStr)).GetByID((UpdatingItem as CustomerPayment).ID).QueryObject;
            ItemShowing();
            OnItemUpdated(new ItemUpdatedEventArgs(UpdatingItem));
        }
        #endregion

        #region 事件处理程序
        private void lnkCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmMasterBase frm = null;
            if (PaymentType == CustomerPaymentType.Customer)
            {
                frm = new FrmCustomerMaster();
            }
            else
            {
                frm = new FrmSupplierMaster();
            }
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Customer = frm.SelectedItem as CompanyInfo;
                txtCustomer.Text = Customer != null ? Customer.Name : string.Empty;
            }
        }

        private void mnu_UndoAssign_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> delRows = new List<DataGridViewRow>();
            if (ItemsGrid.SelectedRows != null && ItemsGrid.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("是否要取消此核销项?", "询问", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in ItemsGrid.SelectedRows)
                    {
                        CustomerPaymentAssign assign = row.Tag as CustomerPaymentAssign;
                        CommandResult ret = (new CustomerPaymentAssignBLL(AppSettings.Current.ConnStr)).UndoAssign(assign);
                        if (ret.Result == ResultCode.Successful) delRows.Add(row);
                    }
                }
            }
            delRows.ForEach(it => ItemsGrid.Rows.Remove(it));
            UpdatingItem = (new CustomerPaymentBLL(AppSettings.Current.ConnStr)).GetByID((UpdatingItem as CustomerPayment).ID).QueryObject;
            OnItemUpdated(new ItemUpdatedEventArgs(UpdatingItem));
            ShowButtonState();
        }
        #endregion

        private void rdTransfer_CheckedChanged(object sender, EventArgs e)
        {
            txtBank.Enabled = rdTransfer.Checked;
        }
    }
}
