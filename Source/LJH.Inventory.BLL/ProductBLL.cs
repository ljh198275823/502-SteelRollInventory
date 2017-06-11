﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory .BusinessModel .SearchCondition ;
using LJH.Inventory.DAL.IProvider;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.BLL
{
    public class ProductBLL : BLLBase<string, Product>
    {
        #region 构造函数
        public ProductBLL(string repoUri)
            : base(repoUri)
        {
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public override CommandResult Add(Product info)
        {
            if (string.IsNullOrEmpty(info.ID))
            {
                if (info.Category != null && !string.IsNullOrEmpty(info.Category.Prefix))
                {
                    info.ID = ProviderFactory.Create<IAutoNumberCreater>(RepoUri).CreateNumber(info.Category.Prefix, UserSettings.Current.ProductSerialCount, "product");
                }
                else
                {
                    info.ID = ProviderFactory.Create<IAutoNumberCreater>(RepoUri).CreateNumber("P", UserSettings.Current.ProductSerialCount, "product");
                }
            }
            if (!string.IsNullOrEmpty(info.ID))
            {
                return base.Add(info);
            }
            else
            {
                return new CommandResult(ResultCode.Fail, "创建商品编号失败，请重试");
            }
        }

        public Product Create(string categoryID, string specification, string model, decimal? density, bool onlyCreate = false)
        {
            return Create(categoryID, specification, model, null, null, density, onlyCreate);
        }

        public Product Create(string categoryID, string specification, string model, decimal? weight, decimal? length, decimal? density, bool onlyCreate = false)
        {
            Product p = null;
            if (!onlyCreate)
            {
                List<Product> ps = GetItems(new ProductSearchCondition() { CategoryID = categoryID, Specification = specification }).QueryObjects;
                if (ps != null && ps.Count > 0)
                {
                    p = ps.FirstOrDefault(it => it.CategoryID == categoryID && it.Specification == specification && it.Model == model && it.Weight == weight && it.Length == length);
                }
                if (p != null) return p;
            }
            p = new Product();
            p.Specification = specification;
            p.CategoryID = categoryID;
            p.Category = new ProductCategoryBLL(RepoUri).GetByID(categoryID).QueryObject;
            p.Name = p.Category != null ? p.Category.Name : categoryID;
            p.Unit = string.Empty;
            p.Model = model;
            p.Length = length;
            p.Weight = weight;
            p.Density = density;
            var ret = Add(p);
            if (ret.Result == ResultCode.Successful) return p;
            return null;
        }

        /// <summary>
        /// 获取所有的规格
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllSpecifications(ProductSearchCondition con)
        {
            var provider = ProviderFactory.Create<IProductProvider>(RepoUri);
            return provider.GetAllSpecifications(con);
        }
        #endregion
    }
}