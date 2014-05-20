/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace WsdlUI.App.UI {

    public sealed class AppInfo {
        string _helpLicensePath = Path.Combine(Consts.LicenseDirectory,"LICENSE.md");

        public string WebSite {
            get;
            private set;
        }
        public string Version {
            get;
            private set;
        }

        public string Developer {
            get;
            private set;
        }

        public string License {
            get;
            private set;
        }

        AppInfo() {
            Assembly assembly = Assembly.GetEntryAssembly();

            Version = assembly.GetName().Version.ToString(3);

            WebSite = ((AssemblyCompanyAttribute)Attribute.GetCustomAttribute(
                 assembly, typeof(AssemblyCompanyAttribute), false))
                .Company;

            Developer = ((AssemblyDescriptionAttribute)Attribute.GetCustomAttribute(
               assembly, typeof(AssemblyDescriptionAttribute), false))
              .Description;

            string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + Path.DirectorySeparatorChar + _helpLicensePath;

            //the license file should always be saved with unix line endings, this is the standard for the project
            string textWithUnixLineEndings = File.ReadAllText(path);
            string correctLineEnding = Regex.Replace(textWithUnixLineEndings, "\n", Environment.NewLine, RegexOptions.Multiline);

            License = correctLineEnding;
        }

        public static AppInfo Instance {
            get {
                return Nested.instance;
            }
        }

        class Nested {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested() {
            }

            internal static readonly AppInfo instance = new AppInfo();
        }
    }
}

