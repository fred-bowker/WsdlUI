/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System;

namespace WsdlUI.App.Process.WebSvcAsync.EventParams {

    //only a single version of this should be running so a name is not needed to identify the call
    public class UpdateAsyncArgs : EventArgs {

        public bool UpdateAvailable {
            get;
            private set;
        }

        public string Version {
            get;
            private set;
        }

        public string DownloadUrl {
            get;
            private set;
        }

        //use if no update is available
        public UpdateAsyncArgs() {
        }

        public UpdateAsyncArgs(string version, string downloadUrl) {
            Version = version;
            DownloadUrl = downloadUrl;
            UpdateAvailable = true;
        }

    }
}
