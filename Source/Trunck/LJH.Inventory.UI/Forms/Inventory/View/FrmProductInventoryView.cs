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
using LJH.Inventory.BLL;
using LJH.GeneralLibrary.Core.UI;

namespace LJH.Inventory.UI.Forms.Inventory
{
    public partial class FrmProductInventoryView : FrmMasterBase
    {
        public FrmProductInventoryView()
        {
            InitializeComponent();
        }

        List<Product> _Products = null;

        #region 重写基类方法
        protected override List<object> GetDataSource()
        {
            _Products = new ProductBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;
            List<ProductInventoryItem> records = null;
            if (SearchCondition == null)
            {
                records = (new ProductInventoryItemBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            }
            else
            {
                records = (new ProductInventoryItemBLL(AppSettings.Current.ConnStr)).GetItems(SearchCondition).QueryObjects;
            }
            return (from item in records
                    orderby item.AddDate ascending
                    select (object)item).ToList();
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            ProductInventoryItem c = item as ProductInventoryItem;
            row.Tag = c;
            row.Cells["colInventorySheet"].Value = c.InventorySheet;
            row.Cells["colProductID"].Value = c.ProductID;
            Product p = _Products.SingleOrDefault(it => it.ID == c.ProductID);
            row.Cells["colProductName"].Value = p != null ? p.Name : string.Empty;
            row.Cells["colSpecification"].Value = p != null ? p.Specification : string.Empty;
            row.Cells["colInventoryDate"].Value = c.AddDate.ToString("yyyy-MM-dd");
            row.Cells["colCount"].Value = c.Count.Trim();
            row.Cells["colReserved"].Value = c.OrderItem != null;
        }
        #endregion
    }
}
