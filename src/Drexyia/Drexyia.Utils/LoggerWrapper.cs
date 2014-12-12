/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/


using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;

namespace Drexyia.Utils {

    //a singleton logger to be used accross applications
    public sealed class Logger {
        public ILog Log {
            get;
            private set;
        }

        Logger() {
            Log = LogManager.GetLogger(typeof(Logger));
        }

        public static Logger Instance {
            get {
                return Nested.instance;
            }
        }

        public void XmlConfig() {
            XmlConfigurator.Configure();
        }

        public void BasicConfig() {
            PatternLayout layout = new PatternLayout();
            layout.ConversionPattern = "%date [%thread] %-5level %C{2} %M - %message%newline";
            layout.ActivateOptions();

            //the ColoredConsoleAppender is not available in mono so use a standard console appender
#if __MonoCS__                       
            log4net.Appender.ConsoleAppender appender = new log4net.Appender.ConsoleAppender();
            appender.Layout = layout;
            appender.ActivateOptions();

            BasicConfigurator.Configure(appender);
#else
            log4net.Appender.ColoredConsoleAppender appender = new log4net.Appender.ColoredConsoleAppender();
            appender.Layout = layout;

            ColoredConsoleAppender.LevelColors errorMapping = new ColoredConsoleAppender.LevelColors();
            errorMapping.BackColor = ColoredConsoleAppender.Colors.HighIntensity | ColoredConsoleAppender.Colors.Red;
            errorMapping.ForeColor = ColoredConsoleAppender.Colors.White;
            errorMapping.Level = Level.Error;
            ColoredConsoleAppender.LevelColors infoMapping = new ColoredConsoleAppender.LevelColors();
            infoMapping.ForeColor = ColoredConsoleAppender.Colors.Green;
            infoMapping.Level = Level.Info;
            ColoredConsoleAppender.LevelColors debugMapping = new ColoredConsoleAppender.LevelColors();
            debugMapping.ForeColor = ColoredConsoleAppender.Colors.Blue;
            debugMapping.Level = Level.Debug;
            appender.AddMapping(errorMapping);
            appender.AddMapping(infoMapping);
            appender.AddMapping(debugMapping);

            appender.ActivateOptions();

            BasicConfigurator.Configure(appender);
#endif
        }

        class Nested {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested() {
            }

            internal static readonly Logger instance = new Logger();
        }
    }
}
