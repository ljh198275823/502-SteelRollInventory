﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.BillProject.Model;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.BillProject.DAL
{
    public class PaymentProvider : ProviderBase<PaymentLog, Guid>
    {
        public PaymentProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr, ms)
        {
        }

        #region 重写基类方法
        protected override PaymentLog GetingItemByID(Guid id, System.Data.Linq.DataContext dc)
        {
            return dc.GetTable<PaymentLog>().SingleOrDefault(item => item.ID == id);
        }

        protected override List<PaymentLog> GetingItems(System.Data.Linq.DataContext dc, SearchCondition search)
        {
            IQueryable<PaymentLog> ret = dc.GetTable<PaymentLog>();
            if (search is PaymentLogSearchCondition)
            {
                PaymentLogSearchCondition con = search as PaymentLogSearchCondition;
                if (con.LogFrom != null) ret = ret.Where(item => item.PaymentDate >= con.LogFrom.Value);
                if (!string.IsNullOrEmpty(con.User)) ret = ret.Where(item => item.User == con.User);
            }
            return ret.ToList();
        }
        #endregion
    }
}
