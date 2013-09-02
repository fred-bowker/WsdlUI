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
            this.rtb_UpdateResult = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // pb_Update
            // 
            this.pb_Update.Location = new System.Drawing.Point(161, 17);
            this.pb_Update.Name = "pb_Update";
            this.pb_Update.Size = new System.Drawing.Size(686, 25);
            this.pb_Update.Step = 1;
            this.pb_Update.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Checking for update";
            // 
            // rtb_UpdateResult
            // 
            this.rtb_UpdateResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_UpdateResult.Location = new System.Drawing.Point(15, 61);
            this.rtb_UpdateResult.Name = "rtb_UpdateResult";
            this.rtb_UpdateResult.ReadOnly = true;
            this.rtb_UpdateResult.Size = new System.Drawing.Size(832, 21);
            this.rtb_UpdateResult.TabIndex = 3;
            this.rtb_UpdateResult.Text = "";
            this.rtb_UpdateResult.Visible = false;
            // 
            // dg_HelpUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 106);
            this.Controls.Add(this.rtb_UpdateResult);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pb_Update);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "dg_HelpUpdate";
            this.Load += new System.EventHandler(this.dg_HelpUpdate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pb_Update;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RichTextBox rtb_UpdateResult;
    }
}
