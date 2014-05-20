/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System;
using System.Windows.Forms;
using CommandLine;
using CommandLine.Text;
using drexProcess = Drexyia.WebSvc.Process;
using utils = Drexyia.Utils;

namespace WsdlUI.App.UI.Console {

    class Options {

        [Option("request-uri", Required = false, HelpText = "A wsdl to load on startup.")]
        public string RequestUri {
            get;
            set;
        }

        [Option("debug", DefaultValue = false, HelpText = "Prints logging output to the console, can also be set in app.config.")]
        public bool Debug {
            get;
            set;
        }

        [ParserState]
        public IParserState LastParserState {
            get;
            set;
        }

        [HelpOption]
        public string GetUsage() {
            HelpText ht = HelpText.AutoBuild(this, current => HelpText.DefaultParsingErrorsHandler(this, current));
            ht.MaximumDisplayWidth = 160;
            ht.Heading = "\nWsdlUI-Console";
            ht.Copyright = "Copyleft GPL v3";

            return ht.ToString();
        }
    }
    
    class Program {

        [STAThread]
        static void Main(string[] args) {

            var options = new Options();
            var parser = new CommandLine.Parser(with => with.HelpWriter = System.Console.Error);

            if (parser.ParseArguments(args, options)) {

                if (options.Debug) {

                    utils.Logger.Instance.BasicConfig();
                }
                else {
                    utils.Logger.Instance.XmlConfig();
                }

                utils.Logger.Instance.Log.Info("Program Start");
                utils.Logger.Instance.Log.Info("Arg RequestUri: " + options.RequestUri);
               
                Run(options);
            }
        }

        static void Run(Options options) {

            Application.ThreadException += Application_ThreadException;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try {

                var mainForm = (options.RequestUri != null)
                  ? new UI.FormMain(options.RequestUri)
                  : new UI.FormMain();

                //mainForm.OnException += mainForm_OnException;

                Application.Run(mainForm);

                mainForm.CleanUp();
   
            }
            catch (Exception ex) //handle exception on startup
            {
                System.Console.WriteLine(ex.ToString());
            }
        }

        static void mainForm_OnException(object sender, drexProcess.WebSvcAsync.EventParams.ExceptionAsyncArgs e) {
            
            System.Console.WriteLine(e.Ex.ToString());
        
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e) {

            System.Console.WriteLine(e.Exception.ToString());

        }
    }
}
