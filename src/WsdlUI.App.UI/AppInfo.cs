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

