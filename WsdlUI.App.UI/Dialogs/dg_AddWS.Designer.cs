/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/


namespace WsdlUI.App.UI.Dialogs
{
    partial class dg_AddWS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        public System.ComponentModel.IContainer components = null;

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
       void InitializeComponent()
        {
            this.btn_Go = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_Wsdl = new System.Windows.Forms.ComboBox();
            this.btn_FileSelect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Go
            // 
            this.btn_Go.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_Go.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Go.Image = global::WsdlUI.App.UI.Properties.Resources.arrow_right_3;
            this.btn_Go.Location = new System.Drawing.Point(789, 58);
            this.btn_Go.Name = "btn_Go";
            this.btn_Go.Size = new System.Drawing.Size(33, 23);
            this.btn_Go.TabIndex = 2;
            this.btn_Go.UseVisualStyleBackColor = true;
            this.btn_Go.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Please provide a wsdl endpoint...";
            // 
            // cb_Wsdl
            // 
            this.cb_Wsdl.FormattingEnabled = true;
            this.cb_Wsdl.Location = new System.Drawing.Point(15, 29);
            this.cb_Wsdl.Name = "cb_Wsdl";
            this.cb_Wsdl.Size = new System.Drawing.Size(768, 21);
            this.cb_Wsdl.TabIndex = 5;
            // 
            // btn_FileSelect
            // 
            this.btn_FileSelect.Image = global::WsdlUI.App.UI.Properties.Resources.folder;
            this.btn_FileSelect.Location = new System.Drawing.Point(789, 29);
            this.btn_FileSelect.Name = "btn_FileSelect";
            this.btn_FileSelect.Size = new System.Drawing.Size(33, 23);
            this.btn_FileSelect.TabIndex = 6;
            this.btn_FileSelect.UseVisualStyleBackColor = true;
            this.btn_FileSelect.Click += new System.EventHandler(this.btn_fileSelect_Click);
            // 
            // dg_AddWS
            // 
            this.AcceptButton = this.btn_Go;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 98);
            this.Controls.Add(this.btn_FileSelect);
            this.Controls.Add(this.cb_Wsdl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Go);
            this.Name = "dg_AddWS";
            this.Text = "  ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btn_Go;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_Wsdl;
        private System.Windows.Forms.Button btn_FileSelect;
    }
}
