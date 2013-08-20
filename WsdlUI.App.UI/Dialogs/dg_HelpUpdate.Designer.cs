namespace WsdlUI.App.UI.Dialogs
{
    partial class dg_HelpUpdate
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
            this.pb_Update = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbl_UpdateResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pb_Update
            // 
            this.pb_Update.Location = new System.Drawing.Point(122, 16);
            this.pb_Update.Name = "pb_Update";
            this.pb_Update.Size = new System.Drawing.Size(375, 23);
            this.pb_Update.Step = 1;
            this.pb_Update.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Checking for update";
            // 
            // lbl_UpdateResult
            // 
            this.lbl_UpdateResult.AutoSize = true;
            this.lbl_UpdateResult.Location = new System.Drawing.Point(13, 57);
            this.lbl_UpdateResult.Name = "lbl_UpdateResult";
            this.lbl_UpdateResult.Size = new System.Drawing.Size(68, 13);
            this.lbl_UpdateResult.TabIndex = 2;
            this.lbl_UpdateResult.Text = "update result";
            this.lbl_UpdateResult.Visible = false;
            // 
            // dg_HelpUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 98);
            this.Controls.Add(this.lbl_UpdateResult);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pb_Update);
            this.Name = "dg_HelpUpdate";
            this.Load += new System.EventHandler(this.dg_HelpUpdate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pb_Update;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbl_UpdateResult;
    }
}
