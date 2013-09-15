using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Addons;
using ICSharpCode.TextEditor.Document;

namespace WsdlUI.App.UI.UserControls.Widgets {
    public class wg_XmlTextEditor : TextEditorControl {

        public wg_XmlTextEditor() {
            Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("XML");
            Document.FoldingManager.FoldingStrategy = new XmlFoldingStrategy();
            Document.FormattingStrategy = new XmlFormattingStrategy();
            TextEditorProperties = InitializeProperties();
            Document.FoldingManager.UpdateFoldings(string.Empty, null);
            TextArea.Refresh(base.TextArea.FoldMargin);
            Document.DocumentChanged += Document_DocumentChanged;
        }

        void Document_DocumentChanged(object sender, DocumentEventArgs e) {
            Document.FoldingManager.UpdateFoldings(string.Empty, null);
            TextArea.Refresh(base.TextArea.FoldMargin);
        }


        ITextEditorProperties InitializeProperties() {
            var properties = new DefaultTextEditorProperties();
            properties.IndentStyle = IndentStyle.Smart;
            properties.ShowSpaces = false;
            properties.LineTerminator = Environment.NewLine;
            properties.ShowTabs = false;
            properties.ShowInvalidLines = false;
            properties.ShowEOLMarker = false;
            properties.TabIndent = 2;
            properties.ShowLineNumbers = false;
            properties.CutCopyWholeLine = true;
            properties.LineViewerStyle = LineViewerStyle.None;
            properties.MouseWheelScrollDown = true;
            properties.MouseWheelTextZoom = true;
            properties.AllowCaretBeyondEOL = false;
            properties.AutoInsertCurlyBracket = true;
            properties.BracketMatchingStyle = BracketMatchingStyle.After;
            properties.ConvertTabsToSpaces = false;
            properties.ShowMatchingBracket = true;
            properties.EnableFolding = true;
            properties.ShowVerticalRuler = false;
            properties.Encoding = System.Text.Encoding.Unicode;
            properties.ShowLineNumbers = false;
            properties.IsIconBarVisible = false;

            return properties;
        }

    
    
    }
}
