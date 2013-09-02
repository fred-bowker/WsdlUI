using System;
using System.Threading;
using System.Windows.Forms;

using websvcasync = WsdlUI.App.Process.WebSvcAsync;

namespace WsdlUI.App.UI.Dialogs
{
    public partial class dg_HelpUpdate : dg_BaseCancel
    {
        public dg_HelpUpdate()
        {
            InitializeComponent();

            pb_Update.Minimum = 1;
            pb_Update.Value = 1;
            pb_Update.Step = 1;
            //interval of a second
            timer1.Interval = 1000;
        }

       void dg_HelpUpdate_Load(object sender, EventArgs e)
        {
            pb_Update.Maximum = AppConfig.Instance.UpdateTimeout;
            timer1.Enabled = true;
            timer1.Start();
            timer1.Tick += timer1_Tick;
         
            var updateCheck = new websvcasync.Operations.UpdateAsyncOp(AppConfig.Instance.UpdateUrl, AppInfo.Instance.Version, State.Instance.ConfigProxy, AppConfig.Instance.UpdateTimeout);
            updateCheck.OnComplete += updateCheck_OnComplete;
            updateCheck.OnWebException += updateCheck_OnWebException;
        
            Thread thread = new Thread(() => 
                updateCheck.Start()
                );
            thread.Start();

        }

        void updateCheck_OnWebException(object sender, EventArgs e)
        {
            timer1.Stop();

            this.Invoke(new MethodInvoker(delegate()
            {
                pb_Update.Value = pb_Update.Maximum;

                rtb_UpdateResult.Text = "An error occurred connecting to the update page";
                rtb_UpdateResult.Visible = true;
            }));
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            if (pb_Update.Value != pb_Update.Maximum)
            {
                pb_Update.Value++;
            }
            else
            {
                timer1.Stop();
            }
        }

        void updateCheck_OnComplete(object sender, websvcasync.EventParams.UpdateAsyncArgs e)
        {
            timer1.Stop();

            this.Invoke(new MethodInvoker(delegate()
            {
                pb_Update.Value = pb_Update.Maximum;

                if (e.UpdateAvailable)
                {
                    string resultMsg = string.Format(Consts.UpdateFormatMsg, e.DownloadUrl);
                    rtb_UpdateResult.Text = resultMsg;
                    rtb_UpdateResult.Visible = true;
                }
                else
                {
                    rtb_UpdateResult.Text = "WsdlUI is up to date";
                    rtb_UpdateResult.Visible = true;
                }
            }));

        }
    }
}
