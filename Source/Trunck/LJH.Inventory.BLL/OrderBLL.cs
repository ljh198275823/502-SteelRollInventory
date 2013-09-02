﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory .BusinessModel ;
using LJH.Inventory .DAL .IProvider ;
using LJH.Inventory.BusinessModel.SearchCondition;

namespace LJH.Inventory.BLL
{
    public class OrderBLL
    {
        #region 构造函数
        public OrderBLL(string repoUri)
        {
            _RepoUri = repoUri;
        }
        #endregion

        #region 私有变量
        private string _RepoUri;

        private string _DocumentType = "order";
        #endregion

        #region 公共方法
        /// <summary>
        /// 通过订单号获取订单
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public QueryResult<Order> GetByID(string orderID)
        {
            IOrderProvider provider = ProviderFactory.Create<IOrderProvider>(_RepoUri);
            return provider.GetByID(orderID);
        }

        public QueryResultList<Order> GetItems(SearchCondition con)
        {
            return ProviderFactory.Create<IOrderProvider>(_RepoUri).GetItems(con);
        }

        public QueryResultList<DocumentOperation> GetHisOperations(string orderID)
        {
            DocumentSearchCondition con = new DocumentSearchCondition()
            {
                DocumentID = orderID,
                DocumentType = _DocumentType
            };
            return ProviderFactory.Create<IDocumentOperationProvider>(_RepoUri).GetItems(con);
        }

        /// <summary>
        /// 增加一个订单
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public CommandResult Add(Order info, string opt)
        {
            if (string.IsNullOrEmpty(info.ID))
            {
                info.ID = ProviderFactory.Create<IAutoNumberCreater>(_RepoUri).CreateNumber(UserSettings.Current.OrderPrefix,
                    UserSettings.Current.OrderDateFormat, UserSettings.Current.OrderSerialCount, _DocumentType);
            }
            if (!string.IsNullOrEmpty(info.ID))
            {
                info.Items.ForEach(item => item.OrderID = info.ID);//这一句不能省!!
                IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(_RepoUri);
                IOrderProvider provider = ProviderFactory.Create<IOrderProvider>(_RepoUri);
                provider.Insert(info, unitWork);

                DocumentOperation doc = new DocumentOperation()
                {
                    DocumentID = info.ID,
                    DocumentType = _DocumentType,
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
                return new CommandResult(ResultCode.Fail, "创建订单号失败，请重试");
            }
        }
        /// <summary>
        ///更新订单
        /// </summary>
        /// <param name="info"></param>
        /// <param name="opt"></param>
        /// <returns></returns>
        public CommandResult Update(Order info, string opt)
        {
            Order original = ProviderFactory.Create<IOrderProvider>(_RepoUri).GetByID(info.ID).QueryObject;
            if (original != null)
            {
                IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(_RepoUri);
                ProviderFactory.Create<IOrderProvider>(_RepoUri).Update(info, original, unitWork);
                DocumentOperation doc = new DocumentOperation()
                {
                    DocumentID = info.ID,
                    DocumentType = _DocumentType,
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
                return new CommandResult(ResultCode.Fail, string.Format("系统中不存在订单号为 {0} 的订单", info.ID));
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
            Order info = ProviderFactory.Create<IOrderProvider>(_RepoUri).GetByID(sheetNo).QueryObject;
            if (info != null)
            {
                if (info.CanApprove)
                {
                    IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(_RepoUri);
                    Order original = info.Clone();
                    info.State = SheetState.Approved;
                    ProviderFactory.Create<IOrderProvider>(_RepoUri).Update(info, original, unitWork);

                    DocumentOperation doc = new DocumentOperation()
                    {
                        DocumentID = info.ID,
                        DocumentType = _DocumentType,
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
                    return new CommandResult(ResultCode.Fail, "单号为 " + info.ID + " 的订单不能再审核");
                }
            }
            else
            {
                return new CommandResult(ResultCode.Fail, "系统中已经不存在单号为 " + info.ID + " 的订单");
            }
        }
        /// <summary>
        /// 将订单作废
        /// </summary>
        /// <param name="sheetNo"></param>
        /// <param name="opt"></param>
        /// <returns></returns>
        public CommandResult Nullify(string sheetNo, string opt)
        {
            Order info = ProviderFactory.Create<IOrderProvider>(_RepoUri).GetByID(sheetNo).QueryObject;
            if (info != null)
            {
                if (info.CanCancel)
                {
                    IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(_RepoUri);
                    Order original = info.Clone();
                    info.State = SheetState.Canceled;
                    ProviderFactory.Create<IOrderProvider>(_RepoUri).Update(info, original, unitWork);
                    DocumentOperation doc = new DocumentOperation()
                    {
                        DocumentID = info.ID,
                        DocumentType = _DocumentType,
                        OperatDate = DateTime.Now,
                        Operation = "作废",
                        State = SheetState.Canceled,
                        Operator = opt
                    };
                    ProviderFactory.Create<IDocumentOperationProvider>(_RepoUri).Insert(doc, unitWork);
                    return unitWork.Commit();
                }
                else
                {
                    return new CommandResult(ResultCode.Fail, "单号为 " + info.ID + " 的订单已经作废");
                }
            }
            else
            {
                return new CommandResult(ResultCode.Fail, "系统中已经不存在单号为 " + info.ID + " 的订单");
            }
        }
        #endregion
    }
}