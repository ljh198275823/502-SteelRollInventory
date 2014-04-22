﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using LJH.Inventory.BusinessModel;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class DepartmentProvider : ProviderBase<Department, string>
    {
        #region 构造函数
        public DepartmentProvider(string connStr, MappingSource ms)
            : base(connStr, ms)
        {
        }
        #endregion
    }
}
