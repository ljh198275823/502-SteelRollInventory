﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BLL;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.UI.Report;

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmRelatedCompanyMaster : FrmMasterBase
    {
        public FrmRelatedCompanyMaster()
        {
            InitializeComponent();
        }

        #region 私有变量
        private List<Customer> _Customers = null;
        #endregion

        #region 私有方法
        private void InitCategoryTree()
        {
            this.categoryTree.Nodes.Clear();
            this.categoryTree.Nodes.Add("所有供应商类别");

            List<RelatedCompanyType> items = (new RelatedCompanyTypeBLL(AppSettings.CurrentSetting.ConnectString)).GetAll().QueryObjects;
            if (items != null && items.Count > 0)
            {
                AddDesendNodes(items, this.categoryTree.Nodes[0]);
            }
        }

        private void AddDesendNodes(List<RelatedCompanyType> items, TreeNode parent)
        {
            List<RelatedCompanyType> pcs = null;
            if (parent.Tag == null)
            {
                pcs = items.Where(it => string.IsNullOrEmpty(it.Parent)).ToList();
            }
            else
            {
                pcs = items.Where(it => it.Parent == (parent.Tag as RelatedCompanyType).ID).ToList();
            }
            if (pcs != null && pcs.Count > 0)
            {
                foreach (RelatedCompanyType pc in pcs)
                {
                    TreeNode node = AddNode(pc, parent);
                    AddDesendNodes(items, node);
                }
            }
            parent.ImageIndex = 0;
            parent.SelectedImageIndex = 0;
            parent.ExpandAll();
        }

        private void SelectNode(TreeNode node)
        {
            if (!object.ReferenceEquals(categoryTree.SelectedNode, node))
            {
                if (categoryTree.SelectedNode != null)
                {
                    categoryTree.SelectedNode.BackColor = Color.White;
                    categoryTree.SelectedNode.ForeColor = Color.Black;
                }
                categoryTree.SelectedNode = node;
                categoryTree.SelectedNode.BackColor = Color.Blue;  //Color.FromArgb(128, 128, 255);
                categoryTree.SelectedNode.ForeColor = Color.White;

                List<object> items = GetSelectedNodeItems();
                ShowItemsOnGrid(items);
            }
        }

        private List<object> GetSelectedNodeItems()
        {
            List<Customer> items = _Customers;
            RelatedCompanyType pc = null;
            if (this.categoryTree.SelectedNode != null) pc = this.categoryTree.SelectedNode.Tag as RelatedCompanyType;
            if (pc != null) items = _Customers.Where(it => it.CategoryID == pc.ID).ToList();

            return (from p in items
                    orderby p.Name ascending
                    select (object)p).ToList();
        }

        private TreeNode AddNode(RelatedCompanyType pc, TreeNode parent)
        {
            TreeNode node = parent.Nodes.Add(string.Format("{0}", pc.Name));
            node.Tag = pc;
            return node;
        }
        #endregion

        #region 重写基类方法
        protected override void Init()
        {
            base.Init();
            InitCategoryTree();
            OperatorInfo opt = OperatorInfo.CurrentOperator;
            menu.Items["btn_Add"].Enabled = opt.Permit(Permission.EditCustomer);
            menu.Items["btn_Delete"].Enabled = opt.Permit(Permission.EditCustomer);
        }

        protected override FrmDetailBase GetDetailForm()
        {
            FrmRelatedCompanyDetail frm = new FrmRelatedCompanyDetail();
            frm.Category = categoryTree.SelectedNode != null ? (categoryTree.SelectedNode.Tag as RelatedCompanyType) : null;
            return frm;
        }

        protected override bool DeletingItem(object item)
        {
            Customer c = item as Customer;
            CustomerBLL bll = new CustomerBLL(AppSettings.CurrentSetting.ConnectString);
            CommandResult ret = bll.Delete(c);
            if (ret.Result != ResultCode.Successful)
            {
                MessageBox.Show(ret.Message);
            }
            else
            {
                _Customers.Remove(c);
            }
            return ret.Result == ResultCode.Successful;
        }

        protected override List<object> GetDataSource()
        {
            CustomerBLL bll = new CustomerBLL(AppSettings.CurrentSetting.ConnectString);
            if (SearchCondition == null)
            {
                CustomerSearchCondition con = new CustomerSearchCondition();
                con.ClassID = CustomerClass.Other;
                SearchCondition = con;
            }
            _Customers = bll.GetItems(SearchCondition).QueryObjects;
            List<object> records = GetSelectedNodeItems();
            return records;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            Customer c = item as Customer;
            row.Tag = c;
            row.Cells["colImage"].Value = Properties.Resources.customer;
            row.Cells["colID"].Value = c.ID;
            row.Cells["colNation"].Value = c.Nation;
            row.Cells["colName"].Value = c.Name;
            row.Cells["colWebsite"].Value = c.Website;
            row.Cells["colTelphone"].Value = c.TelPhone;
            row.Cells["colFax"].Value = c.Fax;
            row.Cells["colAddress"].Value = c.Address;
            row.Cells["colPostalCode"].Value = c.PostalCode;
            row.Cells["colMemo"].Value = c.Memo;
            if (_Customers == null || !_Customers.Exists(it => it.ID == c.ID))
            {
                if (_Customers == null) _Customers = new List<Customer>();
                _Customers.Add(c);
            }
        }
        #endregion

        #region 事件处理程序
        private void mnu_Payment_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                Customer c = dataGridView1.SelectedRows[0].Tag as Customer;
                FrmCustomerPaymentDetail frm = new FrmCustomerPaymentDetail();
                frm.Customer = c;
                frm.IsAdding = true;
                frm.ItemAdded += delegate(object obj, ItemAddedEventArgs args)
                {
                    Customer c1 = (new CustomerBLL(AppSettings.CurrentSetting.ConnectString)).GetByID(c.ID).QueryObject;
                    if (c1 != null)
                    {
                        ShowItemInGridViewRow(dataGridView1.SelectedRows[0], c1);
                    }
                };
                frm.ShowDialog();
            }
        }
        #endregion

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "colPrepay")
                {
                    Customer c = dataGridView1.Rows[e.RowIndex].Tag as Customer;
                    FrmCustomerPaymentRemains frm = new FrmCustomerPaymentRemains();
                    frm.Customer = c;
                    frm.ShowDialog();
                }
            }
        }

        #region 类别树右键菜单
        private void categoryTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SelectNode(e.Node);
        }

        private void mnu_FreshTree_Click(object sender, EventArgs e)
        {
            InitCategoryTree();
            SelectNode(categoryTree.Nodes[0]);
        }

        private void mnu_AddCategory_Click(object sender, EventArgs e)
        {
            RelatedCompanyType pc = categoryTree.SelectedNode.Tag as RelatedCompanyType;
            FrmRelatedCompanyTypeDetail frm = new FrmRelatedCompanyTypeDetail();
            frm.IsAdding = true;
            frm.ParentCategory = pc;
            frm.ItemAdded += delegate(object obj, ItemAddedEventArgs args)
            {
                RelatedCompanyType item = args.AddedItem as RelatedCompanyType;
                AddNode(item, categoryTree.SelectedNode);
            };
            frm.ShowDialog();
        }

        private void mnu_DeleteCategory_Click(object sender, EventArgs e)
        {
            RelatedCompanyType pc = categoryTree.SelectedNode.Tag as RelatedCompanyType;
            if (pc != null && MessageBox.Show("是否删除此类别及其子项?", "询问", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                CommandResult ret = (new RelatedCompanyTypeBLL(AppSettings.CurrentSetting.ConnectString)).Delete(pc);
                if (ret.Result == ResultCode.Successful)
                {
                    categoryTree.SelectedNode.Parent.Nodes.Remove(categoryTree.SelectedNode);
                }
                else
                {
                    MessageBox.Show(ret.Message);
                }
            }
        }

        private void mnu_CategoryProperty_Click(object sender, EventArgs e)
        {
            RelatedCompanyType pc = categoryTree.SelectedNode.Tag as RelatedCompanyType;
            FrmRelatedCompanyTypeDetail frm = new FrmRelatedCompanyTypeDetail();
            frm.IsAdding = false;
            frm.UpdatingItem = pc;
            frm.ItemUpdated += delegate(object obj, ItemUpdatedEventArgs args)
            {
                categoryTree.SelectedNode.Text = string.Format("{0}", pc.Name);
            };
            frm.ShowDialog();
        }
        #endregion
    }
}
