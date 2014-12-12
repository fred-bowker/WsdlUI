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
            this.components = new System.ComponentModel.Container();
            this.txt_License = new System.Windows.Forms.TextBox();
            this.rtb_WebSite = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_Version = new System.Windows.Forms.Label();
            this.pb_AppIcon = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pb_Update = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.rtb_UpdateResult = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_AppIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_License
            // 
            this.txt_License.Location = new System.Drawing.Point(12, 100);
            this.txt_License.Multiline = true;
            this.txt_License.Name = "txt_License";
            this.txt_License.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_License.Size = new System.Drawing.Size(599, 203);
            this.txt_License.TabIndex = 0;
            this.txt_License.TextChanged += new System.EventHandler(this.txt_License_TextChanged);
            this.txt_License.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_License_KeyPress);
            // 
            // rtb_WebSite
            // 
            this.rtb_WebSite.AutoSize = true;
            this.rtb_WebSite.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_WebSite.Location = new System.Drawing.Point(93, 10);
            this.rtb_WebSite.Name = "rtb_WebSite";
            this.rtb_WebSite.ReadOnly = true;
            this.rtb_WebSite.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtb_WebSite.Size = new System.Drawing.Size(421, 14);
            this.rtb_WebSite.TabIndex = 11;
            this.rtb_WebSite.Text = "WS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 9;
            this.label2.Text = "Web Site:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 12;
            this.label4.Text = "Version:";
            // 
            // lbl_Version
            // 
            this.lbl_Version.AutoSize = true;
            this.lbl_Version.Location = new System.Drawing.Point(90, 35);
            this.lbl_Version.Name = "lbl_Version";
            this.lbl_Version.Size = new System.Drawing.Size(21, 14);
            this.lbl_Version.TabIndex = 13;
            this.lbl_Version.Text = "VE";
            // 
            // pb_AppIcon
            // 
            this.pb_AppIcon.Image = global::WsdlUI.App.UI.Properties.Resources.applications_internet_3_png;
            this.pb_AppIcon.Location = new System.Drawing.Point(529, 10);
            this.pb_AppIcon.Name = "pb_AppIcon";
            this.pb_AppIcon.Size = new System.Drawing.Size(82, 75);
            this.pb_AppIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_AppIcon.TabIndex = 14;
            this.pb_AppIcon.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 14);
            this.label1.TabIndex = 15;
            this.label1.Text = "Update:";
            // 
            // pb_Update
            // 
            this.pb_Update.Location = new System.Drawing.Point(93, 64);
            this.pb_Update.Name = "pb_Update";
            this.pb_Update.Size = new System.Drawing.Size(421, 22);
            this.pb_Update.Step = 1;
            this.pb_Update.TabIndex = 16;
            // 
            // rtb_UpdateResult
            // 
            this.rtb_UpdateResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_UpdateResult.Location = new System.Drawing.Point(93, 64);
            this.rtb_UpdateResult.Name = "rtb_UpdateResult";
            this.rtb_UpdateResult.ReadOnly = true;
            this.rtb_UpdateResult.Size = new System.Drawing.Size(421, 22);
            this.rtb_UpdateResult.TabIndex = 17;
            this.rtb_UpdateResult.Text = "";
            this.rtb_UpdateResult.Visible = false;
            // 
            // dg_HelpAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 321);
            this.Controls.Add(this.rtb_UpdateResult);
            this.Controls.Add(this.pb_Update);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pb_AppIcon);
            this.Controls.Add(this.lbl_Version);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rtb_WebSite);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_License);
            this.Font = DefaultFonts.Instance.Small;
            this.Name = "dg_HelpAbout";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.dg_HelpAbout_FormClosed);
            this.Load += new System.EventHandler(this.dg_HelpAbout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_AppIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_License;
        private System.Windows.Forms.RichTextBox rtb_WebSite;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_Version;
        private System.Windows.Forms.PictureBox pb_AppIcon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar pb_Update;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RichTextBox rtb_UpdateResult;
    }
}
