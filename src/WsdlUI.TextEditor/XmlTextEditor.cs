using System;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using ICSharpCode.Addons;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;

namespace WsdlUI.TextEditor {
    public class XmlTextEditor : TextEditorControl {

        public string XmlUnformatted {
            get {
                //<Operation xmlns="">VOID
                //</Operation>
                Regex parser = new Regex(@"\s*<");
                string xmlUnformatted = parser.Replace(Text, "<");

                parser = new Regex(@">\s*<");
                xmlUnformatted = parser.Replace(xmlUnformatted, "><");
                return xmlUnformatted;
            }
        }

        public void FormatXml() {
            Text = XElement.Parse(Text).ToString();
        }

        public XmlTextEditor() {
            Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("XML");
            Document.FoldingManager.FoldingStrategy = new XmlFoldingStrategy();
            Document.FormattingStrategy = new XmlFormattingStrategy();
            TextEditorProperties = InitializeProperties();
            Document.FoldingManager.UpdateFoldings(null, null);
            Document.DocumentChanged += Document_DocumentChanged;
        }

        void Document_DocumentChanged(object sender, DocumentEventArgs e) {
            Document.FoldingManager.UpdateFoldings(null, null);
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
