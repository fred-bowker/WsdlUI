/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/



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
				Regex parser = new Regex(@"				\s*<");
				string xmlUnformatted = parser.Replace(Text, "<");

				parser = new Regex(@"				>\s*<");
				xmlUnformatted = parser.Replace(xmlUnformatted, "><");
				return xmlUnformatted;
			}
		}

		//returns null if xml syntax is valid otherwise returns validation error message
		public string FormatXml() {

			try {
				Text = XElement.Parse(Text.Trim()).ToString();
				return null;
			}
			catch (System.Xml.XmlException ex) {
				return ex.Message;

			}


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
