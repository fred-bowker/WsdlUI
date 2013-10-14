/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System;

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
