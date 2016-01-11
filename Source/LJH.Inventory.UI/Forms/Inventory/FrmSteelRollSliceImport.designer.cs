﻿namespace LJH.Inventory.UI.Forms.Inventory
{
    partial class FrmSteelRollSliceImport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSteelRollSliceImport));
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtFirstRow = new LJH.GeneralLibrary.WinformControl.IntergerTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblSource = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.colRowIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWareHouse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpecification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThick = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colManufacture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(570, 27);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(47, 23);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtPath
            // 
            this.txtPath.Enabled = false;
            this.txtPath.Location = new System.Drawing.Point(6, 27);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(548, 21);
            this.txtPath.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1394, 708);
            this.panel3.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtFirstRow);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.btnImport);
            this.groupBox3.Location = new System.Drawing.Point(646, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(736, 73);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "第二步 导入";
            // 
            // txtFirstRow
            // 
            this.txtFirstRow.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtFirstRow.Location = new System.Drawing.Point(76, 31);
            this.txtFirstRow.MaxValue = 10000;
            this.txtFirstRow.MinValue = 0;
            this.txtFirstRow.Name = "txtFirstRow";
            this.txtFirstRow.Size = new System.Drawing.Size(70, 21);
            this.txtFirstRow.TabIndex = 15;
            this.txtFirstRow.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "从 第";
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(152, 24);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(176, 34);
            this.btnImport.TabIndex = 13;
            this.btnImport.Text = "开始导入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPath);
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(623, 73);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "第一步 选择要导入的电子表格文件";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.lblSource);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(6, 91);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1385, 614);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "数据预览";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRowIndex,
            this.colAddDate,
            this.colWareHouse,
            this.colCategory,
            this.colSpecification,
            this.colModel,
            this.colWeight,
            this.colLength,
            this.colThick,
            this.colCount,
            this.colCustomer,
            this.colSupplier,
            this.colManufacture,
            this.colMemo,
            this.colReason});
            this.dataGridView1.Location = new System.Drawing.Point(3, 42);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 20;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1382, 572);
            this.dataGridView1.TabIndex = 116;
            // 
            // lblSource
            // 
            this.lblSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSource.AutoSize = true;
            this.lblSource.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSource.ForeColor = System.Drawing.Color.Blue;
            this.lblSource.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSource.Location = new System.Drawing.Point(1304, 24);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(44, 12);
            this.lblSource.TabIndex = 17;
            this.lblSource.Text = "条数据";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1145, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "待导入数据预览";
            // 
            // colRowIndex
            // 
            this.colRowIndex.HeaderText = "行号";
            this.colRowIndex.Name = "colRowIndex";
            this.colRowIndex.ReadOnly = true;
            this.colRowIndex.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colRowIndex.Width = 60;
            // 
            // colAddDate
            // 
            this.colAddDate.HeaderText = "入库日期";
            this.colAddDate.Name = "colAddDate";
            // 
            // colWareHouse
            // 
            this.colWareHouse.HeaderText = "仓库*";
            this.colWareHouse.Name = "colWareHouse";
            // 
            // colCategory
            // 
            this.colCategory.HeaderText = "类别*";
            this.colCategory.Name = "colCategory";
            this.colCategory.Width = 80;
            // 
            // colSpecification
            // 
            this.colSpecification.HeaderText = "规格*";
            this.colSpecification.Name = "colSpecification";
            this.colSpecification.Width = 80;
            // 
            // colModel
            // 
            this.colModel.HeaderText = "加工类别*";
            this.colModel.Name = "colModel";
            // 
            // colWeight
            // 
            dataGridViewCellStyle1.Format = "N3";
            dataGridViewCellStyle1.NullValue = null;
            this.colWeight.DefaultCellStyle = dataGridViewCellStyle1;
            this.colWeight.HeaderText = "重量";
            this.colWeight.Name = "colWeight";
            this.colWeight.Width = 85;
            // 
            // colLength
            // 
            dataGridViewCellStyle2.Format = "N3";
            dataGridViewCellStyle2.NullValue = null;
            this.colLength.DefaultCellStyle = dataGridViewCellStyle2;
            this.colLength.HeaderText = "长度";
            this.colLength.Name = "colLength";
            this.colLength.Width = 80;
            // 
            // colThick
            // 
            this.colThick.HeaderText = "厚度";
            this.colThick.Name = "colThick";
            // 
            // colCount
            // 
            this.colCount.HeaderText = "数量*";
            this.colCount.Name = "colCount";
            // 
            // colCustomer
            // 
            this.colCustomer.HeaderText = "客户*";
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.Width = 80;
            // 
            // colSupplier
            // 
            this.colSupplier.HeaderText = "供应商";
            this.colSupplier.Name = "colSupplier";
            this.colSupplier.Width = 80;
            // 
            // colManufacture
            // 
            this.colManufacture.HeaderText = "厂家";
            this.colManufacture.Name = "colManufacture";
            this.colManufacture.Width = 80;
            // 
            // colMemo
            // 
            this.colMemo.HeaderText = "备注";
            this.colMemo.Name = "colMemo";
            // 
            // colReason
            // 
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Red;
            this.colReason.DefaultCellStyle = dataGridViewCellStyle3;
            this.colReason.HeaderText = "导入状态";
            this.colReason.Name = "colReason";
            this.colReason.ReadOnly = true;
            this.colReason.Width = 150;
            // 
            // FrmSteelRollSliceImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1394, 708);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSteelRollSliceImport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "小件导入";
            this.Load += new System.EventHandler(this.FrmStudentImport_Load);
            this.panel3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private GeneralLibrary.WinformControl.IntergerTextBox txtFirstRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRowIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWareHouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpecification;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThick;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn colManufacture;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReason;
    }
}