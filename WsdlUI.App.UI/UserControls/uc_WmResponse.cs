/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/


using System;
using System.Collections.Generic;
using System.Windows.Forms;

using websvcasync = WsdlUI.App.Process.WebSvcAsync;

namespace WsdlUI.App.UI.UserControls
{
    public partial class uc_WmResponse : UserControl
    {
        public uc_WmResponse()
        {
            InitializeComponent();
        }

        public void PopulateForm(websvcasync.Result.CallAsyncResult result)
        {
            uc_responseMessage.PopulateForm(result.ResponseMessage);

            Dictionary<string, StringProperty> propGridValues = new Dictionary<string, StringProperty>();
            propGridValues["Status"] = new StringProperty(result.Status, "Response Status", new List<Attribute>(), true);
            foreach (var keyValue in result.Headers)
            {
                propGridValues[keyValue.Key] = new StringProperty(keyValue.Value, "Response Headers", new List<Attribute>(), true);
            }

            pg_responseHeaders.SelectedObject = new DictionaryPropertyGridAdapter(propGridValues);
        }

        public void Clear()
        {
            pg_responseHeaders.SelectedObject = null;
            uc_responseMessage.Clear();
        }

        private void uc_WmResponse_Load(object sender, EventArgs e) {
            Font = DefaultFonts.Instance.Small;
        }


    }

    
  

   

   

   

}
