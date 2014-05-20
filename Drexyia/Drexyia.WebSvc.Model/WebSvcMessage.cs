/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Drexyia.WebSvc.Model {
    public class WebSvcMessage {

        public const string HEADER_NAME_CONTENT_TYPE = "Content-Type";
        
        const string HEADER_DEFAULT_CONTENT_TYPE = @"text/xml; charset=utf-8";
 
        public string HeaderContentType {
            get {
                return Headers[HEADER_NAME_CONTENT_TYPE];
            }
            set {
                Headers[HEADER_NAME_CONTENT_TYPE] = value;
            }
        }
       
        public string Body {
            get;
            set;
        }

        public string BodyUnformatted {
            get {
                Regex parser = new Regex(@"\s*<");
                string xmlUnformatted = parser.Replace(Body, "<");

                parser = new Regex(@">\s*<");
                xmlUnformatted = parser.Replace(xmlUnformatted, "><");
                return xmlUnformatted;
            }
        }
  
        protected Dictionary<string, string> Headers {
            get;
            set;
        }

        public WebSvcMessage() {
            Headers = new Dictionary<string, string>();
            HeaderContentType = HEADER_DEFAULT_CONTENT_TYPE;
        }

    }
}
