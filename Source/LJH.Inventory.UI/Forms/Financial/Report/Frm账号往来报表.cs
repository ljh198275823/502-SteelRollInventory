﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.BLL;

namespace LJH.Inventory.UI.Forms.Financial.Report
{
    public partial class Frm账号往来报表 : FrmReportBase
    {
        public Frm账号往来报表()
        {
            InitializeComponent();
        }

        private decimal _balance = 0;
        private List<Account> _AllAccounts = null;

        public Account Account { get; set; }

        #region 重写基类方法
        protected override void Init()
        {
            ucDateTimeInterval1.ShowTime = false;
            ucDateTimeInterval1.Init();
            ucDateTimeInterval1.SelectThisMonth();
            txtAccount.Tag = Account;
            txtAccount.Text = Account != null ? Account.Name : null;
            base.Init();
            if (Account != null) btnSearch.PerformClick();
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            账户往来项 cp = item as 账户往来项;
            row.Tag = cp;
            row.Cells["colSheetDate"].Value = cp.Name;
            row.Cells["colSheetID"].Value = cp.单据编号;
            if (cp.收入 != 0 && !string.IsNullOrEmpty(cp.单据编号)) row.Cells["col收入"].Value = cp.收入;
            if (cp.支出 != 0 && !string.IsNullOrEmpty(cp.单据编号)) row.Cells["col支出"].Value = cp.支出;
            _balance += cp.收入 - cp.支出;
            row.Cells["col余额"].Value = _balance;
            Account ac = null;
            if (!string.IsNullOrEmpty(cp.付款单位) && _AllAccounts != null && _AllAccounts.Count > 0) ac = _AllAccounts.SingleOrDefault(it => it.ID == cp.付款单位);
            row.Cells["col付款单位"].Value = ac != null ? ac.Name : cp.付款单位;
            row.Cells["colMemo"].Value = cp.Memo;
        }

        protected override List<object> GetDataSource()
        {
            _balance = 0;
            _AllAccounts = new AccountBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;
            if (txtAccount.Tag == null)
            {
                MessageBox.Show("没有指定账号");
                return null;
            }
            var con = new AccountRecordSearchCondition();
            con.AccountID = (txtAccount.Tag as Account).ID;
            var ps = (new AccountRecordBLL(AppSettings.Current.ConnStr)).GetItems(con).QueryObjects;

            List<账户往来项> ret = new List<账户往来项>();
            var first = new 账户往来项();
            first.Name = "上期结余";
            first.收入 += ps.Sum(it => it.ClassID == CustomerPaymentType.客户收款 && it.CreateDate < ucDateTimeInterval1.StartDateTime.Date ? it.Amount : 0);
            first.收入 += ps.Sum(it => it.ClassID == CustomerPaymentType.其它收款 && it.CreateDate < ucDateTimeInterval1.StartDateTime.Date ? it.Amount : 0);
            first.收入 += ps.Sum(it => it.ClassID == CustomerPaymentType.转账入 && it.CreateDate < ucDateTimeInterval1.StartDateTime.Date ? it.Amount : 0);
            first.收入 += ps.Sum(it => it.ClassID == CustomerPaymentType.供应商退款 && it.CreateDate < ucDateTimeInterval1.StartDateTime.Date ? it.Amount : 0);
            first.支出 += ps.Sum(it => it.ClassID == CustomerPaymentType.供应商付款 && it.CreateDate < ucDateTimeInterval1.StartDateTime.Date ? it.Amount : 0);
            first.支出 += ps.Sum(it => it.ClassID == CustomerPaymentType.转账出 && it.CreateDate < ucDateTimeInterval1.StartDateTime.Date ? it.Amount : 0);
            first.支出 += ps.Sum(it => it.ClassID == CustomerPaymentType.公司管理费用 && it.CreateDate < ucDateTimeInterval1.StartDateTime.Date ? it.Amount : 0);
            first.支出 += ps.Sum(it => it.ClassID == CustomerPaymentType.客户退款 && it.CreateDate < ucDateTimeInterval1.StartDateTime.Date ? it.Amount : 0);
            //ret.Add(first);
            ret.AddRange(from it in ps
                         where it.CreateDate >= ucDateTimeInterval1.StartDateTime && it.CreateDate <= ucDateTimeInterval1.EndDateTime
                         select new 账户往来项()
                         {
                             Name = it.CreateDate.ToString("yyyy-MM-dd"),
                             CreateDate = it.CreateDate,
                             单据编号 = it.SheetID,
                             PaymentType = it.ClassID,
                             收入 = it.ClassID == CustomerPaymentType.客户收款 || it.ClassID == CustomerPaymentType.其它收款 || it.ClassID == CustomerPaymentType.转账入 || it.ClassID == CustomerPaymentType.供应商退款 ? it.Amount : 0,
                             支出 = it.ClassID == CustomerPaymentType.供应商付款 || it.ClassID == CustomerPaymentType.公司管理费用 || it.ClassID == CustomerPaymentType.转账出 || it.ClassID == CustomerPaymentType.客户退款 ? it.Amount : 0,
                             付款单位 = it.OtherAccount,
                             Memo = it.Memo
                         });
            ret = (from it in ret
                   orderby it.CreateDate ascending
                   where it.收入 != 0 || it.支出 != 0
                   select it).ToList();
            ret.Insert(0, first);
            return ret.Select(it => (object)it).ToList();
        }
        #endregion

        #region 事件处理程序
        private void lnkCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmAccountMaster frm = new FrmAccountMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Account ac = frm.SelectedItem as Account;
                txtAccount.Text = ac != null ? ac.Name : string.Empty;
                txtAccount.Tag = ac;
            }
        }

        private void txtCustomer_DoubleClick(object sender, EventArgs e)
        {
            txtAccount.Text = string.Empty;
            txtAccount.Tag = null;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dataGridView1.Rows[e.RowIndex].Tag == null) return;
                账户往来项 cp = dataGridView1.Rows[e.RowIndex].Tag as 账户往来项;
                if (this.dataGridView1.Columns[e.ColumnIndex].Name == "colSheetID")
                {
                    if (cp.PaymentType == CustomerPaymentType.客户收款 || cp.PaymentType == CustomerPaymentType.供应商付款)
                    {
                        if (!Operator.Current.Permit(Permission.CustomerPayment, PermissionActions.Read)) return;
                        var sheet = new CustomerPaymentBLL(AppSettings.Current.ConnStr).GetByID(cp.单据编号).QueryObject;
                        if (sheet != null)
                        {
                            FrmCustomerPaymentDetail frm = new FrmCustomerPaymentDetail();
                            frm.IsAdding = false;
                            frm.UpdatingItem = sheet;
                            frm.IsForView = true;
                            frm.PaymentType = cp.PaymentType;
                            frm.ShowDialog();
                        }
                    }
                    else if (cp.PaymentType == CustomerPaymentType.转账出 || cp.PaymentType == CustomerPaymentType.转账入)
                    {
                        var sheet = new CustomerPaymentBLL(AppSettings.Current.ConnStr).GetByID(cp.单据编号).QueryObject;
                        if (sheet != null)
                        {
                            Frm转公账 frm = new Frm转公账();
                            frm.IsAdding = false;
                            frm.UpdatingItem = sheet;
                            frm.IsForView = true;
                            frm.ShowDialog();
                        }
                    }
                    else if (cp.PaymentType == CustomerPaymentType.其它收款)
                    {
                        if (!Operator.Current.Permit(Permission.其它收款, PermissionActions.Read)) return;
                        var sheet = new CustomerPaymentBLL(AppSettings.Current.ConnStr).GetByID(cp.单据编号).QueryObject;
                        if (sheet != null)
                        {
                            Frm其它收款 frm = new Frm其它收款();
                            frm.IsAdding = false;
                            frm.UpdatingItem = sheet;
                            frm.IsForView = true;
                            frm.ShowDialog();
                        }
                    }
                    else if (cp.PaymentType == CustomerPaymentType.公司管理费用)
                    {
                        var sheet = new ExpenditureRecordBLL(AppSettings.Current.ConnStr).GetByID(cp.单据编号).QueryObject;
                        if (sheet != null)
                        {
                            FrmExpenditureRecordDetail frm = new FrmExpenditureRecordDetail();
                            frm.IsAdding = false;
                            frm.UpdatingItem = sheet;
                            frm.IsForView = true;
                            frm.ShowDialog();
                        }
                    }
                }
            }
        }
        #endregion
    }

    internal class 账户往来项
    {
        public string Name { get; set; }

        public DateTime CreateDate { get; set; }

        public CustomerPaymentType PaymentType { get; set; }

        public string 单据编号 { get; set; }

        public decimal 收入 { get; set; }

        public decimal 支出 { get; set; }

        public string 付款单位 { get; set; }

        public string Memo { get; set; }
    }
}
