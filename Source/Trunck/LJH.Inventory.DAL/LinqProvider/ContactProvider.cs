﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class ContactProvider : ProviderBase<Contact, int>, IContactProvider
    {
        #region 构造函数
        public ContactProvider(string conStr)
            : base(conStr)
        {
        }
        #endregion

        #region 重写基类方法
        protected override Contact GetingItemByID(int id, System.Data.Linq.DataContext dc)
        {
            Contact c = dc.GetTable<Contact>().SingleOrDefault(item => item.ID == id);
            return c;
        }

        protected override List<Contact> GetingItems(System.Data.Linq.DataContext dc, BusinessModel.SearchCondition.SearchCondition search)
        {
            IQueryable<Contact> ret = dc.GetTable<Contact>();
            if (search is ContactSearchCondition)
            {
                ContactSearchCondition con = search as ContactSearchCondition;
                if (!string.IsNullOrEmpty(con.CompanyID)) ret = ret.Where(item => item.Company == con.CompanyID);
            }
            List<Contact> cs = ret.ToList();
            return cs;
        }
        #endregion
    }
}