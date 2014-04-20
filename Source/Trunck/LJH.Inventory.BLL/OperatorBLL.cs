﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;
using LJH.GeneralLibrary.DAL;

namespace LJH.Inventory.BLL
{
    public class OperatorBLL : BLLBase<string, Operator>
    {
        #region 构造函数
        public OperatorBLL(string repUri):base(repUri )
        {
            
        }
        #endregion

        #region 实例方法
        /// <summary>
        /// 登录验证
        /// </summary>
        public bool Authentication(string logName, string pwd)
        {
            Operator info = GetByID(logName).QueryObject;
            if (info != null)
            {
                if (info.ID == logName && info.Password == pwd)
                {
                    Operator.Current = info;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 增加操作员,如果操作员编号已被使用,抛出InvalidOperationException
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public override CommandResult Add(Operator info)
        {
            Role role = info.Role;
            info.Role = null;
            CommandResult ret = base.Add(info);
            info.Role = role;
            return ret;
        }
        #endregion
    }
}
