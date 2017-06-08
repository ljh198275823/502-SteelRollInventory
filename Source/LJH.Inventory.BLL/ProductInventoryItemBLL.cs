﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.DAL.IProvider;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.BLL
{
    public class ProductInventoryItemBLL : BLLBase<Guid, ProductInventoryItem>
    {
        #region 构造函数
        public ProductInventoryItemBLL(string repoUri)
            : base(repoUri)
        {
        }
        #endregion

        #region 公共方法
        public CommandResult UpdateMemo(ProductInventoryItem pi, string memo)
        {
            var clone = pi.Clone();
            clone.Memo = memo;
            var ret = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(clone, pi);
            if (ret.Result == ResultCode.Successful) pi.Memo = memo;
            return ret;
        }

        public CommandResult UpdateWareHouse(ProductInventoryItem pi, WareHouse ws)
        {
            var clone = pi.Clone();
            clone.WareHouseID = ws.ID;
            var ret = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(clone, pi);
            if (ret.Result == ResultCode.Successful)
            {
                pi.WareHouseID = clone.WareHouseID;
            }
            return ret;
        }

        public CommandResult Reserve(ProductInventoryItem pi, string customer)
        {
            if (pi.State != ProductInventoryState.Inventory) return new CommandResult(ResultCode.Fail, "不能预订");
            var clone = pi.Clone();
            clone.State = ProductInventoryState.Reserved;
            clone.Customer = customer;
            var ret = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(clone, pi);
            if (ret.Result == ResultCode.Successful)
            {
                pi.State = clone.State;
                pi.Customer = clone.Customer;
            }
            return ret;
        }

        public CommandResult UnReserve(ProductInventoryItem pi)
        {
            if (pi.State != ProductInventoryState.Reserved) return new CommandResult(ResultCode.Fail, "没有预订的项不能取消预订");
            var clone = pi.Clone();
            clone.State = ProductInventoryState.Inventory;
            var ret = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(clone, pi);
            if (ret.Result == ResultCode.Successful)
            {
                pi.State = clone.State;
            }
            return ret;
        }

        public CommandResult 设置结算单价(ProductInventoryItem pi, decimal price, string opt, string logID)
        {
            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
            var clone = pi.Clone();
            var ci = pi.GetCost(CostItem.入库单价);
            if (ci == null) return new CommandResult(ResultCode.Fail, "没有找到入库单价");
            var f = new CostItem() { Name = CostItem.结算单价, Price = price, WithTax = ci.WithTax, Prepay = ci.Prepay };
            clone.SetCost(f);
            AddOperationLog(pi.ID.ToString(), pi.DocumentType, "设置结算单价", unitWork, DateTime.Now, opt, logID, string.Format("将结算单价设置成{0},", price));
            ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(clone, pi, unitWork);
            var ret = unitWork.Commit();
            if (ret.Result == ResultCode.Successful)
            {
                pi.Costs = clone.Costs;
            }
            return ret;
        }

        private void AddOperationLog(string id, string docType, string operation, IUnitWork unitWork, DateTime dt, string opt, string logID = null, string memo = null)
        {
            DocumentOperation doc = new DocumentOperation()
            {
                ID = Guid.NewGuid(),
                DocumentID = id,
                DocumentType = docType,
                OperatDate = dt,
                Operation = operation,
                Operator = opt,
                LogID = logID,
                Memo = memo
            };
            ProviderFactory.Create<IProvider<DocumentOperation, Guid>>(RepoUri).Insert(doc, unitWork);
        }
        #endregion
    }
}
