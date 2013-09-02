﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示客户
    /// </summary>
    public class Supplier
    {
        #region 构造函数
        public Supplier()
        {
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置编号
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 获取或设置客户公司名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 获取或设置所在国家
        /// </summary>
        public string Nation { get; set; }
        /// <summary>
        /// 获取或设置所在城市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 获取或设置类别
        /// </summary>
        public string CategoryID { get; set; }
        /// <summary>
        /// 获取或设置供应商类别
        /// </summary>
        public SupplierType Category { get; set; }
        /// <summary>
        /// 获取或设置联系电话
        /// </summary>
        public string TelPhone { get; set; }
        /// <summary>
        /// 获取或设置传真
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        /// 获取或设置网站
        /// </summary>
        public string Website { get; set; }
        /// <summary>
        /// 获取或设置邮政编码
        /// </summary>
        public string PostalCode { get; set; }
        /// <summary>
        /// 获取或设置地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 获取或设置开户行
        /// </summary>
        public string Bank { get; set; }
        /// <summary>
        /// 获取或设置银行账号
        /// </summary>
        public string BankAccount { get; set; }
        /// <summary>
        /// 获取或设置SwiftNo
        /// </summary>
        public string SwiftNO { get; set; }
        /// <summary>
        /// 获取或设置信用限额
        /// </summary>
        public decimal CreditLine { get; set; }
        /// <summary>
        /// 获取或设置备注
        /// </summary>
        public string Memo { get; set; }
        #endregion

        #region 公共方法
        public Supplier Clone()
        {
            return MemberwiseClone() as Supplier;
        }
        #endregion
    }
}