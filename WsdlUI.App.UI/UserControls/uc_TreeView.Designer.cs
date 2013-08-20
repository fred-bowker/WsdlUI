/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/


namespace WsdlUI.App.UI.UserControls
{
    partial class uc_TreeView
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Web Services");
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbButtonAdd = new System.Windows.Forms.ToolStripButton();
            this.tsBtnRemove = new System.Windows.Forms.ToolStripButton();
            this.imgList_All = new System.Windows.Forms.ImageList(this.components);
            this.tv_webServices = new System.Windows.Forms.TreeView();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbButtonAdd,
            this.tsBtnRemove});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(150, 44);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbButtonAdd
            // 
            this.tsbButtonAdd.AutoSize = false;
            this.tsbButtonAdd.Image = global::WsdlUI.App.UI.Properties.Resources.list_add_3;
            this.tsbButtonAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbButtonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbButtonAdd.Name = "tsbButtonAdd";
            this.tsbButtonAdd.Size = new System.Drawing.Size(54, 41);
            this.tsbButtonAdd.Text = "Add";
            this.tsbButtonAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbButtonAdd.ToolTipText = "Add a web service";
            this.tsbButtonAdd.Click += new System.EventHandler(this.tsbButtonAdd_Click);
            // 
            // tsBtnRemove
            // 
            this.tsBtnRemove.AutoSize = false;
            this.tsBtnRemove.Image = global::WsdlUI.App.UI.Properties.Resources.list_remove_3;
            this.tsBtnRemove.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsBtnRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRemove.Name = "tsBtnRemove";
            this.tsBtnRemove.Size = new System.Drawing.Size(54, 41);
            this.tsBtnRemove.Text = "Remove";
            this.tsBtnRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsBtnRemove.ToolTipText = "Remove web service";
            this.tsBtnRemove.Click += new System.EventHandler(this.tsBtnRemove_Click);
            // 
            // imgList_All
            // 
            this.imgList_All.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgList_All.ImageSize = new System.Drawing.Size(16, 16);
            this.imgList_All.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tv_webServices
            // 
            this.tv_webServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv_webServices.ImageKey = "view-list-tree-4.png";
            this.tv_webServices.ImageList = this.imgList_All;
            this.tv_webServices.Location = new System.Drawing.Point(0, 44);
            this.tv_webServices.Name = "tv_webServices";
            treeNode1.ImageKey = "view-list-tree-4.png";
            treeNode1.Name = "nd_root";
            treeNode1.SelectedImageKey = "(default)";
            treeNode1.Text = "Web Services";
            this.tv_webServices.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.tv_webServices.SelectedImageKey = "bullet_green.png";
            this.tv_webServices.Size = new System.Drawing.Size(150, 106);
            this.tv_webServices.TabIndex = 2;
            this.tv_webServices.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_webServices_AfterSelect);
            // 
            // uc_TreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tv_webServices);
            this.Controls.Add(this.toolStrip1);
            this.Name = "uc_TreeView";
            this.Load += new System.EventHandler(this.uc_TreeView_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.ToolStripButton tsbButtonAdd;
        public System.Windows.Forms.ToolStripButton tsBtnRemove;
        public System.Windows.Forms.ImageList imgList_All;
        private System.Windows.Forms.TreeView tv_webServices;
    }
}
