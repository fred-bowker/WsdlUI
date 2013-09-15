/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/


namespace WsdlUI.App.UI.UserControls
{
    partial class uc_WmRequest
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pg_headers = new System.Windows.Forms.PropertyGrid();
            this.tec_Request = new Widgets.wg_XmlTextEditor();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pg_headers);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tec_Request);
            this.splitContainer1.Size = new System.Drawing.Size(495, 400);
            this.splitContainer1.SplitterDistance = 90;
            this.splitContainer1.TabIndex = 3;
            // 
            // pg_headers
            // 
            this.pg_headers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pg_headers.HelpVisible = false;
            this.pg_headers.Location = new System.Drawing.Point(0, 0);
            this.pg_headers.Margin = new System.Windows.Forms.Padding(0);
            this.pg_headers.Name = "pg_headers";
            this.pg_headers.Size = new System.Drawing.Size(495, 90);
            this.pg_headers.TabIndex = 0;
            this.pg_headers.ToolbarVisible = false;
            // 
            // tec_Request
            // 
            this.tec_Request.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tec_Request.Location = new System.Drawing.Point(0, 0);
            this.tec_Request.Name = "tec_Request";
            this.tec_Request.Size = new System.Drawing.Size(495, 306);
            this.tec_Request.TabIndex = 2;
            // 
            // uc_WmRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "uc_WmRequest";
            this.Size = new System.Drawing.Size(495, 400);
            this.Load += new System.EventHandler(this.uc_WmRequest_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

       private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PropertyGrid pg_headers;
        private WsdlUI.App.UI.UserControls.Widgets.wg_XmlTextEditor tec_Request;
    }
}
