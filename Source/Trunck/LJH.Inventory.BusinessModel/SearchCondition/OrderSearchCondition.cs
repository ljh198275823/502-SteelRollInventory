﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class OrderSearchCondition : LJH.GeneralLibrary.Core.DAL.SearchCondition
    {
        public DateTimeRange OrderDate { get; set; }

        public string CustomerID { get; set; }

        public string FinalCustomerID { get; set; }

        public string Sales { get; set; }

        public bool? WithTax { get; set; }

        public List<SheetState> States { get; set; }

        public bool? HasNotPaid { get; set; }
    }
}
