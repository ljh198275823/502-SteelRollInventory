﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.BLL
{
    public class YouhuiQuanBLL : BLLBase<string, YouhuiQuan>
    {
        #region 构造函数
        public YouhuiQuanBLL(string repoUri)
            : base(repoUri)
        {
        }
        #endregion
    }
}
