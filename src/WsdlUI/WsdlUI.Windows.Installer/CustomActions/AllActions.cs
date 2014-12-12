/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Deployment.WindowsInstaller;
using System.IO;

using System.Security.Principal;

namespace CustomActions
{
    public class AllActions
    {
        [CustomAction]
        public static ActionResult GetGlobalGroupNames(Session session)
        {
            session.Log("Drexyia - GetGlobalGroupNames - Begin");

            var sid = new SecurityIdentifier(WellKnownSidType.BuiltinUsersSid, null);
            var account = (NTAccount)sid.Translate(typeof(NTAccount));

            session["UsersAccount"] = account.Value;
            session.Log("Drexyia - GetGlobalGroupNames - UserAccount " + account.Value);

            return ActionResult.Success;
        }

        [CustomAction]
        public static ActionResult RemoveConfigFiles(Session session)
        {
            session.Log("Drexyia - RemoveConfigFiles - Begin");

            try
            {
                string outputDirectory = session["InstDir_OutputFolders"];
                foreach (var directory in Directory.GetDirectories(outputDirectory))
                {
                    Directory.Delete(directory, true);
                }
            }
            catch (Exception ex)
            {
                //yes I know we shouldnt catch general exceptions however the backupConfigFiles section is not critical to the install
                session.Log("Drexyia - RemoveConfigFiles - Error - " + ex.ToString());
            }

            return ActionResult.Success;

        }

        [CustomAction]
        //on upgrade or reinstall backup the config files then restore them 
        //config files are prev_url.data, prev_wsdl.data, proxy.data, startupWsdls.data, timeout.data, update.data 
        public static ActionResult BackupConfigFiles(Session session)
        {

            try
            {
                string outputDirectory = session["InstDir_OutputFolders"];
                string configDirectory = outputDirectory + Path.DirectorySeparatorChar + "config";
                //a backup directory of the format config_bak_16_07_2014
                string backupConfigDirectory = outputDirectory + Path.DirectorySeparatorChar + "config_bak_" + DateTime.Now.ToString("dd_MM_yyyy");

                if (Directory.Exists(configDirectory))
                {
                    session.Log("Drexyia - BackupConfigFiles - upgrade or reinstall - config - backup directory: " + backupConfigDirectory);

                    //the backup will only be used on install, we are using a datestamp with no timestamp so if the install is run multiple
                    //times on the same day then ignore subsequent installs
                    if (Directory.Exists(backupConfigDirectory))
                    {
                        return ActionResult.Success;
                    }

                    Directory.CreateDirectory(backupConfigDirectory);
                    CopyConfigFiles(configDirectory, backupConfigDirectory);
                }
                else
                {
                    session.Log("Drexyia - BackupConfigFiles - install - no config directory backup: " + configDirectory);
                }
            }
            catch (Exception ex)
            {
                //yes I know we shouldnt catch general exceptions however the backupConfigFiles section is not critical to the install
                session.Log("Drexyia - BackupConfigFiles - Error " + ex.ToString());
            }

            return ActionResult.Success;
        }

        [CustomAction]
        public static ActionResult RestoreConfigFiles(Session session)
        {
            try
            {
                string outputDirectory = session.CustomActionData["OutputDirectory"];
                string configDirectory = outputDirectory + Path.DirectorySeparatorChar + "config";
                //a backup directory of the format config_bak_16_07_2014
                string backupConfigDirectory = outputDirectory + Path.DirectorySeparatorChar + "config_bak_" + DateTime.Now.ToString("dd_MM_yyyy");

                //checking for the config directory means that files are not copied on unistall as the config directory will have been removed during the uninstall
                if (Directory.Exists(backupConfigDirectory) && Directory.Exists(configDirectory))
                {
                    session.Log("Drexyia - RestoreConfigFiles - upgrade or reinstall - config - backup directory: " + backupConfigDirectory);
                    CopyConfigFiles(backupConfigDirectory, configDirectory);
                }
                else
                {
                    session.Log("Drexyia - RestoreConfigFiles - install - no config directory backup: " + configDirectory);
                }
            }
            catch (Exception ex)
            {
                //yes I know we shouldnt catch general exceptions however the backupConfigFiles section is not critical to the install
                session.Log("Drexyia - RestoreConfigFiles - Error - " + ex.ToString());
            }

            return ActionResult.Success;
        }


        static void CopyConfigFiles(string source, string target)
        {
            //copy the data files
            string[] dataFiles = new string[] {
                "prev_url.data", "prev_wsdl.data", "proxy.data", "startupWsdls.data", "timeout.data", "update.data" 
            };

            foreach (var dataFile in dataFiles)
            {
                var sourcePath = source + Path.DirectorySeparatorChar + dataFile;
                var targetPath = target + Path.DirectorySeparatorChar + dataFile;

                //the data file may have been moved for some reason by the user so check if it exists
                if (File.Exists(sourcePath))
                {
                    //overwrite the file for when restoring config files
                    File.Copy(sourcePath, targetPath, true);
                }
            }
        }
    }
}
