﻿namespace LJH.Inventory.UI.Forms.Inventory
{
    partial class FrmSteelRollSliceMaster
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLength = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.txtWeight = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.chk开条 = new System.Windows.Forms.CheckBox();
            this.chk开吨 = new System.Windows.Forms.CheckBox();
            this.chk开平 = new System.Windows.Forms.CheckBox();
            this.categoryComboBox1 = new LJH.Inventory.UI.Controls.CategoryComboBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSpecification = new LJH.Inventory.UI.Controls.SpecificationComboBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cMnu_Fresh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_CreateInventory = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_CheckView = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cMnu_SelectColumns = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_Export = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpecification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWaitShipping = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colValid = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewLinkColumn();
            this.mnu_Import = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlFilter.SuspendLayout();
            this.panel5.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.panel5);
            this.pnlFilter.Controls.Add(this.panel4);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1219, 38);
            this.pnlFilter.TabIndex = 112;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.txtLength);
            this.panel5.Controls.Add(this.txtWeight);
            this.panel5.Controls.Add(this.chk开条);
            this.panel5.Controls.Add(this.chk开吨);
            this.panel5.Controls.Add(this.chk开平);
            this.panel5.Controls.Add(this.categoryComboBox1);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.cmbSpecification);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(1, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1218, 38);
            this.panel5.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(661, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 89;
            this.label4.Text = "长度";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(535, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 88;
            this.label3.Text = "重量";
            // 
            // txtLength
            // 
            this.txtLength.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtLength.Location = new System.Drawing.Point(696, 10);
            this.txtLength.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtLength.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtLength.Name = "txtLength";
            this.txtLength.PointCount = 2;
            this.txtLength.Size = new System.Drawing.Size(72, 21);
            this.txtLength.TabIndex = 87;
            this.txtLength.Text = "0";
            this.txtLength.TextChanged += new System.EventHandler(this.FreshDate_Clicked);
            // 
            // txtWeight
            // 
            this.txtWeight.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtWeight.Location = new System.Drawing.Point(570, 10);
            this.txtWeight.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtWeight.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.PointCount = 3;
            this.txtWeight.Size = new System.Drawing.Size(81, 21);
            this.txtWeight.TabIndex = 86;
            this.txtWeight.Text = "0";
            this.txtWeight.TextChanged += new System.EventHandler(this.FreshDate_Clicked);
            // 
            // chk开条
            // 
            this.chk开条.AutoSize = true;
            this.chk开条.Checked = true;
            this.chk开条.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk开条.Location = new System.Drawing.Point(408, 12);
            this.chk开条.Name = "chk开条";
            this.chk开条.Size = new System.Drawing.Size(48, 16);
            this.chk开条.TabIndex = 85;
            this.chk开条.Text = "开条";
            this.chk开条.UseVisualStyleBackColor = true;
            this.chk开条.CheckedChanged += new System.EventHandler(this.FreshDate_Clicked);
            // 
            // chk开吨
            // 
            this.chk开吨.AutoSize = true;
            this.chk开吨.Checked = true;
            this.chk开吨.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk开吨.Location = new System.Drawing.Point(463, 12);
            this.chk开吨.Name = "chk开吨";
            this.chk开吨.Size = new System.Drawing.Size(48, 16);
            this.chk开吨.TabIndex = 84;
            this.chk开吨.Text = "开吨";
            this.chk开吨.UseVisualStyleBackColor = true;
            this.chk开吨.CheckedChanged += new System.EventHandler(this.FreshDate_Clicked);
            // 
            // chk开平
            // 
            this.chk开平.AutoSize = true;
            this.chk开平.Checked = true;
            this.chk开平.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk开平.Location = new System.Drawing.Point(354, 12);
            this.chk开平.Name = "chk开平";
            this.chk开平.Size = new System.Drawing.Size(48, 16);
            this.chk开平.TabIndex = 83;
            this.chk开平.Text = "开平";
            this.chk开平.UseVisualStyleBackColor = true;
            this.chk开平.CheckedChanged += new System.EventHandler(this.FreshDate_Clicked);
            // 
            // categoryComboBox1
            // 
            this.categoryComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryComboBox1.FormattingEnabled = true;
            this.categoryComboBox1.Location = new System.Drawing.Point(56, 10);
            this.categoryComboBox1.Name = "categoryComboBox1";
            this.categoryComboBox1.Size = new System.Drawing.Size(121, 20);
            this.categoryComboBox1.TabIndex = 82;
            this.categoryComboBox1.SelectedIndexChanged += new System.EventHandler(this.FreshDate_Clicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 81;
            this.label2.Text = "类别";
            // 
            // cmbSpecification
            // 
            this.cmbSpecification.FormattingEnabled = true;
            this.cmbSpecification.Location = new System.Drawing.Point(217, 10);
            this.cmbSpecification.Name = "cmbSpecification";
            this.cmbSpecification.Size = new System.Drawing.Size(121, 20);
            this.cmbSpecification.TabIndex = 80;
            this.cmbSpecification.TextChanged += new System.EventHandler(this.FreshDate_Clicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(185, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 79;
            this.label5.Text = "规格";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1, 38);
            this.panel4.TabIndex = 6;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cMnu_Fresh,
            this.mnu_CreateInventory,
            this.mnu_CheckView,
            this.toolStripSeparator3,
            this.cMnu_SelectColumns,
            this.cMnu_Export,
            this.mnu_Import});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 164);
            // 
            // cMnu_Fresh
            // 
            this.cMnu_Fresh.Name = "cMnu_Fresh";
            this.cMnu_Fresh.Size = new System.Drawing.Size(152, 22);
            this.cMnu_Fresh.Text = "刷新";
            // 
            // mnu_CreateInventory
            // 
            this.mnu_CreateInventory.Name = "mnu_CreateInventory";
            this.mnu_CreateInventory.Size = new System.Drawing.Size(152, 22);
            this.mnu_CreateInventory.Text = "新建库存";
            this.mnu_CreateInventory.Click += new System.EventHandler(this.mnu_CreateInventory_Click);
            // 
            // mnu_CheckView
            // 
            this.mnu_CheckView.Name = "mnu_CheckView";
            this.mnu_CheckView.Size = new System.Drawing.Size(152, 22);
            this.mnu_CheckView.Text = "查看盘点记录";
            this.mnu_CheckView.Click += new System.EventHandler(this.mnu_CheckView_Click);
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
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colImage,
            this.colCategory,
            this.colSpecification,
            this.colModel,
            this.colWeight,
            this.colLength,
            this.colWaitShipping,
            this.colValid,
            this.colTotal});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 38);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1219, 334);
            this.dataGridView1.TabIndex = 115;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // colImage
            // 
            this.colImage.HeaderText = "";
            this.colImage.Name = "colImage";
            this.colImage.ReadOnly = true;
            this.colImage.Width = 30;
            // 
            // colCategory
            // 
            this.colCategory.HeaderText = "产品类别";
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            // 
            // colSpecification
            // 
            this.colSpecification.HeaderText = "规格";
            this.colSpecification.Name = "colSpecification";
            this.colSpecification.ReadOnly = true;
            // 
            // colModel
            // 
            this.colModel.HeaderText = "加工类型";
            this.colModel.Name = "colModel";
            this.colModel.ReadOnly = true;
            // 
            // colWeight
            // 
            dataGridViewCellStyle1.Format = "N3";
            this.colWeight.DefaultCellStyle = dataGridViewCellStyle1;
            this.colWeight.HeaderText = "重量(吨)";
            this.colWeight.Name = "colWeight";
            this.colWeight.ReadOnly = true;
            // 
            // colLength
            // 
            dataGridViewCellStyle2.Format = "N3";
            this.colLength.DefaultCellStyle = dataGridViewCellStyle2;
            this.colLength.HeaderText = "长度(米)";
            this.colLength.Name = "colLength";
            this.colLength.ReadOnly = true;
            // 
            // colWaitShipping
            // 
            dataGridViewCellStyle3.Format = "N0";
            this.colWaitShipping.DefaultCellStyle = dataGridViewCellStyle3;
            this.colWaitShipping.HeaderText = "待发货";
            this.colWaitShipping.Name = "colWaitShipping";
            this.colWaitShipping.ReadOnly = true;
            // 
            // colValid
            // 
            dataGridViewCellStyle4.Format = "N0";
            this.colValid.DefaultCellStyle = dataGridViewCellStyle4;
            this.colValid.HeaderText = "可用库存";
            this.colValid.Name = "colValid";
            this.colValid.ReadOnly = true;
            this.colValid.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colValid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colTotal
            // 
            dataGridViewCellStyle5.Format = "N0";
            this.colTotal.DefaultCellStyle = dataGridViewCellStyle5;
            this.colTotal.HeaderText = "库存合计";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            this.colTotal.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // mnu_Import
            // 
            this.mnu_Import.Name = "mnu_Import";
            this.mnu_Import.Size = new System.Drawing.Size(152, 22);
            this.mnu_Import.Text = "导入...";
            this.mnu_Import.Click += new System.EventHandler(this.mnu_Import_Click);
            // 
            // FrmSteelRollSliceMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1219, 394);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pnlFilter);
            this.Name = "FrmSteelRollSliceMaster";
            this.Text = "小件管理";
            this.Controls.SetChildIndex(this.pnlFilter, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.pnlFilter.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Fresh;
        private System.Windows.Forms.ToolStripMenuItem mnu_CreateInventory;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cMnu_SelectColumns;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Export;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private Controls.SpecificationComboBox cmbSpecification;
        private System.Windows.Forms.Label label5;
        private Controls.CategoryComboBox categoryComboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox chk开条;
        private System.Windows.Forms.CheckBox chk开吨;
        private System.Windows.Forms.CheckBox chk开平;
        private System.Windows.Forms.ToolStripMenuItem mnu_CheckView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private GeneralLibrary.WinformControl.DecimalTextBox txtLength;
        private GeneralLibrary.WinformControl.DecimalTextBox txtWeight;
        private System.Windows.Forms.DataGridViewImageColumn colImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpecification;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLength;
        private System.Windows.Forms.DataGridViewLinkColumn colWaitShipping;
        private System.Windows.Forms.DataGridViewLinkColumn colValid;
        private System.Windows.Forms.DataGridViewLinkColumn colTotal;
        private System.Windows.Forms.ToolStripMenuItem mnu_Import;
    }
}