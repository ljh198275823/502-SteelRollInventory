﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.DAL.IProvider;
using LJH.GeneralLibrary.DAL;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class PurchaseItemRecordProvider : ProviderBase<PurchaseItemRecord, Guid>, IPurchaseItemRecordProvider
    {
        #region 构造函数
        public PurchaseItemRecordProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr,ms)
        {
        }
        #endregion

        #region 重写基类方法
        protected override PurchaseItemRecord GetingItemByID(Guid id, System.Data.Linq.DataContext dc)
        {
            DataLoadOptions opt = new DataLoadOptions();
            opt.LoadWith<PurchaseItemRecord>(item => item.Supplier);
            opt.LoadWith<PurchaseItemRecord>(item => item.Product);
            opt.LoadWith<Product>(item => item.Category);
            dc.LoadOptions = opt;
            return dc.GetTable<PurchaseItemRecord>().SingleOrDefault(item => item.ID == id);
        }

        protected override List<PurchaseItemRecord> GetingItems(System.Data.Linq.DataContext dc, SearchCondition search)
        {
            DataLoadOptions opt = new DataLoadOptions();
            opt.LoadWith<PurchaseItemRecord>(item => item.Supplier);
            opt.LoadWith<PurchaseItemRecord>(item => item.Product);
            dc.LoadOptions = opt;
            IQueryable<PurchaseItemRecord> ret = dc.GetTable<PurchaseItemRecord>();
            if (search is PurchaseItemRecordSearchCondition)
            {
                PurchaseItemRecordSearchCondition con = search as PurchaseItemRecordSearchCondition;
                if (con.OrderDate != null) ret = ret.Where(item => item.OrderDate >= con.OrderDate.Begin && item.OrderDate <= con.OrderDate.End);
                if (!string.IsNullOrEmpty(con.ProductID)) ret = ret.Where(item => item.ProductID == con.ProductID);
                if (!string.IsNullOrEmpty(con.SupplierID)) ret = ret.Where(item => item.SupplierID == con.SupplierID);
                if (!string.IsNullOrEmpty(con.OrderID)) ret = ret.Where(item => item.OrderID == con.OrderID);
                if (con.States != null && con.States.Count > 0) ret = ret.Where(item => con.States.Contains(item.State));
                if (con.HasOnway != null)
                {
                    if (con.HasOnway.Value)
                    {
                        ret = ret.Where(item => !item.IsComplete && item.Count - item.Received > 0);
                    }
                    else
                    {
                        ret = ret.Where(item => item.IsComplete || item.Count - item.Received == 0);
                    }
                }
            }
            List<PurchaseItemRecord> items = ret.ToList();
            return items;
        }
        #endregion
    }
}