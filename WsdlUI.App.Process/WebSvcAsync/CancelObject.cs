/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System;
using System.Threading;

using process = WsdlUI.App.Process;

namespace WsdlUI.App.Process.WebSvcAsync {
    public class CancelToken {
        public bool IsCancellationRequested;
    }

    public class CancelObject : MonitorObject {
        public event EventHandler OnCancel;

        const int CANCEL_POLL_TIME = 250;

        CancelToken _cancelToken;

        public CancelObject(string name, CancelToken cancelToken) 
            : base(name) {
            _cancelToken = cancelToken;
        }

        public void Start() {
            Thread thread = new Thread(() => CheckForCancelation());
            thread.Start();
        }

        internal new void Stop() {
            base.Stop();
        }

        void CheckForCancelation() {

            //used for displaying debug message, 20 * 250 milliseconds is 5 seconds
            int counter = 0;

            for (; ; ) //ever
            {
                if (base.IsWorkComplete) {

                    process.Logger.Instance.Log.Info("Cancelled Thread Stopped " + base.Name);

                    return;
                }

                if (_cancelToken.IsCancellationRequested) {

                    process.Logger.Instance.Log.Info("Cancelled Thread Cancelled " + base.Name);

                    if (OnCancel != null) {
                        OnCancel(this, new EventArgs());
                        return;
                    }
                }

                //display message for tracing purposes every 5 seconds
                if ((counter % 20) == 0) {
                    process.Logger.Instance.Log.Info("Cancelled Checking " + base.Name);
                }

                Thread.Sleep(CANCEL_POLL_TIME);

                counter++;
            }

        }
    }
}
