/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

namespace WsdlUI.App.UI.UserControls
{
    partial class uc_Status
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
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ss_Progress = new System.Windows.Forms.StatusStrip();
            this.tslbl_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.pb_Running = new System.Windows.Forms.ToolStripProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ss_Progress.SuspendLayout();
            this.SuspendLayout();
            // 
            // ss_Progress
            // 
            this.ss_Progress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ss_Progress.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslbl_Status,
            this.pb_Running});
            this.ss_Progress.Location = new System.Drawing.Point(0, 0);
            this.ss_Progress.Name = "ss_Progress";
            this.ss_Progress.Size = new System.Drawing.Size(150, 23);
            this.ss_Progress.TabIndex = 0;
            this.ss_Progress.Text = "statusStrip1";
            // 
            // tslbl_Status
            // 
            this.tslbl_Status.AutoSize = false;
            this.tslbl_Status.Name = "tslbl_Status";
            this.tslbl_Status.Size = new System.Drawing.Size(100, 18);
            this.tslbl_Status.Text = "Ready";
            // 
            // pb_Running
            // 
            this.pb_Running.AutoSize = false;
            this.pb_Running.Name = "pb_Running";
            this.pb_Running.Size = new System.Drawing.Size(100, 15);
            // 
            // uc_Status
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ss_Progress);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "uc_Status";
            this.Size = new System.Drawing.Size(150, 23);
            this.Load += new System.EventHandler(this.uc_Status_Load);
            this.ss_Progress.ResumeLayout(false);
            this.ss_Progress.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip ss_Progress;
        private System.Windows.Forms.ToolStripStatusLabel tslbl_Status;
        private System.Windows.Forms.ToolStripProgressBar pb_Running;
        private System.Windows.Forms.Timer timer1;
    }
}
