/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/


using System;
using System.IO;
using System.Net;
using drexModel = Drexyia.WebSvc.Model;
using drexProcess = Drexyia.WebSvc.Process;
using utils = Drexyia.Utils;
using wsdlProcess = WsdlUI.App.Process;

namespace WsdlUI.App.Process.WebSvcAsync.Operations {
    public class UpdateAsyncOp : drexProcess.WebSvcAsync.Operations.AsyncOp {

        string _updateUrl;
        string _version;
        HttpWebResponse _response;
        StreamReader _readStream;

        public event EventHandler<wsdlProcess.WebSvcAsync.EventParams.UpdateAsyncArgs> OnComplete;

        public UpdateAsyncOp(string updateUrl, string version, drexModel.IProxy configProxy, int timeoutPeriod)
            : base("UpdateAsyncOp", timeoutPeriod, configProxy, utils.Logger.Instance.Log) {

            _updateUrl = updateUrl;
            _version = version;
        }

        protected override void Work() {

            HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(_updateUrl);
            webReq.Method = "GET";

            webReq.ContentType = "text/plain; encoding='utf-8'";
            webReq.Proxy = base.WebProxy;

			IgnoreSSL();
            _response = (HttpWebResponse)webReq.GetResponse();
            _readStream = new StreamReader(_response.GetResponseStream());

            string responseVersion = _readStream.ReadLine();
            string responseUrl = _readStream.ReadLine();

            Version currentVersion = new Version(_version);
            Version updateVersion = new Version(responseVersion);

            int latestVersion = currentVersion.CompareTo(updateVersion);

            var updateArgs = (latestVersion < 0)
                ? new wsdlProcess.WebSvcAsync.EventParams.UpdateAsyncArgs(responseVersion, responseUrl)
                : new wsdlProcess.WebSvcAsync.EventParams.UpdateAsyncArgs();

            if (OnComplete != null) {
                OnComplete(this, updateArgs);
            }

        }

        protected override void TearDown() {

		    UseSSL();
            if (_response != null) {
                _response.Close();
            }
            if (_readStream != null) {
                _readStream.Close();
            }

        }

        //to access the https address for updates ignore certificate errors, mono does not trust anything by default.
        //all subsequent https calls will use certificates
        private void IgnoreSSL() {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
        }

        private bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors) {
            return true;
        } 

        private void UseSSL() {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = null;
        }
    }
}
