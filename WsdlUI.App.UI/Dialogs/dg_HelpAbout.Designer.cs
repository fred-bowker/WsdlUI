/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/


namespace WsdlUI.App.UI.Dialogs
{
    partial class dg_HelpAbout
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
            this.txt_License = new System.Windows.Forms.TextBox();
            this.lbl_WebSite = new System.Windows.Forms.LinkLabel();
            this.lbl_Developer = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_Version = new System.Windows.Forms.Label();
            this.pb_AppIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_AppIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_License
            // 
            this.txt_License.Location = new System.Drawing.Point(12, 83);
            this.txt_License.Multiline = true;
            this.txt_License.Name = "txt_License";
            this.txt_License.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_License.Size = new System.Drawing.Size(391, 189);
            this.txt_License.TabIndex = 0;
            this.txt_License.TextChanged += new System.EventHandler(this.txt_License_TextChanged);
            this.txt_License.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_License_KeyPress);
            // 
            // lbl_WebSite
            // 
            this.lbl_WebSite.AutoSize = true;
            this.lbl_WebSite.Location = new System.Drawing.Point(92, 31);
            this.lbl_WebSite.Name = "lbl_WebSite";
            this.lbl_WebSite.Size = new System.Drawing.Size(25, 13);
            this.lbl_WebSite.TabIndex = 11;
            this.lbl_WebSite.TabStop = true;
            this.lbl_WebSite.Text = "WS";
            // 
            // lbl_Developer
            // 
            this.lbl_Developer.AutoSize = true;
            this.lbl_Developer.Location = new System.Drawing.Point(92, 9);
            this.lbl_Developer.Name = "lbl_Developer";
            this.lbl_Developer.Size = new System.Drawing.Size(22, 13);
            this.lbl_Developer.TabIndex = 10;
            this.lbl_Developer.Text = "DE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Web Site:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Developer:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Version:";
            // 
            // lbl_Version
            // 
            this.lbl_Version.AutoSize = true;
            this.lbl_Version.Location = new System.Drawing.Point(92, 56);
            this.lbl_Version.Name = "lbl_Version";
            this.lbl_Version.Size = new System.Drawing.Size(21, 13);
            this.lbl_Version.TabIndex = 13;
            this.lbl_Version.Text = "VE";
            // 
            // pictureBox1
            // 
            this.pb_AppIcon.Image = global::WsdlUI.App.UI.Properties.Resources.applications_internet_3_png;
            this.pb_AppIcon.Location = new System.Drawing.Point(333, 9);
            this.pb_AppIcon.Name = "pictureBox1";
            this.pb_AppIcon.Size = new System.Drawing.Size(70, 70);
            this.pb_AppIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_AppIcon.TabIndex = 14;
            this.pb_AppIcon.TabStop = false;
            // 
            // dg_HelpAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 284);
            this.Controls.Add(this.pb_AppIcon);
            this.Controls.Add(this.lbl_Version);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_WebSite);
            this.Controls.Add(this.lbl_Developer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_License);
            this.Name = "dg_HelpAbout";
            ((System.ComponentModel.ISupportInitialize)(this.pb_AppIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_License;
        private System.Windows.Forms.LinkLabel lbl_WebSite;
        private System.Windows.Forms.Label lbl_Developer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_Version;
        private System.Windows.Forms.PictureBox pb_AppIcon;
    }
}
