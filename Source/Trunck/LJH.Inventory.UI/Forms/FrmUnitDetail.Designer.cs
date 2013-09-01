﻿namespace LJH.Inventory.UI.Forms
{
    partial class FrmUnitDetail
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
            this.txtPlural = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.txtMemo = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtID = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(295, 130);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(186, 130);
            // 
            // txtPlural
            // 
            this.txtPlural.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtPlural.Location = new System.Drawing.Point(54, 39);
            this.txtPlural.Name = "txtPlural";
            this.txtPlural.Size = new System.Drawing.Size(119, 21);
            this.txtPlural.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 39;
            this.label5.Text = "复数：";
            // 
            // txtMemo
            // 
            this.txtMemo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtMemo.Location = new System.Drawing.Point(53, 70);
            this.txtMemo.Multiline = true;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(319, 43);
            this.txtMemo.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 36;
            this.label2.Text = "备注：";
            // 
            // txtName
            // 
            this.txtName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtName.Location = new System.Drawing.Point(253, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(119, 21);
            this.txtName.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(194, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 35;
            this.label3.Text = "中文名称：";
            // 
            // txtID
            // 
            this.txtID.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtID.Location = new System.Drawing.Point(53, 12);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(119, 21);
            this.txtID.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 34;
            this.label1.Text = "名称：";
            // 
            // FrmUnitDetail
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(382, 165);
            this.Controls.Add(this.txtPlural);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMemo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label1);
            this.Name = "FrmUnitDetail";
            this.Text = "计量单位明细";
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtID, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtMemo, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtPlural, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GeneralLibrary.WinformControl.DBCTextBox txtPlural;
        private System.Windows.Forms.Label label5;
        private GeneralLibrary.WinformControl.DBCTextBox txtMemo;
        private System.Windows.Forms.Label label2;
        private GeneralLibrary.WinformControl.DBCTextBox txtName;
        private System.Windows.Forms.Label label3;
        private GeneralLibrary.WinformControl.DBCTextBox txtID;
        private System.Windows.Forms.Label label1;
    }
}