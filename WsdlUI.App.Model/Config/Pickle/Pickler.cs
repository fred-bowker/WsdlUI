/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System.IO;

namespace WsdlUI.App.Model.Config.Pickle {
    public class Pickler {
        string _filePath;

        public Pickler(string filePath) {
            _filePath = filePath;
        }

        public void Save(IModelPickle saveItem) {
            try {
                if (saveItem.Modified) {
                    File.WriteAllLines(_filePath, saveItem.Serialize());
                }
            } //if running multiple instances of the application the file may already being read. Then HIDE exception.
            catch (IOException) {
            }
        }

        public void Load(IModelPickle loadItem) {
            try {
                if (File.Exists(_filePath)) {
                    string[] fileData = File.ReadAllLines(_filePath);
                    if (fileData.Length != 0) {
                        loadItem.Deserialize(fileData);
                    }
                }
            } //if running multiple instances of the application the file may already being read. Then HIDE exception.
            catch (IOException) {
            }

        }
    }
}
