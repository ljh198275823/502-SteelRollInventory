﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class SteelRollSliceRecordProvider : ProviderBase<SteelRollSliceRecord, Guid>
    {
        #region 构造函数
        public SteelRollSliceRecordProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr, ms)
        {
        }
        #endregion

        #region 重写基类方法
        protected override SteelRollSliceRecord GetingItemByID(Guid id, System.Data.Linq.DataContext dc)
        {
            return dc.GetTable<SteelRollSliceRecord>().SingleOrDefault(item => item.ID == id);
        }

        protected override List<SteelRollSliceRecord> GetingItems(System.Data.Linq.DataContext dc, SearchCondition search)
        {
            IQueryable<SteelRollSliceRecord> ret = dc.GetTable<SteelRollSliceRecord>();
            if (search is SliceRecordSearchCondition)
            {
                SliceRecordSearchCondition con = search as SliceRecordSearchCondition;
                if (con.SourceRoll != null) ret = ret.Where(item => item.SliceSource == con.SourceRoll.Value);
                if (con.SliceDate != null) ret = ret.Where(item => item.SliceDate >= con.SliceDate.Begin && item.SliceDate <= con.SliceDate.End);
            }
            return ret.ToList();
        }
        #endregion
    }
}