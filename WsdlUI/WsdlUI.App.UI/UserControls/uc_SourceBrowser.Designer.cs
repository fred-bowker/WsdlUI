/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using WsdlUI.TextEditor;

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
            this.tec_source = new XmlTextEditor();
            this.SuspendLayout();
            // 
            // tec_source
            // 
            this.tec_source.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tec_source.IsReadOnly = false;
            this.tec_source.Location = new System.Drawing.Point(0, 0);
            this.tec_source.Name = "tec_source";
            this.tec_source.ShowLineNumbers = false;
            this.tec_source.ShowVRuler = false;
            this.tec_source.Size = new System.Drawing.Size(150, 150);
            this.tec_source.TabIndent = 2;
            this.tec_source.TabIndex = 0;
            // 
            // uc_SourceBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tec_source);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "uc_SourceBrowser";
            this.Load += new System.EventHandler(this.uc_SourceBrowser_Load);
            this.ResumeLayout(false);

        }

        #endregion

       private XmlTextEditor tec_source;

    }
}
