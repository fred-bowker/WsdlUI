/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/


namespace WsdlUI.App.UI.UserControls
{
    partial class uc_Wm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
       void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolStrip1 = new WsdlUI.App.UI.UserControls.Widgets.wg_BaseToolStrip();
            this.tsbtn_Go = new WsdlUI.App.UI.UserControls.Widgets.wg_BaseToolStripButton();
            this.tsbtn_Cancel = new WsdlUI.App.UI.UserControls.Widgets.wg_BaseToolStripButton();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.uc_wm_response1 = new WsdlUI.App.UI.UserControls.uc_WmResponse();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.uc_wm_request1 = new WsdlUI.App.UI.UserControls.uc_WmRequest();
            this.tp_Log = new System.Windows.Forms.TabPage();
            this.uc_log1 = new WsdlUI.App.UI.UserControls.uc_Log();
            this.tc_Settings = new System.Windows.Forms.TabControl();
            this.uc_Status1 = new WsdlUI.App.UI.UserControls.uc_Status();
            this.toolStrip1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tp_Log.SuspendLayout();
            this.tc_Settings.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtn_Go,
            this.tsbtn_Cancel});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.Size = new System.Drawing.Size(604, 45);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtn_Go
            // 
            this.tsbtn_Go.AutoSize = false;
            
            this.tsbtn_Go.Image = global::WsdlUI.App.UI.Properties.Resources.arrow_right_3;
            this.tsbtn_Go.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtn_Go.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_Go.Name = "tsbtn_Go";
            this.tsbtn_Go.Size = new System.Drawing.Size(55, 43);
            this.tsbtn_Go.Text = "Go";
            this.tsbtn_Go.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtn_Go.Click += new System.EventHandler(this.tsBtnGo_Click);
            // 
            // tsbtn_Cancel
            // 
            this.tsbtn_Cancel.AutoSize = false;
            this.tsbtn_Cancel.Enabled = false;
            
            this.tsbtn_Cancel.Image = global::WsdlUI.App.UI.Properties.Resources.process_stop_3;
            this.tsbtn_Cancel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtn_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_Cancel.Name = "tsbtn_Cancel";
            this.tsbtn_Cancel.Size = new System.Drawing.Size(55, 43);
            this.tsbtn_Cancel.Text = "Cancel";
            this.tsbtn_Cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtn_Cancel.Click += new System.EventHandler(this.tsbtn_Cancel_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.uc_wm_response1);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(596, 134);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Response";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // uc_wm_response1
            // 
            this.uc_wm_response1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc_wm_response1.Location = new System.Drawing.Point(0, 0);
            this.uc_wm_response1.Margin = new System.Windows.Forms.Padding(0);
            this.uc_wm_response1.Name = "uc_wm_response1";
            this.uc_wm_response1.Size = new System.Drawing.Size(596, 134);
            this.uc_wm_response1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.uc_wm_request1);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(596, 134);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Request";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // uc_wm_request1
            // 
            this.uc_wm_request1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc_wm_request1.Location = new System.Drawing.Point(0, 0);
            this.uc_wm_request1.Margin = new System.Windows.Forms.Padding(0);
            this.uc_wm_request1.Name = "uc_wm_request1";
            this.uc_wm_request1.Size = new System.Drawing.Size(596, 134);
            this.uc_wm_request1.TabIndex = 0;
            // 
            // tp_Log
            // 
            this.tp_Log.Controls.Add(this.uc_log1);
            this.tp_Log.Location = new System.Drawing.Point(4, 25);
            this.tp_Log.Margin = new System.Windows.Forms.Padding(0);
            this.tp_Log.Name = "tp_Log";
            this.tp_Log.Size = new System.Drawing.Size(596, 134);
            this.tp_Log.TabIndex = 0;
            this.tp_Log.Text = "Log";
            this.tp_Log.UseVisualStyleBackColor = true;
            // 
            // uc_log1
            // 
            this.uc_log1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc_log1.Location = new System.Drawing.Point(0, 0);
            this.uc_log1.Margin = new System.Windows.Forms.Padding(0);
            this.uc_log1.Name = "uc_log1";
            this.uc_log1.Size = new System.Drawing.Size(596, 134);
            this.uc_log1.TabIndex = 0;
            // 
            // tc_Settings
            // 
            this.tc_Settings.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tc_Settings.Controls.Add(this.tabPage3);
            this.tc_Settings.Controls.Add(this.tabPage4);
            this.tc_Settings.Controls.Add(this.tp_Log);
            this.tc_Settings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tc_Settings.Location = new System.Drawing.Point(0, 45);
            this.tc_Settings.Name = "tc_Settings";
            this.tc_Settings.Padding = new System.Drawing.Point(0, 0);
            this.tc_Settings.SelectedIndex = 0;
            this.tc_Settings.Size = new System.Drawing.Size(604, 163);
            this.tc_Settings.TabIndex = 2;
            this.tc_Settings.Tag = "";
            // 
            // uc_Status1
            // 
            this.uc_Status1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uc_Status1.Location = new System.Drawing.Point(0, 208);
            this.uc_Status1.Margin = new System.Windows.Forms.Padding(0);
            this.uc_Status1.Name = "uc_Status1";
            this.uc_Status1.Size = new System.Drawing.Size(604, 21);
            this.uc_Status1.TabIndex = 1;
            // 
            // uc_Wm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tc_Settings);
            this.Controls.Add(this.uc_Status1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "uc_Wm";
            this.Size = new System.Drawing.Size(604, 229);
            this.Load += new System.EventHandler(this.uc_Wm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tp_Log.ResumeLayout(false);
            this.tc_Settings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

       public WsdlUI.App.UI.UserControls.Widgets.wg_BaseToolStrip toolStrip1;
       public WsdlUI.App.UI.UserControls.Widgets.wg_BaseToolStripButton tsbtn_Go;
       protected WsdlUI.App.UI.UserControls.Widgets.wg_BaseToolStripButton tsbtn_Cancel;
        private System.Windows.Forms.TabPage tabPage4;
        private uc_WmResponse uc_wm_response1;
        private System.Windows.Forms.TabPage tabPage3;
        private uc_WmRequest uc_wm_request1;
        private System.Windows.Forms.TabPage tp_Log;
        private uc_Log uc_log1;
        private System.Windows.Forms.TabControl tc_Settings;
        private uc_Status uc_Status1;
    }
}
