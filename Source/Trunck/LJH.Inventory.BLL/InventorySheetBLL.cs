﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory .BusinessModel ;
using LJH.Inventory.BusinessModel.Resource;
using LJH.Inventory .BusinessModel .SearchCondition ;
using LJH.Inventory .DAL .IProvider ;

namespace LJH.Inventory.BLL
{
    public  class InventorySheetBLL
    {
        #region 构造函数
        public InventorySheetBLL(string repoUri)
        {
            _RepoUri = repoUri;
        }
        #endregion

        #region 私有变量
        private string _RepoUri;
        #endregion

        #region 私有方法
        private void AddToProductInventory(InventorySheet sheet, IUnitWork unitWork)
        {
            foreach (InventoryItem si in sheet.Items)
            {
                ProductInventoryItem pii = new ProductInventoryItem()
                {
                    ID = Guid.NewGuid(),
                    ProductID = si.ProductID,
                    WareHouseID = sheet.WareHouseID,
                    Unit = si.Unit,
                    Price = si.Price,
                    Count = si.Count,
                    AddDate =DateTime.Now ,
                    OrderItem = si.OrderItem,
                    PurchaseItem = si.PurchaseItem,
                    InventoryItem = si.ID,
                    InventorySheet = si.SheetNo,
                };
                ProviderFactory.Create<IProductInventoryItemProvider>(_RepoUri).Insert(pii, unitWork);
            }
        }

        private void AddReceivables(InventorySheet sheet, IUnitWork unitWork)
        {

        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 通过收货单编号获取收货单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public QueryResult<InventorySheet> GetByID(string id)
        {
            return ProviderFactory.Create<IInventorySheetProvider>(_RepoUri).GetByID(id);
        }
        /// <summary>
        /// 通过查询条件获取相关收货单
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        public QueryResultList<InventorySheet> GetItems(SearchCondition con)
        {
            return ProviderFactory.Create<IInventorySheetProvider>(_RepoUri).GetItems(con);
        }
        /// <summary>
        /// 通过查询条件获取相关商品销售记录
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        public QueryResultList<InventoryRecord> GetInventoryRecords(SearchCondition con)
        {
            return ProviderFactory.Create<IInventoryRecordProvider>(_RepoUri).GetItems(con);
        }
        /// <summary>
        /// 增加收货单
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public CommandResult Add(InventorySheet info,string opt)
        {
            if (string.IsNullOrEmpty(info.ID))
            {
                info.ID = ProviderFactory.Create<IAutoNumberCreater>(_RepoUri).CreateNumber(UserSettings.Current.InventorySheetPrefix,
                    UserSettings.Current.InventorySheetDateFormat, UserSettings.Current.InventorySheetSerialCount, info.DocumentType);
            }
            if (!string.IsNullOrEmpty(info.ID))
            {
                foreach (InventoryItem item in info.Items) //这一句不能省!!
                {
                    item.SheetNo = info.ID;
                }
                IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(_RepoUri);
                ProviderFactory.Create<IInventorySheetProvider>(_RepoUri).Insert(info, unitWork);

                DocumentOperation doc = new DocumentOperation()
                {
                    DocumentID = info.ID,
                    DocumentType = info.DocumentType,
                    OperatDate = DateTime.Now,
                    Operation = "新增",
                    State = SheetState.Add,
                    Operator = opt,
                };
                ProviderFactory.Create<IDocumentOperationProvider>(_RepoUri).Insert(doc, unitWork);
                return unitWork.Commit();
            }
            else
            {
                return new CommandResult(ResultCode.Fail, "创建收货单号失败，请重试");
            }
        }
        /// <summary>
        /// 更新收货单
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public CommandResult Update(InventorySheet info, string opt)
        {
            IInventorySheetProvider provider = ProviderFactory.Create<IInventorySheetProvider>(_RepoUri);
            InventorySheet original = provider.GetByID(info.ID).QueryObject;
            if (original != null)
            {
                IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(_RepoUri);
                provider.Update(info, original, unitWork);

                DocumentOperation doc = new DocumentOperation()
                {
                    DocumentID = info.ID,
                    DocumentType = info.DocumentType,
                    OperatDate = DateTime.Now,
                    Operation = "修改",
                    State = info.State,
                    Operator = opt,
                };
                ProviderFactory.Create<IDocumentOperationProvider>(_RepoUri).Insert(doc, unitWork);
                return unitWork.Commit();
            }
            else
            {
                return new CommandResult(ResultCode.Fail, "系统中已经不存在单号为 " + info.ID + " 的收货单");
            }
        }
        /// <summary>
        /// 审批收货单
        /// </summary>
        /// <param name="info"></param>
        /// <param name="opt"></param>
        /// <returns></returns>
        public CommandResult Approve(string sheetNo, string opt)
        {
            InventorySheet info = ProviderFactory.Create<IInventorySheetProvider>(_RepoUri).GetByID(sheetNo).QueryObject;
            if (info != null)
            {
                if (info.CanApprove)
                {
                    IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(_RepoUri);
                    InventorySheet original = info.Clone();
                    info.State = SheetState.Approved;
                    ProviderFactory.Create<IInventorySheetProvider>(_RepoUri).Update(info, original, unitWork);

                    DocumentOperation doc = new DocumentOperation()
                    {
                        DocumentID = info.ID,
                        DocumentType = info.DocumentType,
                        OperatDate = DateTime.Now,
                        Operation = "审核",
                        State = SheetState.Approved,
                        Operator = opt,
                    };
                    ProviderFactory.Create<IDocumentOperationProvider>(_RepoUri).Insert(doc, unitWork);
                    return unitWork.Commit();
                }
                else
                {
                    return new CommandResult(ResultCode.Fail, "单号为 " + info.ID + " 的收货单不能再审核");
                }
            }
            else
            {
                return new CommandResult(ResultCode.Fail, "系统中已经不存在单号为 " + info.ID + " 的收货单");
            }
        }
        /// <summary>
        /// 收货单收货
        /// </summary>
        /// <param name="sheetNo">收货单单号</param>
        /// <param name="opt">收货操作员</param>
        /// <returns></returns>
        public CommandResult Inventory(string sheetNo, string opt)
        {
            InventorySheet sheet = ProviderFactory.Create<IInventorySheetProvider>(_RepoUri).GetByID(sheetNo).QueryObject;
            if (sheet == null) return new CommandResult(ResultCode.Fail, "系统中已经不存在单号为 " + sheetNo + " 的收货单");
            if (!sheet.CanInventory) return new CommandResult(ResultCode.Fail, "状态为" + SheetStateDescription.GetDescription(sheet.State) + " 的收货单 " + " 不能收货");

            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(_RepoUri);
            InventorySheet sheet1 = sheet.Clone();
            sheet.State = SheetState.Inventory;
            ProviderFactory.Create<IInventorySheetProvider>(_RepoUri).Update(sheet, sheet1, unitWork);

            AddToProductInventory(sheet, unitWork); //更新商品库存
            AddReceivables(sheet, unitWork);         //增加供应商的应收账款

            DocumentOperation doc = new DocumentOperation()
            {
                DocumentID = sheet.ID,
                DocumentType = sheet.DocumentType,
                OperatDate = DateTime.Now,
                Operation = "收货",
                State = SheetState.Inventory,
                Operator = opt,
            };
            ProviderFactory.Create<IDocumentOperationProvider>(_RepoUri).Insert(doc, unitWork);
            return unitWork.Commit();
        }

        /// <summary>
        /// 将收货单作废
        /// </summary>
        /// <param name="sheetNo"></param>
        /// <param name="opt"></param>
        /// <returns></returns>
        public CommandResult Nullify(string sheetNo, string opt)
        {
            InventorySheet sheet = ProviderFactory.Create<IInventorySheetProvider>(_RepoUri).GetByID(sheetNo).QueryObject;
            if (sheet == null) return new CommandResult(ResultCode.Fail, "系统中已经不存在单号为 " + sheetNo + " 的收货单");
            if (!sheet.CanCancel) return new CommandResult(ResultCode.Fail, "状态为" + SheetStateDescription.GetDescription(sheet.State) + " 的收货单 " + " 不能作废");

            SheetState originalState = sheet.State;
            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(_RepoUri);
            InventorySheet sheet1 = sheet.Clone();
            sheet.State = SheetState.Canceled;
            ProviderFactory.Create<IInventorySheetProvider>(_RepoUri).Update(sheet, sheet1, unitWork);

            if (originalState == SheetState.Inventory) //
            {
                foreach (InventoryItem si in sheet.Items)
                {
                    ProductInventoryItemSearchCondition piSearch = new ProductInventoryItemSearchCondition()
                    {
                        ProductID = si.ProductID,
                        InventoryItem = si.ID
                    };
                    List<ProductInventoryItem> piItems = ProviderFactory.Create<IProductInventoryItemProvider>(_RepoUri).GetItems(piSearch).QueryObjects;
                    foreach (ProductInventoryItem pii in piItems)
                    {
                        if (pii.FromInventory) //如果已经被别的订单分配了，那么这些订单就要重新分配库存，包括已经出货的。
                        {
                        }
                        else
                        {
                            ProviderFactory.Create<IProductInventoryItemProvider>(_RepoUri).Delete(pii, unitWork);
                        }
                    }
                    //删除供应商应付款项。
                }
            }

            DocumentOperation doc = new DocumentOperation()
            {
                DocumentID = sheet.ID,
                DocumentType = sheet.DocumentType,
                OperatDate = DateTime.Now,
                Operation = "取消",
                State = SheetState.Canceled,
                Operator = opt,
            };
            ProviderFactory.Create<IDocumentOperationProvider>(_RepoUri).Insert(doc, unitWork);
            return unitWork.Commit();
        }
        #endregion
    }
}
