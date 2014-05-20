/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System;
using System.Threading;

namespace Drexyia.WebSvc.Process.WebSvcAsync {
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

            for (; ; ) //ever
            {
                if (base.IsWorkComplete) {

                    return;
                }

                if (_cancelToken.IsCancellationRequested) {

                    if (OnCancel != null) {
                        OnCancel(this, new EventArgs());
                        return;
                    }
                }

                Thread.Sleep(CANCEL_POLL_TIME);
            }

        }
    }
}
