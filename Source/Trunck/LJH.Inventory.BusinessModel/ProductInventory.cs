﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    public  class ProductInventory
    {
        #region 构造函数
        public ProductInventory()
        {
        }
        #endregion

        #region 公共属性
        public Guid ID { get; set; }
        /// <summary>
        /// 获取或设置仓库ID
        /// </summary>
        public string WareHouseID { get; set; }
        /// <summary>
        /// 获取或设置仓库
        /// </summary>
        public WareHouse WareHouse { get; set; }
        /// <summary>
        /// 获取或设置商品ID
        /// </summary>
        public string ProductID { get; set; }
        /// <summary>
        /// 获取或设置商品信息
        /// </summary>
        public Product Product{ get; set; }
        /// <summary>
        /// 获取或设置库存数量
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 获取或设置库存数量
        /// </summary>
        public decimal Count { get; set; }
        /// <summary>
        /// 获取或设置已经预订的数量
        /// </summary>
        public decimal Reserved { get; set; }
        /// <summary>
        /// 获取或设置库存金额
        /// </summary>
        public decimal Amount { get; set; }
        #endregion

        #region 公共方法
        public ProductInventory Clone()
        {
            return this.MemberwiseClone() as ProductInventory;
        }
        #endregion
    }
}