﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.UI.View;
using LJH.Inventory.BLL;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.UI;

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmOrderDetail : FrmSheetDetailBase
    {
        public FrmOrderDetail()
        {
            InitializeComponent();
        }

        #region 私有方法
        private void ShowDeliveryItemsOnGrid(IEnumerable<OrderItem> items)
        {
            ItemsGrid.Rows.Clear();
            if (items != null)
            {
                List<string> pids = items.Select(it => it.ProductID).ToList();
                List<Product> ps = (new ProductBLL(AppSettings.Current.ConnStr)).GetItems(new ProductSearchCondition() { ProductIDS = pids }).QueryObjects;
                foreach (OrderItem item in items)
                {
                    int row = ItemsGrid.Rows.Add();
                    Product p = ps.SingleOrDefault(it => it.ID == item.ProductID);
                    ShowDeliveryItemOnRow(ItemsGrid.Rows[row], item, p);
                }
                int r = ItemsGrid.Rows.Add();
                ItemsGrid.Rows[r].Cells["colCount"].Value = "合计";
                ItemsGrid.Rows[r].Cells["colTotal"].Value = items.Sum(it => it.Amount).Trim();
            }
        }

        private void ShowDeliveryItemOnRow(DataGridViewRow row, OrderItem item, Product p)
        {
            row.Tag = item;
            row.Cells["colHeader"].Value = this.ItemsGrid.Rows.Count;
            row.Cells["colProductID"].Value = item.ProductID;
            row.Cells["colProductName"].Value = p != null ? p.Name : string.Empty;
            row.Cells["colSpecification"].Value = p != null ? p.Specification : string.Empty;
            row.Cells["colCategory"].Value = p != null && p.Category != null ? p.Category.Name : string.Empty;
            row.Cells["colUnit"].Value = item.Unit;
            row.Cells["colPrice"].Value = item.Price.Trim();
            row.Cells["colCount"].Value = item.Count.Trim();
            row.Cells["colTotal"].Value = item.Amount.Trim();
            row.Cells["colMemo"].Value = item.Memo;
        }

        private List<OrderItem> GetOrderItemsFromGrid()
        {
            List<OrderItem> items = new List<OrderItem>();
            foreach (DataGridViewRow row in ItemsGrid.Rows)
            {
                if (row.Tag != null) items.Add(row.Tag as OrderItem);
            }
            return items;
        }

        private decimal GetTotalAmount()
        {
            decimal sum = 0;
            foreach (DataGridViewRow row in ItemsGrid.Rows)
            {
                if (row.Tag != null) sum += (row.Tag as OrderItem).Amount;
            }
            return sum.Trim();
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置订单所属的客户
        /// </summary>
        public CompanyInfo Customer { get; set; }
        #endregion

        #region 重写基类方法
        protected override bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtSheetNo.Text) && UpdatingItem != null)
            {
                MessageBox.Show("订单号不能为空");
                txtSheetNo.Focus();
                return false;
            }
            if (Customer == null)
            {
                MessageBox.Show("没有选择客户");
                txtCustomer.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtSalesPerson.Text))
            {
                MessageBox.Show("业务人员不能为空");
                txtSalesPerson.Focus();
                return false;
            }
            if (!rdWithTax.Checked && !rdWithoutTax.Checked)
            {
                MessageBox.Show("没有选择订单的含税情况");
                rdWithTax.Focus();
                return false;
            }
            if (ItemsGrid.Rows.Count == 0)
            {
                MessageBox.Show("订单没有填写订货项");
                return false;
            }
            foreach (DataGridViewRow row in ItemsGrid.Rows)
            {
                OrderItem item = row.Tag as OrderItem;
                if (item != null && item.Count == 0)
                {
                    MessageBox.Show(string.Format("订单第 {0} 项数量为零", row.Index + 1));
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
            this.txtCustomer.Text = Customer != null ? Customer.Name : string.Empty;
            this.dtDemandDate.Value = DateTime.Today.AddDays(1);
            Operator opt = Operator.Current;
            ItemsGrid.Columns["colPrice"].Visible = Operator.Current.Permit(Permission.ReadPrice);
            ItemsGrid.Columns["colTotal"].Visible = Operator.Current.Permit(Permission.ReadPrice);
            if (IsForView)
            {
                toolStrip1.Enabled = false;
                ItemsGrid.ReadOnly = true;
                ItemsGrid.ContextMenu = null;
                ItemsGrid.ContextMenuStrip = null;
            }
        }

        protected override void ItemShowing()
        {
            Order item = UpdatingItem as Order;
            if (item != null)
            {
                this.txtSheetNo.Text = item.ID;
                this.txtSheetNo.Enabled = false;
                Customer = (new CompanyBLL(AppSettings.Current.ConnStr)).GetByID(item.CustomerID).QueryObject;
                this.txtCustomer.Text = Customer != null ? Customer.Name : item.CustomerID;
                this.dtOrderDate.Value = item.OrderDate;
                this.txtSalesPerson.Text = item.SalesPerson;
                this.dtDemandDate.Value = item.DemandDate;
                this.rdWithTax.Checked = item.WithTax;
                this.rdWithoutTax.Checked = !item.WithTax;
                ShowDeliveryItemsOnGrid(item.Items);
                List<DocumentOperation> items = (new DocumentOperationBLL(AppSettings.Current.ConnStr)).GetHisOperations(item.ID, item.DocumentType).QueryObjects;
                ShowOperations(items, dataGridView1);
                List<AttachmentHeader> headers = (new AttachmentBLL(AppSettings.Current.ConnStr)).GetHeaders(item.ID, item.DocumentType).QueryObjects;
                ShowAttachmentHeaders(headers, this.gridAttachment);
                ShowButtonState();
            }
        }

        protected override object GetItemFromInput()
        {
            Order order = UpdatingItem as Order;
            if (order == null)
            {
                order = new Order();
                order.Items = new List<OrderItem>();
                order.LastActiveDate = DateTime.Now;
                order.ID = txtSheetNo.Text == "自动创建" ? string.Empty : this.txtSheetNo.Text;
            }
            else
            {
                order = UpdatingItem as Order;
            }
            order.OrderDate = this.dtOrderDate.Value;
            order.CustomerID = Customer.ID;
            order.SalesPerson = this.txtSalesPerson.Text;
            order.DemandDate = this.dtDemandDate.Value;
            order.WithTax = rdWithTax.Checked;
            order.Items = GetOrderItemsFromGrid();
            order.Items.ForEach(item => item.DemandDate = order.DemandDate);
            order.Items.ForEach(item => item.OrderID = order.ID);
            return order;
        }

        protected override void ShowButtonState()
        {
            if (UpdatingItem == null)
            {
                this.btnOk.Enabled = true;
                this.btnPrint.Enabled = false;
                this.btnApprove.Enabled = false;
                this.btnShip.Enabled = false;
            }
            else
            {
                Order sheet = UpdatingItem as Order;
                this.btnSave.Enabled = sheet.CanEdit;
                this.btnPrint.Enabled = true;
                this.btnApprove.Enabled = sheet.CanApprove;
            }
        }

        protected override CommandResult AddItem(object item)
        {
            return (new OrderBLL(AppSettings.Current.ConnStr)).ProcessSheet(item as Order, SheetOperation.Create, Operator.Current.Name);
        }

        protected override CommandResult UpdateItem(object item)
        {
            return (new OrderBLL(AppSettings.Current.ConnStr)).ProcessSheet(item as Order, SheetOperation.Modify, Operator.Current.Name);
        }
        #endregion

        #region 与附件操作相关的方法和事件处理程序
        private void mnu_AttachmentAdd_Click(object sender, EventArgs e)
        {
            Order item = UpdatingItem as Order;
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

        #region 工具栏处理程序
        private void btnSave_Click(object sender, EventArgs e)
        {
            OrderBLL  processor = new OrderBLL(AppSettings.Current.ConnStr);
            PerformCreateOrModify<Order>(processor, IsAdding ? SheetOperation.Create : SheetOperation.Modify);
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            OrderBLL processor = new OrderBLL(AppSettings.Current.ConnStr);
            PerformCreateOrModify<Order>(processor, SheetOperation.Approve);
        }

        private void btnUndoApprove_Click(object sender, EventArgs e)
        {
            OrderBLL processor = new OrderBLL(AppSettings.Current.ConnStr);
            PerformOperation<Order>(processor, SheetOperation.UndoApprove);
        }

        private void btnNullify_Click(object sender, EventArgs e)
        {
            OrderBLL processor = new OrderBLL(AppSettings.Current.ConnStr);
            PerformOperation<Order>(processor, SheetOperation.Nullify);
        }

        private void btnShip_Click(object sender, EventArgs e)
        {
            if (UpdatingItem != null)
            {
                Order order = UpdatingItem as Order;
                FrmDeliverySheetDetail frm = new FrmDeliverySheetDetail();
                frm.Order = order;
                frm.IsAdding = true;
                frm.ShowDialog();
            }
        }
        #endregion

        #region 公共方法
        public void AddOrdertem(Product product)
        {
            List<OrderItem> sources = GetOrderItemsFromGrid();
            if (!sources.Exists(it => it.ProductID == product.ID))
            {
                OrderItem item = new OrderItem()
                 {
                     ID = Guid.NewGuid(),
                     ProductID = product.ID,
                     Unit = product.Unit,
                     Price = product.Price,
                     Count = 0
                 };
                sources.Add(item);
            }
            ShowDeliveryItemsOnGrid(sources);
        }
        #endregion

        #region 事件处理程序
        private void ItemsGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn col = ItemsGrid.Columns[e.ColumnIndex];
            DataGridViewRow row = ItemsGrid.Rows[e.RowIndex];
            if (row.Tag != null)
            {
                OrderItem item = row.Tag as OrderItem;
                if (col.Name == "colPrice")
                {
                    decimal price;
                    if (decimal.TryParse(row.Cells[e.ColumnIndex].Value.ToString(), out price))
                    {
                        if (price < 0) price = 0;
                        item.Price = price;
                        row.Cells[e.ColumnIndex].Value = price;
                    }
                }
                else if (col.Name == "colCount")
                {
                    int count;
                    if (int.TryParse(row.Cells[e.ColumnIndex].Value.ToString(), out count))
                    {
                        if (count < 0) count = 0;
                        item.Count = count;
                        row.Cells[e.ColumnIndex].Value = count;
                    }
                }
                else if (col.Name == "colMemo")
                {
                    if (row.Cells[e.ColumnIndex].Value != null)
                    {
                        item.Memo = row.Cells[e.ColumnIndex].Value.ToString();
                    }
                    else
                    {
                        item.Memo = null;
                    }
                }
                row.Cells["colTotal"].Value = item.Amount.Trim(); ;
                ItemsGrid.Rows[ItemsGrid.Rows.Count - 1].Cells["colTotal"].Value = GetTotalAmount();
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            FrmProductMaster frm = new FrmProductMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Product p = frm.SelectedItem as Product;
                AddOrdertem(p);
            }
        }

        private void mnu_Remove_Click(object sender, EventArgs e)
        {
            if (ItemsGrid.SelectedRows.Count > 0)
            {
                List<OrderItem> items = GetOrderItemsFromGrid();
                foreach (DataGridViewRow row in ItemsGrid.SelectedRows)
                {
                    if (row.Tag != null) items.Remove(row.Tag as OrderItem);
                }
                ShowDeliveryItemsOnGrid(items);
            }
        }

        private void lnkCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmCustomerMaster frm = new FrmCustomerMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Customer = frm.SelectedItem as CompanyInfo;
                txtCustomer.Text = Customer != null ? Customer.Name : string.Empty;
            }
        }

        private void lnkSalesPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmOperatorMaster frm = new FrmOperatorMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Operator item = frm.SelectedItem as Operator;
                txtSalesPerson.Text = item.Name;
            }
        }

        private void ItemsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (ItemsGrid.Columns[e.ColumnIndex].Name == "colShipped")
                {
                    OrderItem pi = ItemsGrid.Rows[e.RowIndex].Tag as OrderItem;
                    DeliveryRecordSearchCondition con = new DeliveryRecordSearchCondition();
                    con.States = new List<SheetState>();
                    con.States.Add(SheetState.Shipped);
                    con.OrderItem = pi.ID;
                    FrmDeliveryRecordView frm = new FrmDeliveryRecordView();
                    frm.SearchCondition = con;
                    frm.ShowDialog();
                }
            }
        }
        #endregion
    }
}
