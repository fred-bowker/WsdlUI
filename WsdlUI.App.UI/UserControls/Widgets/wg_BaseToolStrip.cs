using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WsdlUI.App.UI.UserControls.Widgets {
    public class wg_BaseToolStrip : ToolStrip {

        public wg_BaseToolStrip() {
            Height = 45;
            Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);

            Font = DefaultFonts.Instance.Small;
        }

    }
}
