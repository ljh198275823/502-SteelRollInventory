﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using LJH.Inventory.BLL;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.GeneralLibrary.Core.DAL;
using LJH.Inventory.UI.Forms.Sale;
using LJH.Inventory.UI.Forms.Financial;
using LJH.Inventory.UI.Forms.General;
using LJH.Inventory.UI.Forms.Sale.View;

namespace LJH.Inventory.UI.Forms.Inventory
{
    public partial class FrmStackOutSheetDetail : FrmSheetDetailBase
    {
        #region 构造函数
        public FrmStackOutSheetDetail()
        {
            InitializeComponent();
        }

        #endregion

        #region 私有方法
        private void ShowSheet(StackOutSheet item)
        {
            if (!string.IsNullOrEmpty(item.ID))
            {
                this.txtSheetNo.Text = item.ID;
                this.txtSheetNo.Enabled = false;
            }
            var Customer = (new CompanyBLL(AppSettings.Current.ConnStr)).GetByID(item.CustomerID).QueryObject;
            this.txtCustomer.Text = Customer != null ? Customer.Name : string.Empty;
            this.txtCustomer.Tag = Customer;
            var WareHouse = (new WareHouseBLL(AppSettings.Current.ConnStr)).GetByID(item.WareHouseID).QueryObject;
            dtSheetDate.Value = item.SheetDate;
            this.txtLinker.Text = item.Linker;
            this.txtLinkerPhone.Text = item.LinkerCall;
            this.txtAddress.Text = item.Address;
            txtDriver.Text = item.Driver;
            txtDriverCall.Text = item.DriverCall;
            txtCarPlate.Text = item.CarPlate;
            chkDeadline.Checked = item.DeadlineDate.HasValue;
            dtDeadline.Value = item.DeadlineDate.HasValue ? item.DeadlineDate.Value : DateTime.Today;
            rdWithoutTax.Checked = item.WithTax == false;
            rdWithTax.Checked = item.WithTax == true;
            this.txtMemo.Text = item.Memo;
            ShowDeliveryItemsOnGrid(item);
            ShowOperations(item.ID, item.DocumentType, dataGridView1);
            ShowAttachmentHeaders(item.ID, item.DocumentType, this.gridAttachment);
            ShowPaymentState(item);
        }

        private void ShowPaymentState(StackOutSheet item)
        {
            var finance = new StackOutSheetBLL(AppSettings.Current.ConnStr).GetFinancialStateOf(item.ID).QueryObject;
            if (finance != null) lnkPayment.Text = finance.Paid.ToString("C2");
        }

        private void ShowDeliveryItemsOnGrid(StackOutSheet sheet)
        {
            ItemsGrid.Rows.Clear();
            var items = sheet.GetSummaryItems();
            if (items != null)
            {
                foreach (StackOutItem item in items)
                {
                    int row = ItemsGrid.Rows.Add();
                    ShowDeliveryItemOnRow(ItemsGrid.Rows[row], item);
                }
                int r = ItemsGrid.Rows.Add();
                ItemsGrid.Rows[r].Cells["colCount"].Value = "合计";
                ItemsGrid.Rows[r].Cells["colTotal"].Value = sheet.Amount;
            }
        }

        private void ShowDeliveryItemOnRow(DataGridViewRow row, StackOutItem item)
        {
            row.Tag = item;
            Product p = new ProductBLL(AppSettings.Current.ConnStr).GetByID(item.ProductID).QueryObject;
            if (item.ID == Guid.Empty || item.InventoryItem == null)
            {
                row.Cells["colHeader"].Value = this.ItemsGrid.Rows.Count;
                row.Cells["colSpecification"].Value = p != null ? p.Specification : string.Empty;
                row.Cells["colCategory"].Value = p != null && p.Category != null ? p.Category.Name : string.Empty;
                row.Cells["colModel"].Value = p.Model;
                row.Cells["colLength"].Value = item.Length;
                row.Cells["colWeight"].Value = item.TotalWeight;
                row.Cells["colPrice"].Value = item.Price;
                row.Cells["colCount"].Value = item.Count;
                row.Cells["colTotal"].Value = item.Amount;
                row.Cells["colMemo"].Value = item.Memo;
                row.Cells["colCount"].ReadOnly = true;
            }
            else
            {
                ProductInventoryItem pi = null;
                if (item.InventoryItem != null) pi = new ProductInventoryItemBLL(AppSettings.Current.ConnStr).GetByID(item.InventoryItem.Value).QueryObject;
                ProductInventoryItemSearchCondition con = new ProductInventoryItemSearchCondition() { DeliveryItem = item.ID };
                var assigns = new ProductInventoryItemBLL(AppSettings.Current.ConnStr).GetItems(con).QueryObjects;
                row.Cells["colModel"].Value = pi != null ? pi.WareHouse.Name : null;
                row.Cells["colWeight"].Value = pi != null ? (pi.RealThick.HasValue ? (decimal?)pi.RealThick : (decimal?)pi.OriginalThick) : null;
                row.Cells["colPrice"].Value = pi != null ? pi.Customer : null;
                row.Cells["colCount"].Value = item.Count;
                decimal maxCount = (assigns == null || assigns.Count == 0) ? pi.Count : pi.Count + assigns.Sum(it => it.Count); //
                row.Cells["colTotal"].Value = maxCount - item.Count;
                row.Cells["colTotal"].Tag = maxCount;
                row.Cells["colTotal"].Style.Format = "N0";
                row.Cells["colMemo"].Value = pi != null ? pi.Memo : null;

                row.Cells["colWeight"].ReadOnly = true;
                row.Cells["colPrice"].ReadOnly = true;
                row.Cells["colMemo"].ReadOnly = true;
            }
        }
        #endregion

        #region 重写基类方法
        protected override bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtSheetNo.Text) && UpdatingItem != null)
            {
                MessageBox.Show("送货单号不能为空");
                txtSheetNo.Focus();
                return false;
            }
            if (txtCustomer.Tag == null)
            {
                MessageBox.Show("没有选择客户");
                txtCustomer.Focus();
                return false;
            }
            if (!rdWithTax.Checked && !rdWithoutTax.Checked)
            {
                MessageBox.Show("请选择是否含税");
                return false;
            }
            if (ItemsGrid.Rows.Count == 0)
            {
                MessageBox.Show("送货单没有填写送货项");
                return false;
            }
            foreach (DataGridViewRow row in ItemsGrid.Rows)
            {
                StackOutItem item = row.Tag as StackOutItem;
                if (item != null && item.Count == 0)
                {
                    MessageBox.Show(string.Format("送货单第 {0} 项送货数量为零", row.Index + 1));
                    row.Selected = true;
                    return false;
                }
            }
            return true;
        }

        protected override void InitControls()
        {
            base.InitControls();
            this.txtSheetNo.Text = _AutoCreate;
            btn_AddSlice.Visible = !UserSettings.Current.ForbidWhenNoOrderID;
            if (IsForView)
            {
                toolStrip1.Enabled = false;
                ItemsGrid.ReadOnly = true;
                ItemsGrid.ContextMenu = null;
                ItemsGrid.ContextMenuStrip = null;
            }
            btnShip.Visible = !(UserSettings.Current != null && UserSettings.Current.DoShipAfterPrint);
        }

        protected override void ItemShowing()
        {
            StackOutSheet sheet = UpdatingItem as StackOutSheet;
            if (sheet != null) ShowSheet(sheet);
        }

        protected override object GetItemFromInput()
        {
            StackOutSheet sheet = UpdatingItem as StackOutSheet;
            sheet.ID = txtSheetNo.Text == "自动创建" ? string.Empty : this.txtSheetNo.Text;
            sheet.CustomerID = txtCustomer.Tag != null ? (txtCustomer.Tag as CompanyInfo).ID : null;
            sheet.SheetDate = dtSheetDate.Value;
            sheet.Linker = txtLinker.Text.Trim();
            sheet.LinkerCall = txtLinkerPhone.Text.Trim();
            sheet.Address = txtAddress.Text.Trim();
            sheet.DriverCall = txtDriverCall.Text;
            sheet.Driver = txtDriver.Text;
            sheet.CarPlate = txtCarPlate.Text;
            sheet.DeadlineDate = chkDeadline.Checked ? (DateTime?)dtDeadline.Value : null;
            if (rdWithTax.Checked) sheet.WithTax = true;
            if (rdWithoutTax.Checked) sheet.WithTax = false;
            sheet.Memo = txtMemo.Text;
            return sheet;
        }

        protected override void ShowButtonState()
        {
            ShowButtonState(this.toolStrip1);
            btnSave.Enabled = btnSave.Enabled && Operator.Current.Permit(Permission.DeliverySheet, PermissionActions.Edit);
            btnNullify.Enabled = btnNullify.Enabled && Operator.Current.Permit(Permission.DeliverySheet, PermissionActions.Nullify);
            btnPrint.Enabled = btnPrint.Enabled && Operator.Current.Permit(Permission.DeliverySheet, PermissionActions.Print);
            btnShip.Enabled = btnShip.Enabled && Operator.Current.Permit(Permission.DeliverySheet, PermissionActions.Ship);
            btnPayment.Enabled = btnPayment.Enabled && Operator.Current.Permit(Permission.CustomerPayment, PermissionActions.Edit);
            ItemsGrid.ContextMenuStrip = btnSave.Enabled ? this.contextMenuStrip1 : null;
            ItemsGrid.ReadOnly = !btnSave.Enabled;
        }
        #endregion

        #region 与附件操作相关的方法和事件处理程序
        private void mnu_AttachmentAdd_Click(object sender, EventArgs e)
        {
            StackOutSheet item = UpdatingItem as StackOutSheet;
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
            StackOutSheetBLL bll = new StackOutSheetBLL(AppSettings.Current.ConnStr);
            PerformOperation<StackOutSheet>(bll, IsAdding ? SheetOperation.Create : SheetOperation.Modify);
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            var sheet = UpdatingItem as StackOutSheet;
            if (sheet == null || sheet.State == SheetState.Canceled) return;
            if (string.IsNullOrEmpty(sheet.ID))
            {
                MessageBox.Show("请先保存送货单后再支付");
                return;
            }
            Financial.FrmCustomerPaymentDetail frm = new Financial.FrmCustomerPaymentDetail();
            frm.PaymentType = CustomerPaymentType.Customer;
            frm.Customer = (txtCustomer.Tag as CompanyInfo);
            frm.StackSheetID = sheet.ID;
            frm.IsAdding = true;
            frm.ShowDialog();
            ShowPaymentState(sheet);
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            StackOutSheetBLL bll = new StackOutSheetBLL(AppSettings.Current.ConnStr);
            PerformOperation<StackOutSheet>(bll, SheetOperation.Approve);
        }

        private void btnUndoApprove_Click(object sender, EventArgs e)
        {
            StackOutSheetBLL bll = new StackOutSheetBLL(AppSettings.Current.ConnStr);
            PerformOperation<StackOutSheet>(bll, SheetOperation.UndoApprove);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            StackOutSheet sheet = UpdatingItem as StackOutSheet;
            if (sheet != null)
            {
                try
                {
                    if (sheet.State == SheetState.Add)
                    {
                        var ret = new StackOutSheetBLL(AppSettings.Current.ConnStr).ProcessSheet(sheet, SheetOperation.Modify, Operator.Current.Name, Operator.Current.ID);
                        if (ret.Result != ResultCode.Successful)
                        {
                            MessageBox.Show(ret.Message);
                            return;
                        }
                        else
                        {
                            this.OnItemUpdated(new LJH.GeneralLibrary.Core.UI.ItemUpdatedEventArgs(sheet));
                        }
                    }
                    string modal = System.IO.Path.Combine(Application.StartupPath, "送货单模板.xls");
                    Print.StackOutSheetExporter exporter = null;
                    if (System.IO.File.Exists(modal))
                    {
                        exporter = new Print.StackOutSheetExporter(modal);
                        var files = exporter.Export(sheet, LJH.GeneralLibrary.TempFolderManager.GetCurrentFolder());
                        foreach (var file in files)
                        {
                            if (System.IO.File.Exists(file))
                            {
                                ProcessStartInfo psi = new ProcessStartInfo(file);
                                psi.Verb = "Print";
                                psi.CreateNoWindow = true;
                                psi.WindowStyle = ProcessWindowStyle.Hidden;
                                psi.UseShellExecute = true;

                                Process prs = new Process();
                                prs.StartInfo = psi;
                                prs.Start();
                            }
                        }
                        if (sheet.State != SheetState.Shipped && UserSettings.Current != null && UserSettings.Current.DoShipAfterPrint)
                        {
                            var ret = new StackOutSheetBLL(AppSettings.Current.ConnStr).ProcessSheet(sheet, SheetOperation.StackOut, Operator.Current.Name, Operator.Current.ID);
                            if (ret.Result != ResultCode.Successful)
                            {
                                MessageBox.Show(ret.Message);
                                return;
                            }
                            else
                            {
                                ShowButtonState();
                                this.OnItemUpdated(new LJH.GeneralLibrary.Core.UI.ItemUpdatedEventArgs(sheet));
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("未找到送货单导出模板", "打印失败");
                    }
                }
                catch (Exception ex)
                {
                    LJH.GeneralLibrary.ExceptionHandling.ExceptionPolicy.HandleException(ex);
                }
            }
        }

        private bool CheckCredit()
        {
            StackOutSheetBLL bll = new StackOutSheetBLL(AppSettings.Current.ConnStr);
            StackOutSheet sheet = UpdatingItem as StackOutSheet;
            StackOutSheetFinancialState fstate = bll.GetFinancialStateOf(sheet.ID).QueryObject;
            CustomerFinancialState cstate = new CompanyBLL(AppSettings.Current.ConnStr).GetCustomerState(sheet.CustomerID).QueryObject;
            decimal credit = cstate.Credit + (fstate != null ? fstate.NotPaid : 0);
            if (credit > cstate.Customer.CreditLine)
            {
                if (UserSettings.Current.ForbidWhenOverCreditLimit)
                {
                    MessageBox.Show("已经超出客户 " + cstate.Customer.Name + " 的信用额度，不能再发货。");
                    return false;
                }
                else if (UserSettings.Current.ReminderWhenOverCreditLimit)
                {
                    if (MessageBox.Show("已经超出客户 " + cstate.Customer.Name + " 的信用额度，是否继续发货?", "询问", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return false ;
                    }
                }
            }
            return true;
        }

        private void btnShip_Click(object sender, EventArgs e)
        {
            StackOutSheetBLL bll = new StackOutSheetBLL(AppSettings.Current.ConnStr);
            if (CheckCredit())
            {
                PerformOperation<StackOutSheet>(bll, SheetOperation.StackOut);
                StackOutSheet sheet = UpdatingItem as StackOutSheet;
                if (sheet.State == SheetState.Shipped)
                {
                    new StackOutSheetBLL(AppSettings.Current.ConnStr).AssignPayment(sheet);
                    ShowPaymentState(sheet);
                }
            }
        }

        private void btnNullify_Click(object sender, EventArgs e)
        {
            StackOutSheetBLL bll = new StackOutSheetBLL(AppSettings.Current.ConnStr);
            PerformOperation<StackOutSheet>(bll, SheetOperation.Nullify);
        }
        #endregion

        #region 事件处理程序
        private void lnkCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmCustomerFinancialStateMaster frm = new FrmCustomerFinancialStateMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var ct = frm.SelectedItem as CustomerFinancialState;
                var c = ct.Customer;
                txtCustomer.Tag = c;
                txtCustomer.Text = c != null ? c.Name : string.Empty;
                txtAddress.Text = c != null ? c.Address : string.Empty;
                if (c.DefaultLinker != null)
                {
                    var contact = new ContactBLL(AppSettings.Current.ConnStr).GetByID(c.DefaultLinker.Value).QueryObject;
                    if (contact != null)
                    {
                        txtLinker.Text = contact.Name;
                        txtLinkerPhone.Text = contact.Mobile;
                    }
                }
            }
        }

        private void txtCustomer_DoubleClick(object sender, EventArgs e)
        {
            txtCustomer.Text = string.Empty;
            txtCustomer.Tag = null;
            txtLinker.Text = string.Empty;
            txtLinkerPhone.Text = string.Empty;
        }

        private void ItemsGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = ItemsGrid.Rows[e.RowIndex];
            StackOutItem item = row.Tag as StackOutItem;
            if (item == null) return; //表示合计行
            StackOutSheet sheet = UpdatingItem as StackOutSheet;
            DataGridViewColumn col = ItemsGrid.Columns[e.ColumnIndex];
            if (col.Name == "colMemo")
            {
                foreach (var it in sheet.Items)
                {
                    if (it.ProductID == item.ProductID) it.Memo = row.Cells["colMemo"].Value != null ? row.Cells["colMemo"].Value.ToString() : null;
                }
            }
            else
            {
                decimal value;
                if (row.Cells[e.ColumnIndex].Value != null && decimal.TryParse(row.Cells[e.ColumnIndex].Value.ToString().TrimStart('¥'), out value))
                {
                    if (value < 0) value = 0;
                    if (col.Name == "colPrice")
                    {
                        item.Price = value;
                        foreach (var it in sheet.Items)
                        {
                            if (it.ProductID == item.ProductID) it.Price = value;
                        }
                        row.Cells[e.ColumnIndex].Value = value;
                        row.Cells["colTotal"].Value = item.Amount;
                    }
                    else if (col.Name == "colCount")
                    {
                        if (value <= Convert.ToInt32(row.Cells["colTotal"].Tag)) //数量不能超出库存项的数量
                        {
                            item.Count = value;
                            row.Cells["colTotal"].Value = Convert.ToInt32(row.Cells["colTotal"].Tag) - item.Count;
                        }
                        else
                        {
                            row.Cells[e.ColumnIndex].Value = item.Count;
                        }
                        for (int i = e.RowIndex; i >= 0; i--) //找合并送货单项的行
                        {
                            var si = ItemsGrid.Rows[i].Tag as StackOutItem;
                            if (si.ID == Guid.Empty && si.ProductID == item.ProductID)
                            {
                                si.Count = sheet.Items.Sum(it => it.ProductID == item.ProductID ? it.Count : 0);
                                ItemsGrid.Rows[i].Cells["colCount"].Value = si.Count;
                                ItemsGrid.Rows[i].Cells["colTotal"].Value = si.Amount;
                                break;
                            }
                        }
                    }
                    else if (col.Name == "colWeight")
                    {
                        item.TotalWeight = value > 0 ? (decimal?)value : null;
                        row.Cells[e.ColumnIndex].Value = value;
                        foreach (var it in sheet.Items)
                        {
                            if (it.ProductID == item.ProductID) it.TotalWeight = value;
                        }
                        row.Cells["colTotal"].Value = item.Amount;
                    }
                    ItemsGrid.Rows[ItemsGrid.Rows.Count - 1].Cells["colTotal"].Value = sheet.Amount;
                }
            }
        }

        private void ItemsGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn col = ItemsGrid.Columns[e.ColumnIndex];
            if (col.Name != "colCount") return;
            DataGridViewRow row = ItemsGrid.Rows[e.RowIndex];
            StackOutSheet sheet = UpdatingItem as StackOutSheet;
            StackOutItem item = row.Tag as StackOutItem;
            if (item == null || item.ID != Guid.Empty) return; //没有点在合并的列上, 不动作
            List<DataGridViewRow> delingRows = new List<DataGridViewRow>();
            for (int i = e.RowIndex + 1; i < ItemsGrid.Rows.Count; i++)
            {
                StackOutItem d = ItemsGrid.Rows[i].Tag as StackOutItem;
                if (d != null && d.ProductID == item.ProductID && d.ID != Guid.Empty) //如果下一行是同一种产品，则说明可以合并起来
                {
                    delingRows.Add(ItemsGrid.Rows[i]);
                }
                else
                {
                    break;
                }
            }
            if (delingRows.Count > 0) //之前已经展开,则收起
            {
                foreach (var dr in delingRows)
                {
                    ItemsGrid.Rows.Remove(dr);
                }
            }
            else //之前没有展开,展开
            {
                int rowIndex = e.RowIndex + 1;
                foreach (var si in sheet.Items)
                {
                    if (item.ProductID == si.ProductID)
                    {
                        ItemsGrid.Rows.Insert(rowIndex);
                        ShowDeliveryItemOnRow(ItemsGrid.Rows[rowIndex], si);
                        rowIndex++;
                    }
                }
            }
        }

        private void btn_AddSlice_Click(object sender, EventArgs e)
        {
            FrmSteelRollSliceSelection frm = new FrmSteelRollSliceSelection();
            ProductInventoryItemSearchCondition con = new ProductInventoryItemSearchCondition();
            con.States = (int)ProductInventoryState.Inventory; //只显示在库的
            con.HasRemain = true;
            frm.SearchCondition = con;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                StackOutSheet sheet = UpdatingItem as StackOutSheet;
                var items = frm.SelectedItems;
                if (items != null && items.Count > 0)
                {
                    foreach (var item in items)
                    {
                        sheet.AddItems(item.Key, item.Value);
                    }
                    ShowDeliveryItemsOnGrid(sheet);
                }
            }
        }

        private void mnu_AddSteelRoll_Click(object sender, EventArgs e)
        {
            FrmSteelRollMaster frm = new FrmSteelRollMaster();
            frm.ForSelect = true;
            ProductInventoryItemSearchCondition con = new ProductInventoryItemSearchCondition();
            con.States = (int)ProductInventoryState.Inventory; //只显示在库的原材料
            frm.SearchCondition = con;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ProductInventoryItem sr = frm.SelectedItem as ProductInventoryItem;
                var ret = new SteelRollBLL(AppSettings.Current.ConnStr).UpdateProduct(sr);
                if (ret.Result == ResultCode.Successful)
                {
                    var sheet = UpdatingItem as StackOutSheet;
                    sheet.AddItems(sr, 1);
                    ShowDeliveryItemsOnGrid(sheet);
                }
                else
                {
                    MessageBox.Show(ret.Message);
                }
            }
        }

        private void 其它费用ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProductMaster frm = new FrmProductMaster();
            frm.ForSelect = true;
            ProductSearchCondition con = new ProductSearchCondition();
            con.IsService = true;
            frm.SearchCondition = con;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                StackOutSheet sheet = UpdatingItem as StackOutSheet;
                Product p = frm.SelectedItem as Product;
                if (p != null)
                {
                    sheet.AddItems(p, 1);
                    ShowDeliveryItemsOnGrid(sheet);
                }
            }
        }

        private void mnu_Remove_Click(object sender, EventArgs e)
        {
            if (ItemsGrid.SelectedCells.Count > 0)
            {
                StackOutSheet sheet = UpdatingItem as StackOutSheet;
                foreach (DataGridViewCell cell in ItemsGrid.SelectedCells)
                {
                    var row = ItemsGrid.Rows[cell.RowIndex];
                    if (row.Tag != null)
                    {
                        StackOutItem si = row.Tag as StackOutItem;
                        if (si.ID == Guid.Empty)
                        {
                            sheet.Items.RemoveAll(it => it.ProductID == si.ProductID);
                        }
                        else
                        {
                            sheet.Items.Remove(si);
                        }
                    }
                }
                ShowDeliveryItemsOnGrid(sheet);
            }
        }

        private void lnkLinker_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtCustomer.Tag != null)
            {
                FrmContactMaster frm = new FrmContactMaster();
                ContactSearchCondition con = new ContactSearchCondition();
                con.CompanyID = (txtCustomer.Tag as CompanyInfo).ID;
                frm.SearchCondition = con;
                frm.ForSelect = true;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Contact c = frm.SelectedItem as Contact;
                    txtLinker.Text = c.Name;
                    txtLinkerPhone.Text = c.Mobile;
                }
            }
            else
            {
                MessageBox.Show("请先选择客户");
            }
        }

        private void lnkDriver_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmStaffMaster frm = new FrmStaffMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Staff s = frm.SelectedItem as Staff;
                txtDriver.Text = s.Name;
                txtDriverCall.Text = s.Phone;
            }
        }
        #endregion

        
    }
}
