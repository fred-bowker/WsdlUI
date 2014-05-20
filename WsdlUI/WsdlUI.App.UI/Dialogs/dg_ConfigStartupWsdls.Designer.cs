/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

namespace WsdlUI.App.UI.Dialogs
{
    partial class dg_ConfigStartupWsdls
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
       void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cb_Enabled = new System.Windows.Forms.CheckBox();
            this.txt_Wsdls = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // cb_Enabled
            // 
            this.cb_Enabled.AutoSize = true;
            this.cb_Enabled.Location = new System.Drawing.Point(12, 196);
            this.cb_Enabled.Name = "cb_Enabled";
            this.cb_Enabled.Size = new System.Drawing.Size(222, 17);
            this.cb_Enabled.TabIndex = 0;
            this.cb_Enabled.Text = "Check to load the above wsdls on startup";
            this.cb_Enabled.UseVisualStyleBackColor = true;
            // 
            // txt_Wsdls
            // 
            this.txt_Wsdls.Location = new System.Drawing.Point(12, 12);
            this.txt_Wsdls.Multiline = true;
            this.txt_Wsdls.Name = "txt_Wsdls";
            this.txt_Wsdls.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Wsdls.Size = new System.Drawing.Size(810, 159);
            this.txt_Wsdls.TabIndex = 2;
            this.txt_Wsdls.TextChanged += new System.EventHandler(this.txt_Wsdls_TextChanged);
            this.txt_Wsdls.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Wsdls_KeyPress);
            // 
            // dg_ConfigStartupWsdls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 230);
            this.Controls.Add(this.txt_Wsdls);
            this.Controls.Add(this.cb_Enabled);
            this.Name = "dg_ConfigStartupWsdls";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.dg_ConfigStartupWsdls_FormClosed);
            this.Load += new System.EventHandler(this.dg_ConfigStartupWsdls_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cb_Enabled;
        private System.Windows.Forms.TextBox txt_Wsdls;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
