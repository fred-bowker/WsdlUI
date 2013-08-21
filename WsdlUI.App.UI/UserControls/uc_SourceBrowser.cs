/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System;
using System.IO;
using System.Text;
using System.Windows.Forms;


namespace WsdlUI.App.UI.UserControls {
    public partial class uc_SourceBrowser : UserControl {
        public uc_SourceBrowser() {
            InitializeComponent();
        }

        //The other way to display the xml is to set the document text property and setting the xslt
        //this method is overkill and involves modifying the default xslt of ie or firefox
        //The method used here SHOULD use the default style sheets for the currently installed IE
        public void PopulateForm (string sourceXML)
  {
   string tempfilePath = string.Format (@"{0}{1}{2}{1}{3}.xml", Directory.GetCurrentDirectory (), Path.DirectorySeparatorChar, Consts.TempDirectory, Guid.NewGuid ());

   File.WriteAllText (tempfilePath, sourceXML, Encoding.UTF8);

   wb_source.AllowNavigation = true;
            wb_source.Navigate(tempfilePath);
        }

        public void Clear() {
            wb_source.DocumentText = null;
        }
    }
}
