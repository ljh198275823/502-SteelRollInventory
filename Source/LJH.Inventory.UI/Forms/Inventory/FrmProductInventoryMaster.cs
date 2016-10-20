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
using LJH.Inventory.BusinessModel.Resource;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.UI.Forms.Inventory.View;
using LJH.GeneralLibrary;
using LJH.GeneralLibrary.Core.UI;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.UI.Forms.Inventory
{
    public partial class FrmProductInventoryMaster : FrmMasterBase
    {
        public FrmProductInventoryMaster()
        {
            InitializeComponent();
        }

        #region 私有变量
        private List<ProductInventoryItem> _ProductInventorys = null;
        private List<ProductInventoryItem> srs = null; //表示加工源
        #endregion

        #region 私有方法
        private void FreshData()
        {
            List<object> items = FilterData();
            ShowItemsOnGrid(items);
        }

        private List<object> FilterData()
        {
            List<ProductInventoryItem> items = _ProductInventorys;
            if (items != null && items.Count > 0)
            {
                if (!string.IsNullOrEmpty(wareHouseComboBox1.Text)) items = items.Where(it => it.WareHouse.Name == wareHouseComboBox1.Text).ToList();
                if (!string.IsNullOrEmpty(categoryComboBox1.Text)) items = items.Where(it => it.Product.CategoryID == categoryComboBox1.SelectedCategoryID).ToList();
                if (!string.IsNullOrEmpty(cmbSpecification.Text)) items = items.Where(it => it.Product.Specification.Contains(cmbSpecification.Text)).ToList();
                if (!string.IsNullOrEmpty(customerCombobox1.Text)) items = items.Where(it => !string.IsNullOrEmpty(it.Customer) && it.Customer.Contains(customerCombobox1.Text)).ToList();
                if (txtWeight.DecimalValue > 0) items = items.Where(it => it.Product.Weight == txtWeight.DecimalValue).ToList();
                if (txtLength.DecimalValue > 0) items = items.Where(it => it.Product.Length == txtLength.DecimalValue).ToList();
                items = items.Where(it => (chk开平.Checked && it.Product.Model == chk开平.Text) ||
                                          (chk开卷.Checked && it.Product.Model == chk开卷.Text) ||
                                          (chk开条.Checked && it.Product.Model == chk开条.Text) ||
                                          (chk开吨.Checked && it.Product.Model == chk开吨.Text)).ToList();
                return (from p in items
                        orderby p.Product.CategoryID ascending,
                                SpecificationHelper.GetWrittenWidth(p.Product.Specification) ascending,
                                SpecificationHelper.GetWrittenThick(p.Product.Specification) ascending,
                                p.WareHouse.Name descending
                        select (object)p).ToList();
            }
            return null;
        }
        #endregion

        #region 重写基类方法
        protected override void Init()
        {
            base.Init();
            this.wareHouseComboBox1.Init();
            this.cmbSpecification.Init();
            this.categoryComboBox1.Init();
            this.customerCombobox1.Init();
        }

        protected override List<object> GetDataSource()
        {
            var f = new ProductInventoryItemSearchCondition();
            f.Sliced = true;
            srs = new SteelRollBLL(AppSettings.Current.ConnStr).GetItems(f).QueryObjects;

            if (SearchCondition == null)
            {
                _ProductInventorys = new SteelRollSliceBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;
            }
            else
            {
                _ProductInventorys = new SteelRollSliceBLL(AppSettings.Current.ConnStr).GetItems(SearchCondition).QueryObjects;
            }
            List<object> records = FilterData();
            return records;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            ProductInventoryItem pi = item as ProductInventoryItem;
            row.Tag = pi;
            row.Cells["colCategory"].Value = pi.Product.Category == null ? pi.Product.CategoryID : pi.Product.Category.Name;
            row.Cells["colSpecification"].Value = pi.Product.Specification;
            row.Cells["colModel"].Value = pi.Product.Model;
            row.Cells["colWareHouse"].Value = pi.WareHouse.Name;
            row.Cells["colWeight"].Value = pi.Product.Weight;
            row.Cells["colLength"].Value = pi.Product.Length;
            row.Cells["colCount"].Value = pi.Count;
            row.Cells["colOriginalThick"].Value = pi.OriginalThick;
            row.Cells["colRealThick"].Value = pi.RealThick;
            row.Cells["colSourceRoll"].Value = pi.SourceRoll.HasValue ? "查看来源卷" : null;
            if (srs != null && srs.Count > 0)
            {
                var source = srs.SingleOrDefault(it => it.ID == pi.SourceRoll);
                row.Cells["colSourceRollWeight"].Value = source != null ? source.OriginalWeight : null;
            }
            row.Cells["colCustomer"].Value = pi.Customer;
            row.Cells["colMemo"].Value = pi.Memo;
        }
        #endregion

        #region 事件处理程序
        private void FreshDate_Clicked(object sender, EventArgs e)
        {
            FreshData();
        }

        private void dataGridview1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            if (dataGridView1.Columns[e.ColumnIndex].Name == "colSourceRoll")
            {
                var pi = dataGridView1.Rows[e.RowIndex].Tag as ProductInventoryItem;
                if (pi != null && pi.SourceRoll != null)
                {
                    var steelRoll = new SteelRollBLL(AppSettings.Current.ConnStr).GetByID(pi.SourceRoll.Value).QueryObject;
                    if (steelRoll != null)
                    {
                        FrmSteelRollDetail frm = new FrmSteelRollDetail();
                        frm.IsForView = true;
                        frm.UpdatingItem = steelRoll;
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.ShowDialog();
                    }
                }
            }
        }
        #endregion
    }
}