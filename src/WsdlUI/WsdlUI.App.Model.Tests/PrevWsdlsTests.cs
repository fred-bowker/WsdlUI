/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System.IO;
using System.Linq;
using NUnit.Framework;
using model = WsdlUI.App.Model;
using pickle = WsdlUI.App.Model.Config.Pickle;

namespace WsdlUI.App.Model.Tests {

    [TestFixture]
    public class PrevWsdlsTests {

        string _testDataDirectory;

        public PrevWsdlsTests() {
            _testDataDirectory = System.IO.Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar +  "TestData" + Path.DirectorySeparatorChar + "WsdlUI.App.Model.Tests";
        }

        [Test]
        //Test that if the data file does not exist we are returned an object with an empty list of wsdls
        public void TestDeserializeNoFile() {

            string testDataPath = _testDataDirectory + Path.DirectorySeparatorChar + @"non_exist_file.data";

            //file should not exist at the beginning of the test
            Assert.IsFalse(File.Exists(testDataPath));

            var storage = new pickle.Pickler(testDataPath);
            var config = new model.Config.PrevWsdls(0);
            storage.Load(config);

            Assert.AreEqual(config.WsdlList.Count(), 0);

            //the file is created on load
            Assert.IsTrue(File.Exists(testDataPath));

            //cleanup
            File.Delete(testDataPath);

        }

        [Test]
        public void TestModifyItem() {

            string testDataPath = _testDataDirectory + Path.DirectorySeparatorChar + @"non_exist_file.data";

            var storage = new pickle.Pickler(testDataPath);
            var config = new model.Config.PrevWsdls(5);
            storage.Load(config);

            //Test that each wsdl is added to the start of the list
            config.Add("A");
            config.Add("B");
            config.Add("C");
            config.Add("D");
            config.Add("E");

            Assert.AreEqual(config.WsdlList[0], "E");
            Assert.AreEqual(config.WsdlList[4], "A");
            Assert.AreEqual(config.WsdlList.Count(), 5);

            //Test that if an item is added to the list that exceeds the number of items the last item from the list is removed
            config.Add("F");

            Assert.AreEqual(config.WsdlList[0], "F");
            Assert.AreEqual(config.WsdlList[4], "B");
            Assert.AreEqual(config.WsdlList.Count(), 5);

            //cleanup
            File.Delete(testDataPath);
        }

        [Test]
        //Test that if the data is modified then it is corretly saved and read from disk
        //tests read and write
        public void TestSerializeDeserialize() {

            string testDataPath = _testDataDirectory + Path.DirectorySeparatorChar + @"prevwsdl-serialize-deserialize.txt";

            Assert.IsTrue(File.Exists(testDataPath));

            //first read in and check data
            var storage = new pickle.Pickler(testDataPath);
            var config = new model.Config.PrevWsdls(5);
            storage.Load(config);

            Assert.AreEqual(config.WsdlList[0], @"http://localhost:1111/service1.svc?wsdl");
            Assert.AreEqual(config.WsdlList[1], @"file://C:\service2.wsdl");
            Assert.AreEqual(config.WsdlList[2], @"http://localhost:3333/service3.svc?wsdl");
            Assert.AreEqual(config.WsdlList[3], @"file://C:\service4.wsdl");
            Assert.AreEqual(config.WsdlList[4], @"http://localhost:5555/service5.svc?wsdl");
            Assert.AreEqual(config.WsdlList.Count(), 5);
            Assert.IsFalse(config.Modified);

            //modify values and serialize to disk
            config.Add("A");
            config.Add("B");
            config.Add("C");
            config.Add("D");
            config.Add("E");
            storage.Save(config);

            //reread in the data and check
            storage = new pickle.Pickler(testDataPath);
            config = new model.Config.PrevWsdls(5);
            storage.Load(config);

            Assert.AreEqual(config.WsdlList[0], "E");
            Assert.AreEqual(config.WsdlList[1], "D");
            Assert.AreEqual(config.WsdlList[2], "C");
            Assert.AreEqual(config.WsdlList[3], "B");
            Assert.AreEqual(config.WsdlList[4], "A");
            Assert.AreEqual(config.WsdlList.Count(), 5);
            Assert.IsFalse(config.Modified);

            //set data back to previous in order that subsequent tests run
            config.Add(@"http://localhost:5555/service5.svc?wsdl");
            config.Add(@"file://C:\service4.wsdl");
            config.Add(@"http://localhost:3333/service3.svc?wsdl");
            config.Add(@"file://C:\service2.wsdl");
            config.Add(@"http://localhost:1111/service1.svc?wsdl");
            storage.Save(config);
        }

        [Test]
        //Test that if the amount of max items is modified then the number of prevwsdls is reduced
        public void TestModifyItemMaxItemsChanged() {
           
            string testDataPath = _testDataDirectory + Path.DirectorySeparatorChar + @"prevwsdl-serialize-deserialize.txt";

            Assert.IsTrue(File.Exists(testDataPath));

            //first read in and check data
            var storage = new pickle.Pickler(testDataPath);
            var config = new model.Config.PrevWsdls(2);
            storage.Load(config);

            Assert.AreEqual(config.WsdlList.Count(), 2);
            Assert.AreEqual(config.WsdlList[0], @"http://localhost:1111/service1.svc?wsdl");
            Assert.AreEqual(config.WsdlList[1], @"file://C:\service2.wsdl");

        }
    }
}
