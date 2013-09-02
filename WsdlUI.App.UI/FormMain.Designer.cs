/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/


namespace WsdlUI.App.UI
{
    partial class FormMain
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
        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.uc_treeView1 = new WsdlUI.App.UI.UserControls.uc_TreeView();
            this.uc_panelInfo1 = new WsdlUI.App.UI.UserControls.uc_PanelInfo();
            this.uc_log1 = new WsdlUI.App.UI.UserControls.uc_Log();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oPTIONSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proxyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startupWsdlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hELPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // scMain
            // 
            this.scMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scMain.BackColor = System.Drawing.SystemColors.Control;
            this.scMain.Location = new System.Drawing.Point(0, 27);
            this.scMain.Margin = new System.Windows.Forms.Padding(0);
            this.scMain.Name = "scMain";
            this.scMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.splitContainer1);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.uc_log1);
            this.scMain.Size = new System.Drawing.Size(884, 424);
            this.scMain.SplitterDistance = 330;
            this.scMain.SplitterWidth = 2;
            this.scMain.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.uc_treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.uc_panelInfo1);
            this.splitContainer1.Size = new System.Drawing.Size(884, 330);
            this.splitContainer1.SplitterDistance = 294;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 0;
            // 
            // uc_treeView1
            // 
            this.uc_treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc_treeView1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uc_treeView1.Location = new System.Drawing.Point(0, 0);
            this.uc_treeView1.Margin = new System.Windows.Forms.Padding(0);
            this.uc_treeView1.Name = "uc_treeView1";
            this.uc_treeView1.Size = new System.Drawing.Size(294, 330);
            this.uc_treeView1.TabIndex = 0;
            // 
            // uc_panelInfo1
            // 
            this.uc_panelInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc_panelInfo1.Location = new System.Drawing.Point(0, 0);
            this.uc_panelInfo1.Margin = new System.Windows.Forms.Padding(0);
            this.uc_panelInfo1.Name = "uc_panelInfo1";
            this.uc_panelInfo1.Size = new System.Drawing.Size(588, 330);
            this.uc_panelInfo1.TabIndex = 0;
            // 
            // uc_log1
            // 
            this.uc_log1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc_log1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uc_log1.Location = new System.Drawing.Point(0, 0);
            this.uc_log1.Margin = new System.Windows.Forms.Padding(0);
            this.uc_log1.Name = "uc_log1";
            this.uc_log1.Size = new System.Drawing.Size(884, 92);
            this.uc_log1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 448);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(884, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fILEToolStripMenuItem,
            this.oPTIONSToolStripMenuItem,
            this.hELPToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(884, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fILEToolStripMenuItem
            // 
            this.fILEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fILEToolStripMenuItem.Name = "fILEToolStripMenuItem";
            this.fILEToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.fILEToolStripMenuItem.Text = "FILE";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeyDisplayString = "Alt + F4";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // oPTIONSToolStripMenuItem
            // 
            this.oPTIONSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.proxyToolStripMenuItem,
            this.updateToolStripMenuItem,
            this.startupWsdlsToolStripMenuItem});
            this.oPTIONSToolStripMenuItem.Name = "oPTIONSToolStripMenuItem";
            this.oPTIONSToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.oPTIONSToolStripMenuItem.Text = "OPTIONS";
            // 
            // proxyToolStripMenuItem
            // 
            this.proxyToolStripMenuItem.Name = "proxyToolStripMenuItem";
            this.proxyToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.proxyToolStripMenuItem.Text = "Proxy";
            this.proxyToolStripMenuItem.Click += new System.EventHandler(this.configProxyToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.configUpdateToolStripMenuItem_Click);
            // 
            // startupWsdlsToolStripMenuItem
            // 
            this.startupWsdlsToolStripMenuItem.Name = "startupWsdlsToolStripMenuItem";
            this.startupWsdlsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.startupWsdlsToolStripMenuItem.Text = "Startup Wsdls";
            this.startupWsdlsToolStripMenuItem.Click += new System.EventHandler(this.configStartupWsdlsToolStripMenuItem_Click);
            // 
            // hELPToolStripMenuItem
            // 
            this.hELPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.checkForUpdateToolStripMenuItem});
            this.hELPToolStripMenuItem.Name = "hELPToolStripMenuItem";
            this.hELPToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.hELPToolStripMenuItem.Text = "HELP";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.helpAboutToolStripMenuItem_Click);
            // 
            // checkForUpdateToolStripMenuItem
            // 
            this.checkForUpdateToolStripMenuItem.Name = "checkForUpdateToolStripMenuItem";
            this.checkForUpdateToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.checkForUpdateToolStripMenuItem.Text = "Check For Update";
            this.checkForUpdateToolStripMenuItem.Click += new System.EventHandler(this.helpUpdateToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 470);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.scMain);
            this.DoubleBuffered = true;
            this.Icon = global::WsdlUI.App.UI.Properties.Resources.applications_internet_3;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            this.scMain.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.SplitContainer scMain;
        private System.ComponentModel.IContainer components;

        public System.Windows.Forms.StatusStrip statusStrip1;
        private UserControls.uc_Log uc_log1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fILEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oPTIONSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proxyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hELPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private UserControls.uc_TreeView uc_treeView1;
        private UserControls.uc_PanelInfo uc_panelInfo1;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startupWsdlsToolStripMenuItem;
    }
}
