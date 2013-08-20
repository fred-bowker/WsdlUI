/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System.Collections.Generic;

namespace WsdlUI.App.Process.WebSvcAsync.Result {
    public class CallAsyncResult {

        public string ResponseMessage {
            get;
            private set;
        }

        public string ContentLength {
            get;
            private set;
        }

        public string Status {
            get;
            private set;
        }

        public Dictionary<string, string> Headers {
            get;
            private set;
        }

        public CallAsyncResult(string responseMessage, string contentLength, string status, Dictionary<string, string> headers) {
            ResponseMessage = responseMessage;
            ContentLength = contentLength;
            Status = status;
            Headers = headers;
        }
    }
}
