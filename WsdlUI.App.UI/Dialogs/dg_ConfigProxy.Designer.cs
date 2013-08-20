/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/


namespace WsdlUI.App.UI.Dialogs
{
    partial class dg_ConfigProxy
    {

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
            this.cb_Enabled = new System.Windows.Forms.ComboBox();
            this.txt_Port = new System.Windows.Forms.TextBox();
            this.txt_Host = new System.Windows.Forms.TextBox();
            this.lbl_Port = new System.Windows.Forms.Label();
            this.lbl_Host = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // cb_Enabled
            // 
            this.cb_Enabled.FormattingEnabled = true;
            this.cb_Enabled.Items.AddRange(new object[] {
            "Enabled",
            "Disabled",
            "System"});
            this.cb_Enabled.Location = new System.Drawing.Point(87, 79);
            this.cb_Enabled.Name = "cb_Enabled";
            this.cb_Enabled.Size = new System.Drawing.Size(166, 21);
            this.cb_Enabled.TabIndex = 13;
            // 
            // txt_Port
            // 
            this.txt_Port.Location = new System.Drawing.Point(87, 43);
            this.txt_Port.Name = "txt_Port";
            this.txt_Port.Size = new System.Drawing.Size(166, 20);
            this.txt_Port.TabIndex = 12;
            // 
            // txt_Host
            // 
            this.txt_Host.Location = new System.Drawing.Point(87, 9);
            this.txt_Host.Name = "txt_Host";
            this.txt_Host.Size = new System.Drawing.Size(166, 20);
            this.txt_Host.TabIndex = 11;
            // 
            // lbl_Port
            // 
            this.lbl_Port.AutoSize = true;
            this.lbl_Port.Location = new System.Drawing.Point(24, 43);
            this.lbl_Port.Name = "lbl_Port";
            this.lbl_Port.Size = new System.Drawing.Size(26, 13);
            this.lbl_Port.TabIndex = 10;
            this.lbl_Port.Text = "Port";
            // 
            // lbl_Host
            // 
            this.lbl_Host.AutoSize = true;
            this.lbl_Host.Location = new System.Drawing.Point(24, 9);
            this.lbl_Host.Name = "lbl_Host";
            this.lbl_Host.Size = new System.Drawing.Size(29, 13);
            this.lbl_Host.TabIndex = 9;
            this.lbl_Host.Text = "Host";
            // 
            // dg_ConfigProxy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 120);
            this.Controls.Add(this.cb_Enabled);
            this.Controls.Add(this.txt_Port);
            this.Controls.Add(this.txt_Host);
            this.Controls.Add(this.lbl_Port);
            this.Controls.Add(this.lbl_Host);
            this.Name = "dg_ConfigProxy";
            this.Text = "  ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.dg_ConfigProxy_FormClosed);
            this.Load += new System.EventHandler(this.dg_ConfigProxy_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_Enabled;
        private System.Windows.Forms.TextBox txt_Port;
        private System.Windows.Forms.TextBox txt_Host;
        private System.Windows.Forms.Label lbl_Port;
        private System.Windows.Forms.Label lbl_Host;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.ComponentModel.IContainer components;

    }
}
