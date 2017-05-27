﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory .BusinessModel ;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory .DAL .IProvider ;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.BLL
{
    public class CustomerReceivableBLL : BLLBase<Guid, CustomerReceivable>
    {
        #region 构造函数
        public CustomerReceivableBLL(string repoUri)
            : base(repoUri)
        {
        }
        #endregion

        #region 重写基类方法
        public override CommandResult Delete(CustomerReceivable info)
        {
            AccountRecordAssignSearchCondition con = new AccountRecordAssignSearchCondition() { ReceivableID = info.ID };
            List<AccountRecordAssign> assigns = new AccountRecordAssignBLL(RepoUri).GetItems(con).QueryObjects;
            if (assigns != null && assigns.Count > 0)
            {
                bool allSuccess = true;
                foreach (AccountRecordAssign assign in assigns)
                {
                    CommandResult ret = (new AccountRecordAssignBLL(RepoUri)).UndoAssign(assign);
                    if (ret.Result != ResultCode.Successful) allSuccess = false;
                }
                if (!allSuccess) return new CommandResult(ResultCode.Fail, "某些核销项删除失败");
            }
            return base.Delete(info);
        }
        #endregion
    }
}
