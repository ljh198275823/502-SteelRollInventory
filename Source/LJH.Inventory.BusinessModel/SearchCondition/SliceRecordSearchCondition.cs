﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class SliceRecordSearchCondition : LJH.GeneralLibrary.Core.DAL.SearchCondition
    {
        /// <summary>
        /// 获取或设置要查询加工记录的铁皮卷ID
        /// </summary>
        public Guid? SourceRoll { get; set; }
        /// <summary>
        /// 获取或设置要查询加工记录的加工日期范围
        /// </summary>
        public DateTimeRange SliceDate { get; set; }
    }
}