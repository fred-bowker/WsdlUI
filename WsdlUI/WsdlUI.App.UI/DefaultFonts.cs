/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System.Drawing;


namespace WsdlUI.App.UI {

    public sealed class DefaultFonts {

        public Font Large {
            get;
            private set;
        }

        public Font Medium {
            get;
            private set;
        }

        public Font Small {
            get;
            private set;
        }

        public Font Smaller {
            get;
            private set;
        }

        DefaultFonts() {

            //Consolas is a windows font
            //Inconsolata is an open font similar to Consolas it can be installed on Windows and Linux
            //Courier New sould be installed on Windows and Linux
            string fontName = "Consolas";
            bool result = IsFontInstalled(fontName);
            if (!result) {
                fontName = "Inconsolata";
                result = IsFontInstalled(fontName);

                if (!result) {
                    fontName = "Courier New";
                    result = IsFontInstalled(fontName);
                    if (!result) {
                        //process.Logger.Instance.Log.Info("no default font found");
                    }
                }
            }

            //process.Logger.Instance.Log.Info("using font: " + fontName);

            Smaller = new System.Drawing.Font(fontName, 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Small =  new System.Drawing.Font(fontName, 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Medium = new System.Drawing.Font(fontName, 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Large = new System.Drawing.Font(fontName, 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        bool IsFontInstalled(string fontName) {
            using (Font fontTester = new Font(fontName, 12, FontStyle.Regular, GraphicsUnit.Pixel)) {
                return (fontTester.Name == fontName);
            }
        }

        public static DefaultFonts Instance {
            get {
                return Nested.instance;
            }
        }

        class Nested {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested() {
            }

            internal static readonly DefaultFonts instance = new DefaultFonts();
        }
    }
}

