﻿namespace LJH.Inventory.UI.Forms
{
    partial class FrmDeliverySheetDetail
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnu_AddOrderItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_AddItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_RemoveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnApprove = new System.Windows.Forms.ToolStripButton();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.btnShip = new System.Windows.Forms.ToolStripButton();
            this.btnPaid = new System.Windows.Forms.ToolStripButton();
            this.btnPaymentAssign = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtCustomer = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnkCustomer = new System.Windows.Forms.LinkLabel();
            this.ItemsGrid = new System.Windows.Forms.DataGridView();
            this.label15 = new System.Windows.Forms.Label();
            this.txtSheetNo = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colOperateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOperation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOperator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFill = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtMemo = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.colProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpecification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtWareHouse = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnkWareHouse = new System.Windows.Forms.LinkLabel();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemsGrid)).BeginInit();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(926, 318);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(817, 318);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_AddOrderItem,
            this.btn_AddItem,
            this.mnu_RemoveItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 70);
            // 
            // mnu_AddOrderItem
            // 
            this.mnu_AddOrderItem.Name = "mnu_AddOrderItem";
            this.mnu_AddOrderItem.Size = new System.Drawing.Size(160, 22);
            this.mnu_AddOrderItem.Text = "选择销售订单项";
            this.mnu_AddOrderItem.Click += new System.EventHandler(this.mnu_AddOrderItem_Click);
            // 
            // btn_AddItem
            // 
            this.btn_AddItem.Name = "btn_AddItem";
            this.btn_AddItem.Size = new System.Drawing.Size(160, 22);
            this.btn_AddItem.Text = "选择商品";
            this.btn_AddItem.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // mnu_RemoveItem
            // 
            this.mnu_RemoveItem.Name = "mnu_RemoveItem";
            this.mnu_RemoveItem.Size = new System.Drawing.Size(160, 22);
            this.mnu_RemoveItem.Text = "删除";
            this.mnu_RemoveItem.Click += new System.EventHandler(this.mnu_Remove_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 12);
            this.label5.TabIndex = 7;
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnApprove,
            this.btnPrint,
            this.btnShip,
            this.btnPaid,
            this.btnPaymentAssign});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(788, 56);
            this.toolStrip2.TabIndex = 88;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnSave
            // 
            this.btnSave.Image = global::LJH.Inventory.UI.Properties.Resources.save;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(51, 53);
            this.btnSave.Text = "保存(&S)";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.ToolTipText = "保存(&S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnApprove
            // 
            this.btnApprove.Image = global::LJH.Inventory.UI.Properties.Resources.approve;
            this.btnApprove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(52, 53);
            this.btnApprove.Text = "审核(&A)";
            this.btnApprove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::LJH.Inventory.UI.Properties.Resources.Print_;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(51, 53);
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnShip
            // 
            this.btnShip.Image = global::LJH.Inventory.UI.Properties.Resources.shipped;
            this.btnShip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShip.Name = "btnShip";
            this.btnShip.Size = new System.Drawing.Size(53, 53);
            this.btnShip.Text = "出货(&D)";
            this.btnShip.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnPaid
            // 
            this.btnPaid.Image = global::LJH.Inventory.UI.Properties.Resources.payment;
            this.btnPaid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPaid.Name = "btnPaid";
            this.btnPaid.Size = new System.Drawing.Size(51, 53);
            this.btnPaid.Text = "收款(&P)";
            this.btnPaid.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnPaymentAssign
            // 
            this.btnPaymentAssign.Image = global::LJH.Inventory.UI.Properties.Resources.assign;
            this.btnPaymentAssign.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPaymentAssign.Name = "btnPaymentAssign";
            this.btnPaymentAssign.Size = new System.Drawing.Size(53, 53);
            this.btnPaymentAssign.Text = "核销(&G)";
            this.btnPaymentAssign.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Location = new System.Drawing.Point(7, 58);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(780, 334);
            this.tabControl1.TabIndex = 89;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtWareHouse);
            this.tabPage1.Controls.Add(this.lnkWareHouse);
            this.tabPage1.Controls.Add(this.txtMemo);
            this.tabPage1.Controls.Add(this.txtCustomer);
            this.tabPage1.Controls.Add(this.lnkCustomer);
            this.tabPage1.Controls.Add(this.ItemsGrid);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.txtSheetNo);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(772, 308);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "基本信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtCustomer
            // 
            this.txtCustomer.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCustomer.Location = new System.Drawing.Point(233, 12);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(301, 21);
            this.txtCustomer.TabIndex = 115;
            // 
            // lnkCustomer
            // 
            this.lnkCustomer.AutoSize = true;
            this.lnkCustomer.Location = new System.Drawing.Point(196, 16);
            this.lnkCustomer.Name = "lnkCustomer";
            this.lnkCustomer.Size = new System.Drawing.Size(35, 12);
            this.lnkCustomer.TabIndex = 114;
            this.lnkCustomer.TabStop = true;
            this.lnkCustomer.Text = "客户:";
            this.lnkCustomer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCustomer_LinkClicked);
            // 
            // ItemsGrid
            // 
            this.ItemsGrid.AllowDrop = true;
            this.ItemsGrid.AllowUserToAddRows = false;
            this.ItemsGrid.AllowUserToDeleteRows = false;
            this.ItemsGrid.AllowUserToResizeRows = false;
            this.ItemsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ItemsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductID,
            this.colMemo,
            this.colProductName,
            this.colSpecification,
            this.colUnit,
            this.colPrice,
            this.colCount,
            this.colTotal});
            this.ItemsGrid.ContextMenuStrip = this.contextMenuStrip1;
            this.ItemsGrid.Location = new System.Drawing.Point(16, 72);
            this.ItemsGrid.Name = "ItemsGrid";
            this.ItemsGrid.RowHeadersVisible = false;
            this.ItemsGrid.RowTemplate.Height = 23;
            this.ItemsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ItemsGrid.Size = new System.Drawing.Size(749, 231);
            this.ItemsGrid.TabIndex = 77;
            this.ItemsGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.ItemsGrid_CellEndEdit);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(17, 42);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 12);
            this.label15.TabIndex = 60;
            this.label15.Text = "备注:";
            // 
            // txtSheetNo
            // 
            this.txtSheetNo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtSheetNo.Location = new System.Drawing.Point(73, 12);
            this.txtSheetNo.Name = "txtSheetNo";
            this.txtSheetNo.Size = new System.Drawing.Size(106, 21);
            this.txtSheetNo.TabIndex = 55;
            this.txtSheetNo.Text = "自动创建";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 12);
            this.label11.TabIndex = 59;
            this.label11.Text = "送货单号:";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(772, 383);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "报关";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(772, 383);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "装箱";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(772, 383);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "运输";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(772, 383);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "退税";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(772, 383);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "相关文档";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.dataGridView1);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(772, 383);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "操作记录";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOperateDate,
            this.colOperation,
            this.colOperator,
            this.colFill});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(772, 383);
            this.dataGridView1.TabIndex = 99;
            // 
            // colOperateDate
            // 
            this.colOperateDate.HeaderText = "操作时间";
            this.colOperateDate.Name = "colOperateDate";
            this.colOperateDate.ReadOnly = true;
            this.colOperateDate.Width = 130;
            // 
            // colOperation
            // 
            this.colOperation.HeaderText = "操作";
            this.colOperation.Name = "colOperation";
            this.colOperation.ReadOnly = true;
            this.colOperation.Width = 200;
            // 
            // colOperator
            // 
            this.colOperator.HeaderText = "操作员";
            this.colOperator.Name = "colOperator";
            this.colOperator.ReadOnly = true;
            this.colOperator.Width = 150;
            // 
            // colFill
            // 
            this.colFill.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFill.HeaderText = "";
            this.colFill.Name = "colFill";
            this.colFill.ReadOnly = true;
            // 
            // txtMemo
            // 
            this.txtMemo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtMemo.Location = new System.Drawing.Point(70, 39);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(695, 21);
            this.txtMemo.TabIndex = 116;
            // 
            // colProductID
            // 
            this.colProductID.HeaderText = "商品编号";
            this.colProductID.Name = "colProductID";
            this.colProductID.ReadOnly = true;
            this.colProductID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colMemo
            // 
            this.colMemo.HeaderText = "备注";
            this.colMemo.Name = "colMemo";
            // 
            // colProductName
            // 
            this.colProductName.HeaderText = "商品名称";
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            this.colProductName.Width = 120;
            // 
            // colSpecification
            // 
            this.colSpecification.HeaderText = "规格";
            this.colSpecification.Name = "colSpecification";
            this.colSpecification.ReadOnly = true;
            this.colSpecification.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colSpecification.Width = 80;
            // 
            // colUnit
            // 
            this.colUnit.HeaderText = "单位";
            this.colUnit.Name = "colUnit";
            this.colUnit.ReadOnly = true;
            this.colUnit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colUnit.Width = 80;
            // 
            // colPrice
            // 
            dataGridViewCellStyle13.Format = "N2";
            dataGridViewCellStyle13.NullValue = null;
            this.colPrice.DefaultCellStyle = dataGridViewCellStyle13;
            this.colPrice.HeaderText = "单价";
            this.colPrice.Name = "colPrice";
            this.colPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colCount
            // 
            dataGridViewCellStyle14.Format = "N0";
            dataGridViewCellStyle14.NullValue = "0";
            this.colCount.DefaultCellStyle = dataGridViewCellStyle14;
            this.colCount.HeaderText = "数量";
            this.colCount.Name = "colCount";
            this.colCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCount.Width = 80;
            // 
            // colTotal
            // 
            dataGridViewCellStyle15.Format = "N2";
            dataGridViewCellStyle15.NullValue = null;
            this.colTotal.DefaultCellStyle = dataGridViewCellStyle15;
            this.colTotal.HeaderText = "金额";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            this.colTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colTotal.Width = 80;
            // 
            // txtWareHouse
            // 
            this.txtWareHouse.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtWareHouse.Location = new System.Drawing.Point(588, 12);
            this.txtWareHouse.Name = "txtWareHouse";
            this.txtWareHouse.Size = new System.Drawing.Size(177, 21);
            this.txtWareHouse.TabIndex = 118;
            // 
            // lnkWareHouse
            // 
            this.lnkWareHouse.AutoSize = true;
            this.lnkWareHouse.Location = new System.Drawing.Point(549, 16);
            this.lnkWareHouse.Name = "lnkWareHouse";
            this.lnkWareHouse.Size = new System.Drawing.Size(35, 12);
            this.lnkWareHouse.TabIndex = 117;
            this.lnkWareHouse.TabStop = true;
            this.lnkWareHouse.Text = "仓库:";
            this.lnkWareHouse.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkWareHouse_LinkClicked);
            // 
            // FrmDeliverySheetDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 398);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDeliverySheetDetail";
            this.Text = "送货单";
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.toolStrip2, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemsGrid)).EndInit();
            this.tabPage7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btn_AddItem;
        private System.Windows.Forms.ToolStripMenuItem mnu_RemoveItem;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnApprove;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.ToolStripButton btnShip;
        private System.Windows.Forms.ToolStripButton btnPaid;
        private System.Windows.Forms.ToolStripButton btnPaymentAssign;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView ItemsGrid;
        private System.Windows.Forms.Label label15;
        private GeneralLibrary.WinformControl.DBCTextBox txtSheetNo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperator;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFill;
        private GeneralLibrary.WinformControl.DBCTextBox txtCustomer;
        private System.Windows.Forms.LinkLabel lnkCustomer;
        private System.Windows.Forms.ToolStripMenuItem mnu_AddOrderItem;
        private GeneralLibrary.WinformControl.DBCTextBox txtMemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpecification;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private GeneralLibrary.WinformControl.DBCTextBox txtWareHouse;
        private System.Windows.Forms.LinkLabel lnkWareHouse;
    }
}