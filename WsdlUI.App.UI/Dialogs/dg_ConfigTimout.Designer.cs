/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/


namespace WsdlUI.App.UI.Dialogs
{
    partial class dg_ConfigTimout
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
       void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cb_Timeout = new System.Windows.Forms.ComboBox();
            this.lbl_Timeout = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cb_Timeout
            // 
            this.cb_Timeout.FormattingEnabled = true;
            this.cb_Timeout.Location = new System.Drawing.Point(193, 7);
            this.cb_Timeout.Name = "cb_Timeout";
            this.cb_Timeout.Size = new System.Drawing.Size(152, 22);
            this.cb_Timeout.TabIndex = 13;
            // 
            // lbl_Timeout
            // 
            this.lbl_Timeout.AutoSize = true;
            this.lbl_Timeout.Location = new System.Drawing.Point(12, 7);
            this.lbl_Timeout.Name = "lbl_Timeout";
            this.lbl_Timeout.Size = new System.Drawing.Size(175, 14);
            this.lbl_Timeout.TabIndex = 9;
            this.lbl_Timeout.Text = "Web service call timeout";
            // 
            // dg_ConfigTimout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 47);
            this.Controls.Add(this.cb_Timeout);
            this.Controls.Add(this.lbl_Timeout);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "dg_ConfigTimout";
            this.Text = "  ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.dg_ConfigTimeout_FormClosed);
            this.Load += new System.EventHandler(this.dg_ConfigTimeout_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

       private System.Windows.Forms.ComboBox cb_Timeout;
      private System.Windows.Forms.Label lbl_Timeout;
      private System.ComponentModel.IContainer components;

    }
}
