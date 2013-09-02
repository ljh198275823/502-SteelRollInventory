﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;

namespace LJH.Inventory.BLL
{
    public class OperatorBLL
    {
        #region 构造函数
        public OperatorBLL(string repUri)
        {
            provider = ProviderFactory.Create<IOperatorProvider>(repUri);
        }
        #endregion
        #region 私有变量
        private IOperatorProvider provider;
        #endregion

        #region 实例方法

        /// <summary>
        /// 登录验证
        /// </summary>
        public bool Authentication(string logName, string pwd)
        {
            OperatorInfo info = GetByID(logName).QueryObject;
            if (info != null)
            {
                if (info.OperatorID == logName && info.Password == pwd)
                {
                    OperatorInfo.CurrentOperator = info;
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
        /// 根据操作员ID获取操作员
        /// </summary>
        /// <param name="optID"></param>
        /// <returns></returns>
        public QueryResult<OperatorInfo> GetByID(string optID)
        {
            return provider.GetByID(optID);
        }

        /// <summary>
        /// 获取所有操作员
        /// </summary>
        /// <returns></returns>
        public QueryResultList<OperatorInfo> GetAllOperators()
        {
            return provider.GetItems(null);
        }

        /// <summary>
        /// 增加操作员,如果操作员编号已被使用,抛出InvalidOperationException
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public CommandResult Insert(OperatorInfo info)
        {
            RoleInfo role = info.Role;
            info.Role = null;
            CommandResult ret = provider.Insert(info);
            info.Role = role;
            return ret;
        }
        /// <summary>
        /// 修改操作员,如果操作员编号已被使用,抛出InvalidOperationException
        /// </summary>
        /// <param name="newVal"></param>
        /// <returns></returns>
        public CommandResult Update(OperatorInfo newVal)
        {
            OperatorInfo original = GetByID(newVal.OperatorID).QueryObject;
            if (original != null)
            {
                return provider.Update(newVal, original);
            }
            else
            {
                throw new InvalidOperationException(string.Format("数据库中不存在操作员\"{0}\",可能被其它人员删除!", newVal.OperatorID));
            }
        }
        /// <summary>
        /// 删除操作员
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        /// <exception cref=" "></exception>
        public CommandResult Delete(OperatorInfo info)
        {
            if (!info.CanDelete)
            {
                throw new InvalidOperationException(string.Format("操作员\"{0}\"是系统默认的操作员,不能被删除!", info.OperatorID));
            }
            return provider.Delete(info);
        }
        #endregion
    }
}