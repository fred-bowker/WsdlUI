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

    internal class TimeoutObject : MonitorObject {
    
        int _timeOutInSeconds;

        internal bool HasTimedOut {
            get;
            private set;
        }

        internal event EventHandler<EventParams.TimeoutAsyncArgs> OnTimeout;

        internal TimeoutObject(string name, int timeOutInSeconds)
            : base(name) {
            _timeOutInSeconds = timeOutInSeconds;

        }

        internal void Start() {
            Thread thread = new Thread(() => CheckForTimeout());
            thread.IsBackground = true;
            thread.Start();
        }

        internal new void Stop() {
            base.Stop();
        }

        void CheckForTimeout() {

            for (int i = 0; i < _timeOutInSeconds; i++) {
                if (base.IsWorkComplete) {
                    return;
                }

                Thread.Sleep(1000);
            }

            HasTimedOut = true;

            if (OnTimeout != null) {
                OnTimeout(this, new EventParams.TimeoutAsyncArgs(base.Name));
                return;
            }

        }
    }


}
