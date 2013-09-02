﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.DAL.IProvider;

namespace LJH.Inventory.BLL
{
    public class CustomerPaymentBLL
    {
        #region 构造函数
        public CustomerPaymentBLL(string repoUri)
        {
            _RepoUri = repoUri;
        }
        #endregion

        #region 私有变量
        private string _RepoUri;
        #endregion

        #region 动态库内部方法
        /// <summary>
        /// 结算各项应收账款明细
        /// </summary>
        /// <param name="paymentID">客户付款ID</param>
        /// <param name="customerID">客户ID</param>
        /// <param name="amount">结算的金额</param>
        /// <param name="firstSheet">结算的送货单,没有指定的话填空或null</param>
        /// <param name="exceptID">不用结算的送货单,没有指定的话填空或null</param>
        /// <param name="exceptDaiFu">不用结算的代付款项,没有指定的话填0</param>
        /// <param name="unitWork">工作单元</param>
        /// <returns></returns>
        internal void SettleReceivables(string paymentID, string customerID, decimal amount, string receivableID, string exceptID, IUnitWork unitWork)
        {
            if (amount <= 0) return;
            if (!string.IsNullOrEmpty(receivableID))
            {
                CustomerReceivable cr = ProviderFactory.Create<ICustomerReceivableProvider>(_RepoUri).GetByID(receivableID).QueryObject;
                if (cr != null && cr.Receivable >0)
                {
                    decimal temp = cr.Receivable >= amount ? amount : cr.Receivable;
                    CustomerPaymentAssign cpa = new CustomerPaymentAssign()
                    {
                        PaymentID = paymentID,
                        ReceivableID = cr.ID,
                        Amount = temp
                    };
                    ProviderFactory.Create<ICustomerPaymentAssignProvider>(_RepoUri).Insert(cpa, unitWork);
                }
            }
            else
            {
                List<CustomerReceivable> items = (new CustomerBLL(_RepoUri)).GetUnSettleReceivables(customerID);
                if (items != null && items.Count > 0)
                {
                    items = (from item in items orderby item.CreateDate ascending select item).ToList();
                    foreach (CustomerReceivable cr in items)
                    {
                        if (cr.ID != exceptID)
                        {
                            decimal temp = cr.Receivable >= amount ? amount : cr.Receivable;
                            CustomerPaymentAssign cpa = new CustomerPaymentAssign()
                            {
                                PaymentID = paymentID,
                                ReceivableID = cr.ID,
                                Amount = temp
                            };
                            ProviderFactory.Create<ICustomerPaymentAssignProvider>(_RepoUri).Insert(cpa, unitWork);
                            amount -= temp;
                            if (amount == 0) return;
                        }
                    }
                }
            }
        }
        #endregion

        #region 公共方法
        public QueryResult<CustomerPayment> GetByID(string paymentID)
        {
            return ProviderFactory.Create<ICustomerPaymentProvider>(_RepoUri).GetByID(paymentID);
        }
        /// <summary>
        /// 通过指定条件获取符合的客户付款单
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        public QueryResultList<CustomerPayment> GetItems(SearchCondition con)
        {
            ICustomerPaymentProvider provider = ProviderFactory.Create<ICustomerPaymentProvider>(_RepoUri);
            return provider.GetItems(con);
        }
        /// <summary>
        /// 获取某个客户付款单的金额分配
        /// </summary>
        /// <param name="paymentID"></param>
        /// <returns></returns>
        public QueryResultList<CustomerPaymentAssign> GetAssigns(string paymentID)
        {
            CustomerPaymentAssignSearchCondition con = new CustomerPaymentAssignSearchCondition();
            con.PaymentID = paymentID;
            return ProviderFactory.Create<ICustomerPaymentAssignProvider>(_RepoUri).GetItems(con);
        }
        /// <summary>
        /// 获取某个客户的所有还有余额的付款单
        /// </summary>
        /// <returns></returns>
        public QueryResultList<CustomerPayment> GetAllRemains(string customerID)
        {
            CustomerPaymentSearchCondition con = new CustomerPaymentSearchCondition();
            con.CustomerID = customerID;
            con.HasRemain = true;
            return ProviderFactory.Create<ICustomerPaymentProvider>(_RepoUri).GetItems(con);
        }
        /// <summary>
        /// 分配客户付款金额
        /// </summary>
        /// <param name="assigns"></param>
        /// <returns></returns>
        public CommandResult AssignPayment(List<CustomerPaymentAssign> assigns)
        {
            IUnitWork unitwork = ProviderFactory.Create<IUnitWork>(_RepoUri);
            foreach (CustomerPaymentAssign assign in assigns)
            {
                ProviderFactory.Create<ICustomerPaymentAssignProvider>(_RepoUri).Insert(assign, unitwork);
            }
            return unitwork.Commit();
        }
        /// <summary>
        /// 增加客户付款信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public CommandResult Add(CustomerPayment info, bool PayReceivables)
        {
            Customer customer = (new CustomerBLL(_RepoUri)).GetByID(info.CustomerID).QueryObject;
            if (customer == null) return new CommandResult(ResultCode.Fail, "系统中不存在编号为 " + info.CustomerID + " 的客户");
            if (string.IsNullOrEmpty(info.ID))
            {
                info.ID = ProviderFactory.Create<IAutoNumberCreater>(_RepoUri).CreateNumber(UserSettings.Current.CustomerPaymentPrefix,
                    UserSettings.Current.CustomerPaymentDateFormat, UserSettings.Current.CustomerPaymentSerialCount, "customerPayment"); //付款单
                if (string.IsNullOrEmpty(info.ID)) return new CommandResult(ResultCode.Fail, "创建单号失败，请重试");
            }
            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(_RepoUri);

            if (PayReceivables)
            {
                SettleReceivables(info.ID, info.CustomerID, info.Amount, info.SheetNo, null, unitWork);
            }

            ICustomerPaymentProvider provider = ProviderFactory.Create<ICustomerPaymentProvider>(_RepoUri);
            provider.Insert(info, unitWork);
            return unitWork.Commit();
        }
        /// <summary>
        /// 增加并全部分配
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public CommandResult AddAndAssign(CustomerPayment info)
        {
            Customer customer = (new CustomerBLL(_RepoUri)).GetByID(info.CustomerID).QueryObject;
            if (customer == null) return new CommandResult(ResultCode.Fail, "系统中不存在编号为 " + info.CustomerID + " 的客户");
            if (string.IsNullOrEmpty(info.ID))
            {
                info.ID = ProviderFactory.Create<IAutoNumberCreater>(_RepoUri).CreateNumber(UserSettings.Current.CustomerPaymentPrefix,
                    UserSettings.Current.CustomerPaymentDateFormat, UserSettings.Current.CustomerPaymentSerialCount, "customerPayment"); //付款单
                if (string.IsNullOrEmpty(info.ID)) return new CommandResult(ResultCode.Fail, "创建单号失败，请重试");
            }
            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(_RepoUri);

            CustomerPaymentAssign assign = new CustomerPaymentAssign()
            {
                PaymentID = info.ID,
                ReceivableID = info.SheetNo,
                Amount = info.Amount,
            };
            ProviderFactory.Create<ICustomerPaymentAssignProvider>(_RepoUri).Insert(assign, unitWork);
            ProviderFactory.Create<ICustomerPaymentProvider>(_RepoUri).Insert(info, unitWork);
            return unitWork.Commit();
        }
        /// <summary>
        /// 取消客户的付款记录
        /// </summary>
        /// <param name="info"></param>
        /// <param name="firstFromPrepay"></param>
        /// <returns></returns>
        public CommandResult Cancel(CustomerPayment info, string opt)
        {
            CustomerPayment original = ProviderFactory.Create<ICustomerPaymentProvider>(_RepoUri).GetByID(info.ID).QueryObject;
            if (original == null) return new CommandResult(ResultCode.Fail, "系统中不存在此项");
            if (original.CancelDate != null) return new CommandResult(ResultCode.Fail, "取消的单据不能再次取消");

            Customer c = (new CustomerBLL(_RepoUri)).GetByID(info.CustomerID).QueryObject;
            if (c == null) return new CommandResult(ResultCode.Fail, "系统中不存在编号为 " + info.CustomerID + " 的客户");

            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(_RepoUri);
            decimal amount = info.Amount;
            List<CustomerPaymentAssign> assigns = GetAssigns(info.ID).QueryObjects;
            if (assigns != null && assigns.Count > 0)
            {
                foreach (CustomerPaymentAssign assign in assigns)
                {
                    ProviderFactory.Create<ICustomerPaymentAssignProvider>(_RepoUri).Delete(assign, unitWork);
                }
            }
            CustomerPayment cp = info.Clone();
            info.CancelDate = DateTime.Now;
            info.CancelOperator = opt;
            ICustomerPaymentProvider provider = ProviderFactory.Create<ICustomerPaymentProvider>(_RepoUri);
            provider.Update(info, cp, unitWork);
            return unitWork.Commit();
        }
        #endregion
    }
}