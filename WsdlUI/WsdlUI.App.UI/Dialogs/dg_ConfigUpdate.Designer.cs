/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

namespace WsdlUI.App.UI.Dialogs
{
    partial class dg_ConfigUpdate
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
            this.cb_EnableUpdate = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cb_EnableUpdate
            // 
            this.cb_EnableUpdate.AutoSize = true;
            this.cb_EnableUpdate.Location = new System.Drawing.Point(21, 12);
            this.cb_EnableUpdate.Name = "cb_EnableUpdate";
            this.cb_EnableUpdate.Size = new System.Drawing.Size(158, 17);
            this.cb_EnableUpdate.TabIndex = 0;
            this.cb_EnableUpdate.Text = "Check for update on startup";
            this.cb_EnableUpdate.UseVisualStyleBackColor = true;
            // 
            // dg_ConfigUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 44);
            this.Controls.Add(this.cb_EnableUpdate);
            this.Name = "dg_ConfigUpdate";
            this.Load += new System.EventHandler(this.dg_ConfigUpdate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cb_EnableUpdate;
    }
}
