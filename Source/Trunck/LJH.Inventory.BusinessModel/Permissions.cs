﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 操作员的权限枚举
    /// </summary>
    public enum Permission
    {
        #region 数据管理
        /// <summary>
        /// 查看系统选项
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "系统选项")]
        SystemOptions = 1,
        /// <summary>
        /// 产品类别
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "产品类别")]
        ProductCategory = 2,
        /// <summary>
        /// 查看商品
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "产品资料")]
        Product = 3,
        /// <summary>
        /// 仓库资料
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "仓库资料")]
        WareHouse = 4,
        /// <summary>
        /// 部门资料
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "部门资料")]
        Department=5,
        /// <summary>
        /// 人员资料
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "人员资料")]
        Staff = 5,
        /// <summary>
        /// 产品库存
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "产品库存")]
        ProductInventory = 5,
        /// <summary>
        /// 库存盘点
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "库存盘点")]
        InventoryCheck = 6,
        /// <summary>
        /// 客户类别
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "客户类别")]
        CustomerType = 7,
        /// <summary>
        /// 客户资料
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "客户资料")]
        Customer ,
        /// <summary>
        /// 订单资料
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "订单资料")]
        Order ,
        /// <summary>
        /// 送货单资料
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "送货单资料")]
        DeliverySheet = 9,
        /// <summary>
        /// 供应商类别
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "供应商类别")]
        SupplierType = 10,
        /// <summary>
        /// 供应商资料
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "供应商资料")]
        Supplier = 10,
        /// <summary>
        /// 采购单资料
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "采购单资料")]
        PurchaseOrder = 10,
        /// <summary>
        /// 收货单资料
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "收货单资料")]
        InventorySheet = 11,
        /// <summary>
        /// 客户还款资料
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "客户还款资料")]
        CustomerPayment = 12,
        /// <summary>
        /// 资金支出资料
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "资金支出资料")]
        ExpenditureRecord = 13,

        /// <summary>
        /// 资金支出资料
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "其它公司类别")]
        OtherCompanyType= 13,
        /// <summary>
        /// 资金支出资料
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "其它公司资料")]
        OtherCompany= 13,
        #endregion

        #region 查询与报表
        /// <summary>
        /// 出货记录查询
        /// </summary>
        [OperatorRight(Catalog = "查询与报表", Actions = PermissionActions.Read, Description = "出货记录查询")]
        DeliveryRecordReport = 101,
        /// <summary>
        /// 产品出货统计
        /// </summary>
        [OperatorRight(Catalog = "查询与报表", Actions = PermissionActions.Read, Description = "产品出货统计")]
        DeliveryStatistics = 102,
        /// <summary>
        /// 业务员业绩统计
        /// </summary>
        [OperatorRight(Catalog = "查询与报表", Actions = PermissionActions.Read, Description = "业务员业绩统计")]
        PerformanceStatistics = 103,
        #endregion

        #region 安全
        /// <summary>
        /// 操作员资料
        /// </summary>
        [OperatorRight(Catalog = "安全", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "操作员资料")]
        Operator = 201,
        /// <summary>
        /// 查看角色资料
        /// </summary>
        [OperatorRight(Catalog = "安全", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "角色资料")]
        Role = 202,
        #endregion
    }

    /// <summary>
    /// 表示权限的动作
    /// </summary>
    public enum PermissionActions
    {
        /// <summary>
        /// 查看
        /// </summary>
        Read = 0x1,
        /// <summary>
        /// 编辑
        /// </summary>
        Edit = 0x2,


    }

    public class OperatorRightAttribute : Attribute
    {
        #region 构造函数
        public OperatorRightAttribute()
        {
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 权限的类别
        /// </summary>
        public string Catalog { get; set; }
        /// <summary>
        /// 获取或设置权限的所有操作
        /// </summary>
        public PermissionActions Actions { get; set; }
        /// <summary>
        /// 权限的备注
        /// </summary>
        public string Description { get; set; }
        #endregion
    }
}
