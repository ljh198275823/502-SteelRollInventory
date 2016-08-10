﻿namespace LJH.Inventory.UI.Forms.Inventory
{
    partial class FrmSteelRollMaster
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblTotalWeight = new System.Windows.Forms.Label();
            this.txtCarPlate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ucDateTimeInterval1 = new LJH.Inventory.UI.Controls.UCDateTimeInterval();
            this.customerCombobox1 = new LJH.Inventory.UI.Controls.CustomerCombobox(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chk预订 = new System.Windows.Forms.CheckBox();
            this.chk待发货 = new System.Windows.Forms.CheckBox();
            this.chk在库 = new System.Windows.Forms.CheckBox();
            this.chk作废 = new System.Windows.Forms.CheckBox();
            this.chk发货 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.categoryComboBox1 = new LJH.Inventory.UI.Controls.CategoryComboBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.wareHouseComboBox1 = new LJH.Inventory.UI.Controls.WareHouseComboBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbBrand = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbSpecification = new LJH.Inventory.UI.Controls.SpecificationComboBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.chkStackIn = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colAddDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWareHouse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpecification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOriginalWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOriginalLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colManufacture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCarplate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPurchasePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTransCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOtherCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeliverySheet = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cMnu_Fresh = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.预订ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.取消预订ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnu_Check = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_CheckView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_Nullify = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cMnu_SelectColumns = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_Export = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_Import = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.pnlFilter.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.panel5);
            this.pnlFilter.Controls.Add(this.panel4);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1354, 86);
            this.pnlFilter.TabIndex = 112;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblTotalWeight);
            this.panel5.Controls.Add(this.txtCarPlate);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.ucDateTimeInterval1);
            this.panel5.Controls.Add(this.customerCombobox1);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.panel2);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.categoryComboBox1);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.wareHouseComboBox1);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.cmbSupplier);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.cmbBrand);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.cmbSpecification);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.chkStackIn);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(1, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1353, 86);
            this.panel5.TabIndex = 7;
            // 
            // lblTotalWeight
            // 
            this.lblTotalWeight.AutoSize = true;
            this.lblTotalWeight.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalWeight.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalWeight.Location = new System.Drawing.Point(1054, 45);
            this.lblTotalWeight.Name = "lblTotalWeight";
            this.lblTotalWeight.Size = new System.Drawing.Size(0, 35);
            this.lblTotalWeight.TabIndex = 95;
            // 
            // txtCarPlate
            // 
            this.txtCarPlate.Location = new System.Drawing.Point(897, 50);
            this.txtCarPlate.Name = "txtCarPlate";
            this.txtCarPlate.Size = new System.Drawing.Size(140, 21);
            this.txtCarPlate.TabIndex = 94;
            this.txtCarPlate.TextChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(850, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 93;
            this.label2.Text = "车皮号";
            // 
            // ucDateTimeInterval1
            // 
            this.ucDateTimeInterval1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucDateTimeInterval1.EndDateTime = new System.DateTime(2015, 11, 19, 10, 3, 12, 722);
            this.ucDateTimeInterval1.Location = new System.Drawing.Point(602, 7);
            this.ucDateTimeInterval1.Name = "ucDateTimeInterval1";
            this.ucDateTimeInterval1.ShowTime = true;
            this.ucDateTimeInterval1.Size = new System.Drawing.Size(221, 74);
            this.ucDateTimeInterval1.StartDateTime = new System.DateTime(2015, 11, 19, 10, 3, 12, 722);
            this.ucDateTimeInterval1.TabIndex = 92;
            this.ucDateTimeInterval1.ValueChanged += new System.EventHandler(this.ucDateTimeInterval1_ValueChanged);
            // 
            // customerCombobox1
            // 
            this.customerCombobox1.FormattingEnabled = true;
            this.customerCombobox1.Location = new System.Drawing.Point(384, 46);
            this.customerCombobox1.Name = "customerCombobox1";
            this.customerCombobox1.Size = new System.Drawing.Size(121, 20);
            this.customerCombobox1.TabIndex = 91;
            this.customerCombobox1.TextChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(352, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 90;
            this.label8.Text = "客户";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.chk预订);
            this.panel2.Controls.Add(this.chk待发货);
            this.panel2.Controls.Add(this.chk在库);
            this.panel2.Controls.Add(this.chk作废);
            this.panel2.Controls.Add(this.chk发货);
            this.panel2.Location = new System.Drawing.Point(897, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(311, 24);
            this.panel2.TabIndex = 89;
            // 
            // chk预订
            // 
            this.chk预订.AutoSize = true;
            this.chk预订.Checked = true;
            this.chk预订.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk预订.Location = new System.Drawing.Point(116, 3);
            this.chk预订.Name = "chk预订";
            this.chk预订.Size = new System.Drawing.Size(48, 16);
            this.chk预订.TabIndex = 54;
            this.chk预订.Text = "预订";
            this.chk预订.UseVisualStyleBackColor = true;
            // 
            // chk待发货
            // 
            this.chk待发货.AutoSize = true;
            this.chk待发货.Checked = true;
            this.chk待发货.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk待发货.Location = new System.Drawing.Point(53, 4);
            this.chk待发货.Name = "chk待发货";
            this.chk待发货.Size = new System.Drawing.Size(60, 16);
            this.chk待发货.TabIndex = 53;
            this.chk待发货.Text = "待发货";
            this.chk待发货.UseVisualStyleBackColor = true;
            this.chk待发货.CheckedChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // chk在库
            // 
            this.chk在库.AutoSize = true;
            this.chk在库.Checked = true;
            this.chk在库.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk在库.Location = new System.Drawing.Point(2, 4);
            this.chk在库.Name = "chk在库";
            this.chk在库.Size = new System.Drawing.Size(48, 16);
            this.chk在库.TabIndex = 52;
            this.chk在库.Text = "在库";
            this.chk在库.UseVisualStyleBackColor = true;
            this.chk在库.CheckedChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // chk作废
            // 
            this.chk作废.AutoSize = true;
            this.chk作废.Location = new System.Drawing.Point(234, 4);
            this.chk作废.Name = "chk作废";
            this.chk作废.Size = new System.Drawing.Size(60, 16);
            this.chk作废.TabIndex = 50;
            this.chk作废.Text = "已作废";
            this.chk作废.UseVisualStyleBackColor = true;
            this.chk作废.CheckedChanged += new System.EventHandler(this.chk发货_CheckedChanged);
            // 
            // chk发货
            // 
            this.chk发货.AutoSize = true;
            this.chk发货.Location = new System.Drawing.Point(168, 4);
            this.chk发货.Name = "chk发货";
            this.chk发货.Size = new System.Drawing.Size(60, 16);
            this.chk发货.TabIndex = 51;
            this.chk发货.Text = "已发货";
            this.chk发货.UseVisualStyleBackColor = true;
            this.chk发货.CheckedChanged += new System.EventHandler(this.chk发货_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(838, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 88;
            this.label7.Text = "库存状态";
            // 
            // categoryComboBox1
            // 
            this.categoryComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryComboBox1.FormattingEnabled = true;
            this.categoryComboBox1.Location = new System.Drawing.Point(216, 14);
            this.categoryComboBox1.Name = "categoryComboBox1";
            this.categoryComboBox1.Size = new System.Drawing.Size(121, 20);
            this.categoryComboBox1.TabIndex = 85;
            this.categoryComboBox1.SelectedIndexChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(182, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 84;
            this.label1.Text = "类别";
            // 
            // wareHouseComboBox1
            // 
            this.wareHouseComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wareHouseComboBox1.FormattingEnabled = true;
            this.wareHouseComboBox1.Location = new System.Drawing.Point(57, 14);
            this.wareHouseComboBox1.Name = "wareHouseComboBox1";
            this.wareHouseComboBox1.Size = new System.Drawing.Size(112, 20);
            this.wareHouseComboBox1.TabIndex = 83;
            this.wareHouseComboBox1.SelectedIndexChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 81;
            this.label4.Text = "仓库";
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Items.AddRange(new object[] {
            "",
            "一冷扎",
            "二冷扎"});
            this.cmbSupplier.Location = new System.Drawing.Point(57, 46);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(112, 20);
            this.cmbSupplier.TabIndex = 80;
            this.cmbSupplier.SelectedIndexChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 79;
            this.label3.Text = "供应商";
            // 
            // cmbBrand
            // 
            this.cmbBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Location = new System.Drawing.Point(216, 46);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(121, 20);
            this.cmbBrand.TabIndex = 78;
            this.cmbBrand.SelectedIndexChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(182, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 77;
            this.label9.Text = "厂家";
            // 
            // cmbSpecification
            // 
            this.cmbSpecification.FormattingEnabled = true;
            this.cmbSpecification.Location = new System.Drawing.Point(384, 14);
            this.cmbSpecification.Name = "cmbSpecification";
            this.cmbSpecification.Size = new System.Drawing.Size(121, 20);
            this.cmbSpecification.TabIndex = 76;
            this.cmbSpecification.TextChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(352, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 75;
            this.label5.Text = "规格";
            // 
            // chkStackIn
            // 
            this.chkStackIn.AutoSize = true;
            this.chkStackIn.Location = new System.Drawing.Point(527, 15);
            this.chkStackIn.Name = "chkStackIn";
            this.chkStackIn.Size = new System.Drawing.Size(72, 16);
            this.chkStackIn.TabIndex = 44;
            this.chkStackIn.Text = "入库日期";
            this.chkStackIn.UseVisualStyleBackColor = true;
            this.chkStackIn.CheckedChanged += new System.EventHandler(this.FreshData_Clicked);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1, 86);
            this.panel4.TabIndex = 6;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAddDate,
            this.colWareHouse,
            this.colCategory,
            this.colSpecification,
            this.colOriginalWeight,
            this.colOriginalLength,
            this.colWeight,
            this.colLength,
            this.colCustomer,
            this.colSupplier,
            this.colManufacture,
            this.colSerialNumber,
            this.colCarplate,
            this.colMaterial,
            this.colPurchasePrice,
            this.colTransCost,
            this.colOtherCost,
            this.colState,
            this.colDeliverySheet,
            this.colMemo});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 86);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 20;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1354, 521);
            this.dataGridView1.TabIndex = 115;
            // 
            // colAddDate
            // 
            this.colAddDate.HeaderText = "入库日期";
            this.colAddDate.Name = "colAddDate";
            this.colAddDate.ReadOnly = true;
            this.colAddDate.Width = 120;
            // 
            // colWareHouse
            // 
            this.colWareHouse.HeaderText = "仓库";
            this.colWareHouse.Name = "colWareHouse";
            this.colWareHouse.ReadOnly = true;
            this.colWareHouse.Width = 120;
            // 
            // colCategory
            // 
            this.colCategory.HeaderText = "类别";
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            this.colCategory.Width = 80;
            // 
            // colSpecification
            // 
            this.colSpecification.HeaderText = "规格";
            this.colSpecification.Name = "colSpecification";
            this.colSpecification.ReadOnly = true;
            // 
            // colOriginalWeight
            // 
            dataGridViewCellStyle1.Format = "N3";
            dataGridViewCellStyle1.NullValue = null;
            this.colOriginalWeight.DefaultCellStyle = dataGridViewCellStyle1;
            this.colOriginalWeight.HeaderText = "入库重量";
            this.colOriginalWeight.Name = "colOriginalWeight";
            this.colOriginalWeight.ReadOnly = true;
            this.colOriginalWeight.Visible = false;
            this.colOriginalWeight.Width = 80;
            // 
            // colOriginalLength
            // 
            dataGridViewCellStyle2.Format = "N3";
            dataGridViewCellStyle2.NullValue = null;
            this.colOriginalLength.DefaultCellStyle = dataGridViewCellStyle2;
            this.colOriginalLength.HeaderText = "入库长度";
            this.colOriginalLength.Name = "colOriginalLength";
            this.colOriginalLength.ReadOnly = true;
            this.colOriginalLength.Visible = false;
            // 
            // colWeight
            // 
            dataGridViewCellStyle3.Format = "N3";
            dataGridViewCellStyle3.NullValue = null;
            this.colWeight.DefaultCellStyle = dataGridViewCellStyle3;
            this.colWeight.HeaderText = "重量";
            this.colWeight.Name = "colWeight";
            this.colWeight.ReadOnly = true;
            this.colWeight.Width = 80;
            // 
            // colLength
            // 
            dataGridViewCellStyle4.Format = "N3";
            dataGridViewCellStyle4.NullValue = null;
            this.colLength.DefaultCellStyle = dataGridViewCellStyle4;
            this.colLength.HeaderText = "长度";
            this.colLength.Name = "colLength";
            this.colLength.ReadOnly = true;
            this.colLength.Visible = false;
            // 
            // colCustomer
            // 
            this.colCustomer.HeaderText = "客户";
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.ReadOnly = true;
            // 
            // colSupplier
            // 
            this.colSupplier.HeaderText = "供应商";
            this.colSupplier.Name = "colSupplier";
            this.colSupplier.ReadOnly = true;
            // 
            // colManufacture
            // 
            this.colManufacture.HeaderText = "厂家";
            this.colManufacture.Name = "colManufacture";
            this.colManufacture.ReadOnly = true;
            // 
            // colSerialNumber
            // 
            this.colSerialNumber.HeaderText = "卷号";
            this.colSerialNumber.Name = "colSerialNumber";
            this.colSerialNumber.ReadOnly = true;
            this.colSerialNumber.Width = 80;
            // 
            // colCarplate
            // 
            this.colCarplate.HeaderText = "车皮号";
            this.colCarplate.Name = "colCarplate";
            this.colCarplate.ReadOnly = true;
            // 
            // colMaterial
            // 
            this.colMaterial.HeaderText = "材质";
            this.colMaterial.Name = "colMaterial";
            this.colMaterial.ReadOnly = true;
            // 
            // colPurchasePrice
            // 
            dataGridViewCellStyle5.Format = "C2";
            this.colPurchasePrice.DefaultCellStyle = dataGridViewCellStyle5;
            this.colPurchasePrice.HeaderText = "出厂价格";
            this.colPurchasePrice.Name = "colPurchasePrice";
            this.colPurchasePrice.ReadOnly = true;
            // 
            // colTransCost
            // 
            dataGridViewCellStyle6.Format = "C2";
            this.colTransCost.DefaultCellStyle = dataGridViewCellStyle6;
            this.colTransCost.HeaderText = "运输费用";
            this.colTransCost.Name = "colTransCost";
            this.colTransCost.ReadOnly = true;
            // 
            // colOtherCost
            // 
            dataGridViewCellStyle7.Format = "C2";
            this.colOtherCost.DefaultCellStyle = dataGridViewCellStyle7;
            this.colOtherCost.HeaderText = "其它费用";
            this.colOtherCost.Name = "colOtherCost";
            this.colOtherCost.ReadOnly = true;
            // 
            // colState
            // 
            this.colState.HeaderText = "库存状态";
            this.colState.Name = "colState";
            this.colState.ReadOnly = true;
            // 
            // colDeliverySheet
            // 
            this.colDeliverySheet.HeaderText = "送货单";
            this.colDeliverySheet.Name = "colDeliverySheet";
            this.colDeliverySheet.ReadOnly = true;
            this.colDeliverySheet.Width = 125;
            // 
            // colMemo
            // 
            this.colMemo.HeaderText = "备注";
            this.colMemo.Name = "colMemo";
            this.colMemo.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cMnu_Fresh,
            this.cMnu_Add,
            this.toolStripSeparator1,
            this.预订ToolStripMenuItem,
            this.取消预订ToolStripMenuItem,
            this.toolStripSeparator2,
            this.mnu_Check,
            this.mnu_CheckView,
            this.mnu_Nullify,
            this.toolStripSeparator3,
            this.cMnu_SelectColumns,
            this.cMnu_Export,
            this.mnu_Import});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 264);
            // 
            // cMnu_Fresh
            // 
            this.cMnu_Fresh.Name = "cMnu_Fresh";
            this.cMnu_Fresh.Size = new System.Drawing.Size(152, 22);
            this.cMnu_Fresh.Text = "刷新";
            // 
            // cMnu_Add
            // 
            this.cMnu_Add.Name = "cMnu_Add";
            this.cMnu_Add.Size = new System.Drawing.Size(152, 22);
            this.cMnu_Add.Text = "新建";
            // 
            // 预订ToolStripMenuItem
            // 
            this.预订ToolStripMenuItem.Name = "预订ToolStripMenuItem";
            this.预订ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.预订ToolStripMenuItem.Text = "预订";
            this.预订ToolStripMenuItem.Click += new System.EventHandler(this.预订ToolStripMenuItem_Click);
            // 
            // 取消预订ToolStripMenuItem
            // 
            this.取消预订ToolStripMenuItem.Name = "取消预订ToolStripMenuItem";
            this.取消预订ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.取消预订ToolStripMenuItem.Text = "取消预订";
            this.取消预订ToolStripMenuItem.Click += new System.EventHandler(this.取消预订ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // mnu_Check
            // 
            this.mnu_Check.Name = "mnu_Check";
            this.mnu_Check.Size = new System.Drawing.Size(152, 22);
            this.mnu_Check.Text = "盘点";
            this.mnu_Check.Click += new System.EventHandler(this.mnu_Check_Click);
            // 
            // mnu_CheckView
            // 
            this.mnu_CheckView.Name = "mnu_CheckView";
            this.mnu_CheckView.Size = new System.Drawing.Size(152, 22);
            this.mnu_CheckView.Text = "查看盘点记录";
            this.mnu_CheckView.Click += new System.EventHandler(this.mnu_CheckView_Click);
            // 
            // mnu_Nullify
            // 
            this.mnu_Nullify.Name = "mnu_Nullify";
            this.mnu_Nullify.Size = new System.Drawing.Size(152, 22);
            this.mnu_Nullify.Text = "作废";
            this.mnu_Nullify.Click += new System.EventHandler(this.mnu_Nullify_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // cMnu_SelectColumns
            // 
            this.cMnu_SelectColumns.Name = "cMnu_SelectColumns";
            this.cMnu_SelectColumns.Size = new System.Drawing.Size(152, 22);
            this.cMnu_SelectColumns.Text = "选择列...";
            // 
            // cMnu_Export
            // 
            this.cMnu_Export.Name = "cMnu_Export";
            this.cMnu_Export.Size = new System.Drawing.Size(152, 22);
            this.cMnu_Export.Text = "导出...";
            // 
            // mnu_Import
            // 
            this.mnu_Import.Name = "mnu_Import";
            this.mnu_Import.Size = new System.Drawing.Size(152, 22);
            this.mnu_Import.Text = "导入...";
            this.mnu_Import.Click += new System.EventHandler(this.mnu_Import_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // FrmSteelRollMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1354, 629);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pnlFilter);
            this.Name = "FrmSteelRollMaster";
            this.Text = "原材料管理";
            this.Controls.SetChildIndex(this.pnlFilter, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.pnlFilter.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Fresh;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Add;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cMnu_SelectColumns;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Export;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ToolStripMenuItem mnu_Nullify;
        private System.Windows.Forms.CheckBox chkStackIn;
        private Controls.SpecificationComboBox cmbSpecification;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbBrand;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private Controls.WareHouseComboBox wareHouseComboBox1;
        private Controls.CategoryComboBox categoryComboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chk作废;
        private System.Windows.Forms.CheckBox chk发货;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private Controls.CustomerCombobox customerCombobox1;
        private Controls.UCDateTimeInterval ucDateTimeInterval1;
        private System.Windows.Forms.ToolStripMenuItem mnu_Import;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnu_Check;
        private System.Windows.Forms.ToolStripMenuItem mnu_CheckView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCarPlate;
        private System.Windows.Forms.Label lblTotalWeight;
        private System.Windows.Forms.CheckBox chk待发货;
        private System.Windows.Forms.CheckBox chk在库;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWareHouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpecification;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOriginalWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOriginalLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn colManufacture;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCarplate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPurchasePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTransCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOtherCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colState;
        private System.Windows.Forms.DataGridViewLinkColumn colDeliverySheet;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemo;
        private System.Windows.Forms.ToolStripMenuItem 预订ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 取消预订ToolStripMenuItem;
        private System.Windows.Forms.CheckBox chk预订;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}