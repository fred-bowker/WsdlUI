/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System;
using System.Windows.Forms;

using process = WsdlUI.App.Process;

namespace WsdlUI.App.UI {
    static class Program {
        static readonly object _locker = new object();
        static bool _exceptionOccurred;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {

            process.Logger.Instance.Log.Info("Program Start");

            Application.ThreadException += Application_ThreadException;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try {
                WsdlUI.App.UI.FormMain mainForm = new UI.FormMain();
                mainForm.OnException += mainForm_OnException;

                mainForm.Setup();
                Application.Run(mainForm);

                if (!_exceptionOccurred) {
                    mainForm.CleanUp();
                }
            }
            catch (Exception ex) //handle exception on startup
            {
                HandleException(ex);
            }
        }

        static void mainForm_OnException(object sender, Process.WebSvcAsync.EventParams.ExceptionAsyncArgs e) {
            HandleException(e.Ex);
        }

        //handle exception on ui thread
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e) {
            HandleException(e.Exception);
        }

        static void HandleException(Exception ex) {

   process.Logger.Instance.Log.Error(ex.ToString());

            lock (_locker) {
                if (!_exceptionOccurred) {
                    _exceptionOccurred = true;

                    WsdlUI.App.UI.Dialogs.dg_Error dialog = new WsdlUI.App.UI.Dialogs.dg_Error();
                    dialog.PopulateForm(ex);

                    dialog.ShowDialog();

                    if (System.Windows.Forms.Application.MessageLoop) {

                        // Use this since we are a WinForms app
                        Application.Exit();
                    }
                    else {

                        // Use this since we are a console app
                        Environment.Exit(1);
                    }

                }
            }
        }

    }
}
