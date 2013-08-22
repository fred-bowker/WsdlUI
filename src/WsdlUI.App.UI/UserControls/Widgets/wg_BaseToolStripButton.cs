using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WsdlUI.App.UI.UserControls.Widgets {
    public class wg_BaseToolStripButton : ToolStripButton {

        public wg_BaseToolStripButton() {
            
            Size = new System.Drawing.Size(55, 43);
            Font = DefaultFonts.Instance.Small;
      
        }

    }
}
