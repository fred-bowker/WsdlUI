/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System.IO;

using NUnit.Framework;

using model = WsdlUI.App.Model;
using pickle = WsdlUI.App.Model.Config.Pickle;

namespace WsdlUI.App.Model.Tests
{
    [TestFixture]
    public class ProxyTests
    {        
            string _testDataDirectory;

            public ProxyTests() {
                _testDataDirectory = System.IO.Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "TestData" + Path.DirectorySeparatorChar + "WsdlUI.App.Model.Tests";
            }

            [Test]
            //Test that if the data file does not exist we are returned the proxy with defaults
            public void TestDeserializeNoFile() {

                string testDataPath = _testDataDirectory + Path.DirectorySeparatorChar + @"non_exist_file.data";

                //file should not exist at the beginning of the test
                Assert.IsFalse(File.Exists(testDataPath));

                var storageProxy = new pickle.Pickler(testDataPath);
                var configProxy = new model.Config.Proxy();

                storageProxy.Load(configProxy);

                Assert.AreEqual(configProxy.Port, 8888);
                Assert.AreEqual(configProxy.Host, "127.0.0.1");

                //the file is created on load
                Assert.IsTrue(File.Exists(testDataPath));

                //cleanup
                File.Delete(testDataPath);
            }

            [Test]
            //Test that if the data is modified then it is corretly saved and read from disk
            //tests read and write
            public void TestSerializeDeserialize() {

                string testDataPath = _testDataDirectory + Path.DirectorySeparatorChar + @"proxy-serialize-deserialize.txt";

                Assert.IsTrue(File.Exists(testDataPath));

                //first test that data is correcly read in from disk
                var storageProxy = new pickle.Pickler(testDataPath);
                var configProxy = new model.Config.Proxy();
                storageProxy.Load(configProxy);

                Assert.AreEqual(configProxy.Port, 1234);
                Assert.AreEqual(configProxy.Host, "123.4.5.6");
                Assert.AreEqual(configProxy.ProxyType, Drexyia.WebSvc.Model.Proxy.EProxyType.Disabled);
                Assert.AreEqual(configProxy.Modified, false);

                //modify data and serialize back to file
                configProxy.Port = 5678;
                configProxy.Host = "111.2.3.4";
                configProxy.ProxyType = Drexyia.WebSvc.Model.Proxy.EProxyType.Enabled;
                storageProxy.Save(configProxy);

                //read in the data again and check the values
                storageProxy = new pickle.Pickler(testDataPath);
                configProxy = new model.Config.Proxy();
                storageProxy.Load(configProxy);

                Assert.AreEqual(configProxy.Port, 5678);
                Assert.AreEqual(configProxy.Host, "111.2.3.4");
                Assert.AreEqual(configProxy.ProxyType, Drexyia.WebSvc.Model.Proxy.EProxyType.Enabled);
                Assert.AreEqual(configProxy.Modified, false);

                //set the settings back to initial so that tests can run again
                configProxy.Port = 1234;
                configProxy.Host = "123.4.5.6";
                configProxy.ProxyType = Drexyia.WebSvc.Model.Proxy.EProxyType.Disabled;
                storageProxy.Save(configProxy);
            }
        }

    }

