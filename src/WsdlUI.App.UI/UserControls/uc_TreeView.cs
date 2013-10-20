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
using websvcasync = WsdlUI.App.Process.WebSvcAsync;

namespace WsdlUI.App.UI.UserControls {
    public partial class uc_TreeView : UserControl {
        public event Action AddClicked;
        public event Action<string> RemoveClicked;
        public event Action<string, string> WebMethodClicked;
        public event Action<string> WebServiceClicked;

        public uc_TreeView() {
            InitializeComponent();

            imgList_All.Images.Add("view-list-tree-4.png", global::WsdlUI.App.UI.Properties.Resources.view_list_tree_4);
            imgList_All.Images.Add("wsdl.png", global::WsdlUI.App.UI.Properties.Resources.wsdl);
            imgList_All.Images.Add("bullet_purple.png", global::WsdlUI.App.UI.Properties.Resources.bullet_purple);
            imgList_All.Images.Add("bullet_green.png", global::WsdlUI.App.UI.Properties.Resources.bullet_green);
        }

        void tsbButtonAdd_Click(object sender, EventArgs e) {
            if (AddClicked != null) {
                AddClicked();
            }
        }

        public void AddClickedComplete(websvcasync.Result.RetrieveAsyncResult item) {
            this.Invoke(new MethodInvoker(delegate() {
                tv_webServices.BeginUpdate();

                var wsNode = new TreeNode(item.WebSvcResult.SourceURI);
                wsNode.ImageKey = "wsdl.png";
                wsNode.SelectedImageKey = "wsdl.png";
                wsNode.Name = item.WebSvcResult.SourceURI;
                wsNode.Tag = WSNodeType.WebServiceNode;
                wsNode.ContextMenuStrip = cms_AddRemoveStartup;

                foreach (var webMethod in item.WebSvcResult.WebSvcMethods) {
                    TreeNode wmNode = new TreeNode(webMethod.Key);
                    wmNode.ImageKey = "bullet_purple.png";
                    wmNode.SelectedImageKey = "bullet_green.png";
                    wmNode.Name = webMethod.Key;
                    wmNode.Tag = WSNodeType.WebMethodNode;
                    wsNode.Nodes.Add(wmNode);
                }

                var root = tv_webServices.Nodes[0];
                root.Nodes.Add(wsNode);

                tv_webServices.ExpandAll();

                tv_webServices.EndUpdate();


            }));
        }

        void tv_webServices_AfterSelect(object sender, TreeViewEventArgs e) {
            WSNodeType nodeType = (WSNodeType)e.Node.Tag;

            //when running on mono removing a node fires the select event and causes an exception
            //checking the action means that we only handle the event on ByMouse action
            if (e.Action != TreeViewAction.Unknown) {

                if (nodeType == WSNodeType.WebServiceNode) {

                    process.Logger.Instance.Log.Info("Start: Node Type WebServiceNode " + e.Node.Name);

                    if (WebServiceClicked != null) {
                        WebServiceClicked(e.Node.Name);
                    }
                }
                else if (nodeType == WSNodeType.WebMethodNode) {

                    string webServiceName = e.Node.Parent.Name;

                    process.Logger.Instance.Log.Info("Start: Node Type WebMethodNode " + webServiceName + " " + e.Node.Name);

                    if (WebMethodClicked != null) {

                        WebMethodClicked(webServiceName, e.Node.Name);
                    }
                }
            }
        }

        void tsBtnRemove_Click(object sender, EventArgs e) {

            Remove();

        }

        private void uc_TreeView_Load(object sender, EventArgs e) {
            var root = tv_webServices.Nodes[0];
            root.Tag = WSNodeType.RootNode;
            root.SelectedImageKey = "view-list-tree-4.png";

            Font = DefaultFonts.Instance.Small;
            tv_webServices.Font = DefaultFonts.Instance.Medium;

        }

        private void mi_Add_Startup_Click(object sender, EventArgs e) {
            State.Instance.ConfigStartupWsdls.AddWsdl(tv_webServices.SelectedNode.Name);
        }

        private void mi_Remove_Startup_Click(object sender, EventArgs e) {
            State.Instance.ConfigStartupWsdls.RemoveWsdl(tv_webServices.SelectedNode.Name);
        }

        private void tv_webServices_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {

                TreeNode clickedNode = tv_webServices.GetNodeAt(e.Location);
                tv_webServices.SelectedNode = clickedNode;

                bool startupContainsWsdl = State.Instance.ConfigStartupWsdls.ContainsWsdl(clickedNode.Name);
                mi_Add_Startup.Visible = !startupContainsWsdl;
                mi_Remove_Startup.Visible = startupContainsWsdl;

            }
        }

        private void mi_Remove_Click(object sender, EventArgs e)
        {
            Remove();
        }

        void Remove()
        {
            if (tv_webServices.SelectedNode == null)
            {
                return;
            }

            WSNodeType nodeType = (WSNodeType)tv_webServices.SelectedNode.Tag;

            if (nodeType == WSNodeType.WebServiceNode)
            {

                process.Logger.Instance.Log.Info("Start: Node Type WebServiceNode " + tv_webServices.SelectedNode.Name);

                if (RemoveClicked != null)
                {
                    RemoveClicked(tv_webServices.SelectedNode.Name);
                }

                tv_webServices.SelectedNode.Remove();

            }
            else if (nodeType == WSNodeType.WebMethodNode)
            {

                process.Logger.Instance.Log.Info("Start: Node Type WebMethodNode " + tv_webServices.SelectedNode.Parent.Name);

                if (RemoveClicked != null)
                {
                    RemoveClicked(tv_webServices.SelectedNode.Parent.Name);
                }

                tv_webServices.SelectedNode.Parent.Remove();
            }

        }

        private void copyUriToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string uri = tv_webServices.SelectedNode.Name;
            Clipboard.SetText(uri);
        }
    }
}
