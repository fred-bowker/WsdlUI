/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/


namespace WsdlUI.App.UI.Dialogs
{
    partial class dg_Error
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
            this.btn_Copy = new System.Windows.Forms.Button();
            this.rtb_error = new System.Windows.Forms.RichTextBox();
            this.tt_Copy = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // btn_Copy
            // 
            this.btn_Copy.AutoSize = true;
            this.btn_Copy.Image = global::WsdlUI.App.UI.Properties.Resources.tool_clipboard;
            this.btn_Copy.Location = new System.Drawing.Point(433, 324);
            this.btn_Copy.Name = "btn_Copy";
            this.btn_Copy.Size = new System.Drawing.Size(75, 28);
            this.btn_Copy.TabIndex = 4;
            this.tt_Copy.SetToolTip(this.btn_Copy, "Copy to clipboard");
            this.btn_Copy.UseVisualStyleBackColor = true;
            this.btn_Copy.Click += new System.EventHandler(this.btn_Copy_Click);
            // 
            // rtb_error
            // 
            this.rtb_error.Location = new System.Drawing.Point(12, 12);
            this.rtb_error.Name = "rtb_error";
            this.rtb_error.Size = new System.Drawing.Size(496, 296);
            this.rtb_error.TabIndex = 3;
            this.rtb_error.Text = "";
            this.rtb_error.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtb_error_KeyPress);
            // 
            // dg_Error
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 364);
            this.Controls.Add(this.btn_Copy);
            this.Controls.Add(this.rtb_error);
            this.Name = "dg_Error";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_error;
        private System.Windows.Forms.Button btn_Copy;
        private System.Windows.Forms.ToolTip tt_Copy;
    }
}
