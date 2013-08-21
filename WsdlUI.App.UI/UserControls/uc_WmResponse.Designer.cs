/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/


namespace WsdlUI.App.UI.UserControls
{
    partial class uc_WmResponse
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
            this.uc_responseMessage = new WsdlUI.App.UI.UserControls.uc_SourceBrowser();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pg_responseHeaders = new System.Windows.Forms.PropertyGrid();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uc_responseMessage
            // 
            this.uc_responseMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc_responseMessage.Location = new System.Drawing.Point(0, 0);
            this.uc_responseMessage.Margin = new System.Windows.Forms.Padding(0);
            this.uc_responseMessage.Name = "uc_responseMessage";
            this.uc_responseMessage.Size = new System.Drawing.Size(558, 322);
            this.uc_responseMessage.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pg_responseHeaders);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.uc_responseMessage);
            this.splitContainer1.Size = new System.Drawing.Size(558, 423);
            this.splitContainer1.SplitterDistance = 97;
            this.splitContainer1.TabIndex = 2;
            // 
            // pg_responseHeaders
            // 
            this.pg_responseHeaders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pg_responseHeaders.HelpVisible = false;
            this.pg_responseHeaders.Location = new System.Drawing.Point(0, 0);
            this.pg_responseHeaders.Margin = new System.Windows.Forms.Padding(0);
            this.pg_responseHeaders.Name = "pg_responseHeaders";
            this.pg_responseHeaders.Size = new System.Drawing.Size(558, 97);
            this.pg_responseHeaders.TabIndex = 0;
            this.pg_responseHeaders.ToolbarVisible = false;
            // 
            // uc_WmResponse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "uc_WmResponse";
            this.Size = new System.Drawing.Size(558, 423);
            this.Load += new System.EventHandler(this.uc_WmResponse_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private uc_SourceBrowser uc_responseMessage;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PropertyGrid pg_responseHeaders;
    }
}
