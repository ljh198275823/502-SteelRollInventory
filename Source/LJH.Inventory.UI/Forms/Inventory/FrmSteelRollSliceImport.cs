﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Threading;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BLL;
using LJH.Inventory.BusinessModel;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.WinformControl;

namespace LJH.Inventory.UI.Forms.Inventory
{
    public partial class FrmSteelRollSliceImport : Form
    {
        public FrmSteelRollSliceImport()
        {
            InitializeComponent();
        }

        private List<WareHouse> _AllWareHouses = new WareHouseBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;
        private List<ProductCategory> _Categories = new ProductCategoryBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;

        #region 私有方法
        private void ClearData()
        {
            this.dataGridView1.Rows.Clear();
            lblSource.Text = "条数据";
        }

        private bool FillColumn(DataGridViewColumn col, DataTable source, string sourceColName = null)
        {
            if (string.IsNullOrEmpty(sourceColName)) sourceColName = col.HeaderText.Trim('*').Trim();
            foreach (DataColumn dc in source.Columns)
            {
                if (dc.ColumnName == sourceColName)
                {
                    for (int i = 0; i < source.Rows.Count; i++)
                    {
                        if (dataGridView1.Rows.Count < i + 1)
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells["colRowIndex"].Value = i + 1; // 从1开始
                        }
                        object value = source.Rows[i][dc];
                        dataGridView1.Rows[i].Cells[col.Name].Value = value;
                    }
                    return true;
                }
            }
            return false;
        }

        private ProductInventoryItem GetStudentFromRow(DataGridViewRow row)
        {
            DateTime addDate = DateTime.Now;
            if (row.Cells["colAddDate"].Value != null && !string.IsNullOrEmpty(row.Cells["colAddDate"].Value.ToString().Trim()) &&
                !DateTime.TryParse(row.Cells["colAddDate"].Value.ToString().Trim(), out addDate))
            {
                row.Cells["colReason"].Value = "入库日期列不能转化成日期";
                return null;
            }
            string ws = null;
            if (row.Cells["colWareHouse"].Value == null)
            {
                row.Cells["colReason"].Value = "没有指定仓库";
                return null;
            }
            else
            {
                ws = LJH.GeneralLibrary.StringHelper.ToDBC(row.Cells["colWareHouse"].Value.ToString().Trim());
                if (_AllWareHouses == null || _AllWareHouses.Count == 0 || !_AllWareHouses.Exists(it => it.Name == ws))
                {
                    row.Cells["colReason"].Value = "系统不存在此仓库";
                    return null;
                }
                ws = _AllWareHouses.First(it => it.Name == ws).ID;
            }
            string category = null;
            if (row.Cells["colCategory"].Value == null)
            {
                row.Cells["colReason"].Value = "没有指定类别";
                return null;
            }
            else
            {
                category = LJH.GeneralLibrary.StringHelper.ToDBC(row.Cells["colCategory"].Value.ToString().Trim());
                if (_Categories == null || _Categories.Count == 0 || !_Categories.Exists(it => it.Name == category))
                {
                    row.Cells["colReason"].Value = "系统不存在此类别";
                    return null;
                }
                category = _Categories.First(it => it.Name == category).ID;
            }
            string specification = null;
            if (row.Cells["colSpecification"].Value == null)
            {
                row.Cells["colReason"].Value = "没有指定规格";
                return null;
            }
            else
            {
                specification = LJH.GeneralLibrary.StringHelper.ToDBC(row.Cells["colSpecification"].Value.ToString().Trim());
                decimal? width = SpecificationHelper.GetWrittenWidth(specification);
                decimal? thick = SpecificationHelper.GetWrittenThick(specification);
                if (width == null || thick == null)
                {
                    row.Cells["colReason"].Value = "规格格式不正确";
                    return null;
                }
                specification = string.Format("{0:F2}*{1:F0}", thick > width ? width : thick, width > thick ? width : thick); //一般来说厚度小于宽度，这里将表格中的“宽*厚”这种格式改成“厚*宽”
            }
            if (row.Cells["colModel"].Value == null || string.IsNullOrEmpty(row.Cells["colModel"].Value.ToString().Trim()))
            {
                row.Cells["colReason"].Value = "没有指定加工类型";
                return null;
            }
            string model = LJH.GeneralLibrary.StringHelper.ToDBC(row.Cells["colModel"].Value.ToString().Trim());
            decimal weight = 0;
            if (row.Cells["colWeight"].Value != null && !string.IsNullOrEmpty(row.Cells["colWeight"].Value.ToString().Trim()) &&
               (!decimal.TryParse(LJH.GeneralLibrary.StringHelper.ToDBC(row.Cells["colWeight"].Value.ToString().Trim()), out weight) || weight <= 0))
            {
                row.Cells["colReason"].Value = "重量不正确";
                return null;
            }
            decimal length = 0;
            if (row.Cells["colLength"].Value != null && !string.IsNullOrEmpty(row.Cells["colLength"].Value.ToString().Trim()) &&
                (!decimal.TryParse(LJH.GeneralLibrary.StringHelper.ToDBC(row.Cells["colLength"].Value.ToString().Trim()), out length) || length <= 0))
            {
                row.Cells["colReason"].Value = "长度不正确";
                return null;
            }
            if (weight == 0 && length == 0)
            {
                row.Cells["colReason"].Value = "重量和长度至少指定一个";
                return null;
            }
            decimal reaThick = 0;
            if (row.Cells["colThick"].Value != null && !string.IsNullOrEmpty(row.Cells["colThick"].Value.ToString().Trim()) &&
                (!decimal.TryParse(LJH.GeneralLibrary.StringHelper.ToDBC(row.Cells["colThick"].Value.ToString().Trim()), out reaThick) || reaThick <= 0))
            {
                row.Cells["colReason"].Value = "厚度不正确";
                return null;
            }
            decimal count = 0;
            if (row.Cells["colCount"].Value == null ||
                !decimal.TryParse(LJH.GeneralLibrary.StringHelper.ToDBC(row.Cells["colCount"].Value.ToString().Trim()), out count) || count <= 0)
            {
                row.Cells["colReason"].Value = "数量不正确";
                return null;
            }
            count = (int)count; //取整
            if (row.Cells["colCustomer"].Value == null || string.IsNullOrEmpty(row.Cells["colCustomer"].Value.ToString().Trim()))
            {
                row.Cells["colReason"].Value = "没有指定客户";
                return null;
            }
            string customer = LJH.GeneralLibrary.StringHelper.ToDBC(row.Cells["colCustomer"].Value.ToString().Trim());
            string supplier = row.Cells["colSupplier"].Value == null ? null : LJH.GeneralLibrary.StringHelper.ToDBC(row.Cells["colSupplier"].Value.ToString().Trim());
            string manufacture = row.Cells["colManufacture"].Value == null ? null : LJH.GeneralLibrary.StringHelper.ToDBC(row.Cells["colManufacture"].Value.ToString().Trim());
            var product = new ProductBLL(AppSettings.Current.ConnStr).Create(category, specification, model, weight == 0 || model == "开平" ? null : (decimal?)weight, length == 0 ? null : (decimal?)length, 7.85m);
            if (product == null)
            {
                row.Cells["colReason"].Value = "创建产品失败";
                return null;
            }
            ProductInventoryItem pi = new ProductInventoryItem();
            pi.ID = Guid.NewGuid();
            pi.AddDate = addDate;
            pi.ProductID = product.ID;
            pi.Product = product;
            pi.Model = product.Model;
            pi.WareHouseID = ws;
            pi.OriginalThick = reaThick == 0 ? null : (decimal?)reaThick;
            pi.Weight = weight;
            pi.Length = length;
            pi.Count = count;
            pi.Unit = "卷";
            pi.Customer = customer;
            pi.Supplier = supplier;
            pi.Manufacture = manufacture;
            pi.Memo = row.Cells["colMemo"].Value != null ? row.Cells["colMemo"].Value.ToString().Trim() : null;
            pi.InventorySheet = "导入";
            pi.State = ProductInventoryState.Inventory;
            return pi;
        }
        #endregion

        #region 事件处理程序
        private void FrmStudentImport_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dig = new OpenFileDialog();
                dig.Filter = "Excel文档|*.xls;*.xlsx|所有文件(*.*)|*.*";
                if (dig.ShowDialog() == DialogResult.OK)
                {
                    ClearData();
                    string path = dig.FileName;
                    txtPath.Text = path;
                    DataTable _SourceTable = NPOIExcelHelper.Import(path);
                    if (_SourceTable != null)
                    {
                        foreach (DataGridViewColumn col in dataGridView1.Columns)
                        {
                            if (!col.ReadOnly) FillColumn(col, _SourceTable); //可编辑的列才需要填充数据
                        }
                    }
                    lblSource.Text = string.Format("{0}条数据", _SourceTable != null ? _SourceTable.Rows.Count : 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            int total = dataGridView1.Rows.Count - txtFirstRow.IntergerValue + 1;
            if (total == 0) return;
            int firstRow = txtFirstRow.IntergerValue;
            int count = 0;
            int success = 0;

            FrmProcessing frm = new FrmProcessing();
            Action action = delegate()
            {
                try
                {
                    SteelRollSliceBLL bll = new SteelRollSliceBLL(AppSettings.Current.ConnStr);
                    for (int i = firstRow - 1; i < dataGridView1.Rows.Count; i++)
                    {
                        try
                        {
                            if (dataGridView1.Rows[i].Visible)
                            {
                                count++;
                                var sr = GetStudentFromRow(dataGridView1.Rows[i]);
                                if (sr != null)
                                {
                                    CommandResult ret = bll.Add(sr);
                                    if (ret.Result == ResultCode.Successful)
                                    {
                                        success++;
                                        this.Invoke((Action)(() => dataGridView1.Rows[i].Visible = false));
                                    }
                                    else
                                    {
                                        dataGridView1.Rows[i].Cells["colReason"].Value = ret.Message;
                                    }
                                }
                                frm.ShowProgress(string.Format("导入{0}条数据 成功{1}条 失败{2}条", count, success, count - success), (decimal)(count) / total);
                            }
                        }
                        catch (Exception ex)
                        {
                            LJH.GeneralLibrary.ExceptionHandling.ExceptionPolicy.HandleException(ex);
                        }
                    }
                    frm.ShowProgress(string.Empty, 1);
                }
                catch (ThreadAbortException)
                {
                }
            };

            Thread t = new Thread(new ThreadStart(action));
            t.IsBackground = true;
            t.Start();
            if (frm.ShowDialog() != DialogResult.OK)
            {
                t.Abort();
            }
            MessageBox.Show(string.Format("共成功导入{0}条数据", success), "结果");
        }
        #endregion
    }
}