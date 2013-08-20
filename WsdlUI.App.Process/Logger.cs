/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/


using log4net;
using log4net.Config;

namespace WsdlUI.App.Process
{
    public sealed class Logger
    {
        public ILog Log {
            get;
            private set;
        }

        Logger()
        {
            Log = LogManager.GetLogger(typeof(Logger));
            XmlConfigurator.Configure();
        }

        public static Logger Instance
        {
            get
            {
                return Nested.instance;
            }
        }

        class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }

            internal static readonly Logger instance = new Logger();
        }
    }
}
