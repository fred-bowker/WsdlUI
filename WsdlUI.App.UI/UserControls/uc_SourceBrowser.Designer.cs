/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/


namespace WsdlUI.App.UI.UserControls
{
    partial class uc_SourceBrowser
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
            this.wb_source = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // wb_source
            // 
            this.wb_source.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wb_source.Location = new System.Drawing.Point(0, 0);
            this.wb_source.Margin = new System.Windows.Forms.Padding(0);
            this.wb_source.MinimumSize = new System.Drawing.Size(20, 20);
            this.wb_source.Name = "wb_source";
            this.wb_source.Size = new System.Drawing.Size(150, 150);
            this.wb_source.TabIndex = 0;
            // 
            // uc_SourceBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.wb_source);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "uc_SourceBrowser";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser wb_source;
    }
}
