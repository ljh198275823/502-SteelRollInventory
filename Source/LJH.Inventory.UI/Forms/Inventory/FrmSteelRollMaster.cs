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
using LJH.Inventory.UI.Report;
using LJH.Inventory.UI.Forms.Inventory.View;
using LJH.GeneralLibrary;
using LJH.GeneralLibrary.Core.UI;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.UI.Forms.Inventory
{
    public partial class FrmSteelRollMaster : FrmMasterBase
    {
        public FrmSteelRollMaster()
        {
            InitializeComponent();
        }

        #region 私有变量
        private List<ProductInventoryItem> _SteelRolls = null;
        #endregion

        #region 私有方法
        private void InitSupplier(ComboBox cmb)
        {
            cmb.Items.Clear();
            List<CompanyInfo> cs = new CompanyBLL(AppSettings.Current.ConnStr).GetAllSuppliers().QueryObjects;
            if (cs != null && cs.Count > 0)
            {
                cmb.Items.Add(string.Empty);
                var items = (from p in cs
                             orderby p.Name ascending
                             select p.Name);
                foreach (var item in items)
                {
                    cmb.Items.Add(item);
                }
            }
        }

        private void FreshData()
        {
            List<object> items = FilterData();
            ShowItemsOnGrid(items);
        }

        private List<object> FilterData()
        {
            if (_SteelRolls == null) return null;
            List<ProductInventoryItem> items = _SteelRolls.ToList();
            if (items != null && items.Count > 0)
            {
                if (chkStackIn.Checked) items = items.Where(it => it.AddDate >= ucDateTimeInterval1.StartDateTime && it.AddDate <= ucDateTimeInterval1.EndDateTime).ToList();
                if (!string.IsNullOrEmpty(categoryComboBox1.Text)) items = items.Where(it => it.Product.CategoryID == categoryComboBox1.SelectedCategoryID).ToList();
                if (!string.IsNullOrEmpty(wareHouseComboBox1.Text)) items = items.Where(it => it.WareHouseID == wareHouseComboBox1.SelectedWareHouseID).ToList();
                if (!string.IsNullOrEmpty(cmbSpecification.Text)) items = items.Where(it => it.Product.Specification.Contains(cmbSpecification.Text)).ToList();
                if (!string.IsNullOrEmpty(cmbSupplier.Text)) items = items.Where(it => it.Supplier == cmbSupplier.Text).ToList();
                if (!string.IsNullOrEmpty(cmbBrand.Text)) items = items.Where(it => it.Manufacture == cmbBrand.Text).ToList();
                if (!string.IsNullOrEmpty(customerCombobox1.Text)) items = items.Where(it => it.Customer == customerCombobox1.Text).ToList();
                if (!string.IsNullOrEmpty(txtCarPlate.Text.Trim())) items = items.Where(it => !string.IsNullOrEmpty(it.Carplate) && it.Carplate.Contains(txtCarPlate.Text.Trim())).ToList();
                items = items.Where(it => (chk作废.Checked && it.State == ProductInventoryState.Nullified) ||
                                          (chk发货.Checked && it.State == ProductInventoryState.Shipped) ||
                                          (chk待发货.Checked && it.State == ProductInventoryState.WaitShipping) ||
                                          (chk在库.Checked && it.State == ProductInventoryState.Inventory)).ToList();
            }
            if (items != null && items.Count > 0)
            {
                return (from p in items
                        orderby p.Product.CategoryID ascending,
                                SpecificationHelper.GetWrittenWidth(p.Product.Specification) ascending,
                                SpecificationHelper.GetWrittenThick(p.Product.Specification) ascending,
                                p.AddDate descending
                        select (object)p).ToList();
            }
            return null;
        }

        private void ShowRowColor(DataGridViewRow row)
        {
            ProductInventoryItem sr = row.Tag as ProductInventoryItem;
            if (sr.State == ProductInventoryState.Nullified)
            {
                row.DefaultCellStyle.ForeColor = Color.Red;
            }
            else
            {
                row.DefaultCellStyle.ForeColor = Color.Blue;
            }
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
            this.ucDateTimeInterval1.Init();
            this.ucDateTimeInterval1.SelectToday();
            InitSupplier(cmbBrand);
            InitSupplier(cmbSupplier);
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            cMnu_Add.Enabled = Operator.Current.Permit(Permission.SteelRoll, PermissionActions.Edit);
            mnu_Check.Enabled = Operator.Current.Permit(Permission.SteelRoll, PermissionActions.Check);
            mnu_Nullify.Enabled = Operator.Current.Permit(Permission.SteelRoll, PermissionActions.Nullify);
        }

        protected override FrmDetailBase GetDetailForm()
        {
            FrmSteelRollDetail frm = new FrmSteelRollDetail();
            return frm;
        }

        protected override bool DeletingItem(object item)
        {
            return false;
        }

        protected override List<object> GetDataSource()
        {
            var bll = new SteelRollBLL(AppSettings.Current.ConnStr);
            if (SearchCondition == null)
            {
                _SteelRolls = bll.GetItems(null).QueryObjects;
            }
            else
            {
                _SteelRolls = bll.GetItems(SearchCondition).QueryObjects;
            }
            List<object> records = FilterData();
            return records;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            ProductInventoryItem sr = item as ProductInventoryItem;
            row.Tag = sr;
            row.Cells["colAddDate"].Value = sr.AddDate.ToString("yyyy-MM-dd");
            row.Cells["colCategory"].Value = sr.Product.Category == null ? sr.Product.CategoryID : sr.Product.Category.Name;
            row.Cells["colSpecification"].Value = sr.Product.Specification;
            row.Cells["colWareHouse"].Value = sr.WareHouse.Name;
            row.Cells["colOriginalWeight"].Value = sr.OriginalWeight;
            row.Cells["colOriginalLength"].Value = sr.OriginalLength;
            row.Cells["colWeight"].Value = sr.Weight;
            row.Cells["colLength"].Value = sr.Length;
            row.Cells["colCustomer"].Value = sr.Customer;
            row.Cells["colSupplier"].Value = sr.Supplier;
            row.Cells["colManufacture"].Value = sr.Manufacture;
            row.Cells["colState"].Value = ProductInventoryStateDescription.GetDescription(sr.State);
            row.Cells["colSerialNumber"].Value = sr.SerialNumber;
            row.Cells["colCarplate"].Value = sr.Carplate;
            row.Cells["colMaterial"].Value = sr.Material;
            row.Cells["colPurchasePrice"].Value = sr.PurchasePrice;
            row.Cells["colTransCost"].Value = sr.TransCost;
            row.Cells["colOtherCost"].Value = sr.OtherCost;
            row.Cells["colDeliverySheet"].Value = sr.DeliverySheet;
            row.Cells["colMemo"].Value = sr.Memo;
            ShowRowColor(row);
            if (sr.State==ProductInventoryState .Nullified)
            {
                row.DefaultCellStyle.ForeColor = Color.Red;
                row.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            }
            if (!_SteelRolls.Exists(it => it.ID == sr.ID))
            {
                _SteelRolls.Add(sr);
            }
        }

        protected override void FreshStatusBar()
        {
            base.FreshStatusBar();
            if (dataGridView1.Rows.Count > 0)
            {
                decimal total = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    var pi = row.Tag as ProductInventoryItem;
                    if (pi.State != ProductInventoryState.Nullified) total += pi.Weight.Value;
                }
                lblTotalWeight.Text = string.Format("合计 {0:F3}吨", total);
            }
            else
            {
                lblTotalWeight.Text = string.Empty;
            }
        }
        #endregion

        #region 事件处理函数
        private void FreshData_Clicked(object sender, EventArgs e)
        {
            FreshData();
        }

        private void ucDateTimeInterval1_ValueChanged(object sender, EventArgs e)
        {
            if (chkStackIn.Checked) FreshData_Clicked(sender, e);
        }

        private void mnu_SliceView_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count == 1)
            {
                ProductInventoryItem sr = dataGridView1.SelectedRows[0].Tag as ProductInventoryItem;
                SliceRecordSearchCondition con = new SliceRecordSearchCondition();
                con.SourceRoll = sr.ID;
                FrmSliceRecordView frm = new FrmSliceRecordView();
                frm.SearchCondition = con;
                frm.ShowDialog();
            }
        }

        private void mnu_Check_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                ProductInventoryItem sr = dataGridView1.SelectedRows[0].Tag as ProductInventoryItem;
                if (sr.State == ProductInventoryState.Inventory)
                {
                    FrmSteelRollCheck frm = new FrmSteelRollCheck();
                    frm.SteelRoll = sr;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        ShowItemInGridViewRow(dataGridView1.SelectedRows[0], sr);
                    }
                }
                else
                {
                    MessageBox.Show(string.Format("原材料处于 \"{0}\" 状态,不能进行盘点", ProductInventoryStateDescription.GetDescription(sr.State)));
                }
            }
        }

        private void mnu_CheckView_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                ProductInventoryItem sr = dataGridView1.SelectedRows[0].Tag as ProductInventoryItem;
                View.FrmSteelRollCheckRecordView frm = new FrmSteelRollCheckRecordView();
                frm.SearchCondition = new InventoryCheckRecordSearchCondition() { SourceID = sr.ID };
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
        }

        private void mnu_Nullify_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要作废所选的原材料?", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    ProductInventoryItem item = row.Tag as ProductInventoryItem;
                    if (item.State == ProductInventoryState.Inventory)
                    {
                        CommandResult ret = (new SteelRollBLL(AppSettings.Current.ConnStr)).Nullify(item);
                        if (ret.Result == ResultCode.Successful)
                        {
                            ShowItemInGridViewRow(row, item);
                        }
                        else
                        {
                            MessageBox.Show(ret.Message);
                        }
                    }
                }
            }
        }
        #endregion

        private void mnu_Import_Click(object sender, EventArgs e)
        {
            FrmSteelRollImport frm = new FrmSteelRollImport();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            cMnu_Fresh.PerformClick();
        }
    }
}