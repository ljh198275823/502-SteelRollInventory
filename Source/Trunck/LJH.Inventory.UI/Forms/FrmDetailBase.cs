﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BLL;

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmDetailBase : Form
    {
        public FrmDetailBase()
        {
            InitializeComponent();
        }

        #region 保护属性
        protected readonly string _AutoCreate = "自动创建";
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置是否是用于增加
        /// </summary>
        public bool IsAdding { get; set; }
        /// <summary>
        /// 获取或设置是否是用于查看项目的明细
        /// </summary>
        public bool IsForView { get; set; }
        /// <summary>
        /// 获取或设置要查看项的明细
        /// </summary>
        public object UpdatingItem { get; set; }
        #endregion

        #region 事件
        public event EventHandler<ItemUpdatedEventArgs> ItemUpdated;
        public event EventHandler<ItemAddedEventArgs> ItemAdded;
        #endregion

        #region 模板方法
        protected virtual bool CheckInput()
        {
            throw new NotImplementedException("子类没有重写CheckInput方法");
        }

        protected virtual void InitControls()
        {
            
        }
        protected virtual void ItemShowing()
        {
            
        }

        protected virtual Object GetItemFromInput()
        {
            throw new NotImplementedException("子类没有重写GetItemFromInput方法");
        }

        protected virtual CommandResult  AddItem(object addingItem)
        {
            throw new NotImplementedException("子类没有重写AddItem方法");
        }

        protected virtual CommandResult UpdateItem(object updatingItem)
        {
            throw new NotImplementedException("子类没有重写UpdateItem方法");
        }

        protected virtual void OnItemUpdated(ItemUpdatedEventArgs e)
        {
            if (this.ItemUpdated != null) this.ItemUpdated(this, e);
        }

        protected virtual void OnItemAdded(ItemAddedEventArgs e)
        {
            if (this.ItemAdded != null) ItemAdded(this, e);
        }

        protected virtual void ShowButtonState()
        {

        }
        #endregion

        #region 事件处理程序
        private void FrmDetailBase_Load(object sender, EventArgs e)
        {
            InitControls();
            if (!IsAdding)
            {
                ItemShowing();
            }
            btnOk.Enabled = !IsForView;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!CheckInput()) return;
            object item = GetItemFromInput();
            CommandResult ret = null;
            if (IsAdding)
            {
                ret = AddItem(item);
                if (ret.Result == ResultCode.Successful)
                {
                    OnItemAdded(new ItemAddedEventArgs(item));
                    this.Close();
                }
                else
                {
                    MessageBox.Show(ret.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                ret = UpdateItem(item);
                if (ret.Result == ResultCode.Successful)
                {
                    OnItemUpdated(new ItemUpdatedEventArgs(item));
                    this.Close();
                }
                else
                {
                    MessageBox.Show(ret.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}