﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using NPOI;
using NPOI.HPSF;
using NPOI.HSSF;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.Resource;
using LJH.Inventory.BLL;
using LJH.GeneralLibrary;

namespace LJH.Inventory.UI.Forms.Inventory.Print
{
    /// <summary>
    /// 表示一个送货单导出电子表格类
    /// </summary>
    public class StackOutSheetExporter
    {
        public StackOutSheetExporter(string modalPath)
        {
            modal = modalPath;
        }

        /// <summary>
        /// 获取或设置EXCEL模板的路径
        /// </summary>
        public string modal;

        /// <summary>
        /// 导出操作员当班信息到EXCEL中
        /// </summary>
        /// <param name="optLog"></param>
        public void Export(StackOutSheet info, string path)
        {
            using (FileStream fs = new FileStream(modal, FileMode.Open, FileAccess.Read))
            {
                IWorkbook wb = WorkbookFactory.Create(fs);
                ISheet sheet = wb.GetSheetAt(0);
                IRow row = sheet.GetRow(1);
                if (row != null)
                {
                    ICell cell = row.GetCell(1);
                    if (cell != null) cell.SetCellValue(info.ID);
                    cell = row.GetCell(4);
                    if (cell != null) cell.SetCellValue(info.State == BusinessModel.SheetState.Shipped ? info.LastActiveDate.ToString("yyyy-MM-dd") : DateTime.Today.ToString("yyyy-MM-dd"));
                }
                row = sheet.GetRow(2);
                if (row != null)
                {
                    CompanyInfo customer = new CompanyBLL(AppSettings.Current.ConnStr).GetByID(info.CustomerID).QueryObject;
                    ICell cell = row.GetCell(1);
                    if (cell != null) cell.SetCellValue(customer != null ? customer.Name : info.CustomerID);
                    cell = row.GetCell(4);
                    if (cell != null) cell.SetCellValue(info.Linker);
                    cell = row.GetCell(7);
                    if (cell != null) cell.SetCellValue(info.LinkerCall);
                }
                row = sheet.GetRow(3);
                if (row != null)
                {
                    ICell cell = row.GetCell(1);
                    if (cell != null) cell.SetCellValue(info.Driver );
                    cell = row.GetCell(4);
                    if (cell != null) cell.SetCellValue(info.DriverCall );
                    cell = row.GetCell(7);
                    if (cell != null) cell.SetCellValue(info.CarPlate );
                }
                row = sheet.GetRow(4);
                if (row != null)
                {
                    ICell cell = row.GetCell(1);
                    if (cell != null) cell.SetCellValue(info.Address);
                    cell = row.GetCell(7);
                    if (cell != null) cell.SetCellValue(info.WithTax  ? "KP" : "BK");
                }
                row = sheet.GetRow(5);
                if (row != null)
                {
                    //ICell cell = row.GetCell(1);
                    //if (cell != null) cell.SetCellValue(info.Driver);
                    //cell = row.GetCell(4);
                    //if (cell != null) cell.SetCellValue(info.DriverCall);
                    //cell = row.GetCell(7);
                    //if (cell != null) cell.SetCellValue(info.CarPlate);
                }

                var items = info.GetSummaryItems();
                int rowIndex=7;
                foreach (var item in items)
                {
                    if (rowIndex < 15)
                    {
                        row = sheet.GetRow(rowIndex);
                        if (row != null)
                        {
                            var p = new ProductBLL(AppSettings.Current.ConnStr).GetByID(item.ProductID).QueryObject;
                            ICell cell = row.GetCell(0);
                            if (cell != null) cell.SetCellValue(p.Category.Name);
                            cell = row.GetCell(1);
                            if (cell != null) cell.SetCellValue(p.Specification);
                            cell = row.GetCell(2);
                            if (cell != null) cell.SetCellValue(p.Length.HasValue ? p.Length.Value.ToString("F2") : string.Empty);
                            cell = row.GetCell(3);
                            if (cell != null) cell.SetCellValue(item.Count.ToString("F0"));
                            cell = row.GetCell(4);
                            if (cell != null) cell.SetCellValue(item.TotalWeight.HasValue ? item.TotalWeight.Value.ToString("F3") : (p.Weight.HasValue ? p.Weight.Value.ToString("F3") : string.Empty));
                            cell = row.GetCell(5);
                            if (cell != null) cell.SetCellValue(p.Model);
                            cell = row.GetCell(6);
                            if (cell != null) cell.SetCellValue((Double)item.Price);
                            cell = row.GetCell(7);
                            if (cell != null) cell.SetCellValue((Double)item.Amount);
                            cell = row.GetCell(8);
                            if (cell != null) cell.SetCellValue(item.Memo);
                        }
                    }
                    rowIndex++;
                }
                row = sheet.GetRow(15);
                if (row != null)
                {
                    ICell cell = row.GetCell(7);
                    if (cell != null) cell.SetCellValue((double)info.Amount);
                    cell = row.GetCell(2);
                    if (cell != null) cell.SetCellValue((double)info.Amount);
                }
                MemoryStream stream = new MemoryStream();
                wb.Write(stream);
                var buf = stream.ToArray();
                //保存为Excel文件
                using (FileStream fs1 = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    fs1.Write(buf, 0, buf.Length);
                    fs1.Flush();
                }
            }
        }
    }
}