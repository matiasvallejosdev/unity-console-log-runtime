
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using ViewModel;

namespace Commands
{
    public class ConsoleApplicationPersistanceSaveCmd : ICommand
    {
        private ConsoleViewModel consoleData;

        public ConsoleApplicationPersistanceSaveCmd(ConsoleViewModel consoleData)
        {
            this.consoleData = consoleData;
        }

        public void Execute()
        {
            var date = DateTime.Now.ToShortDateString();
            var name = System.IO.Path.GetRandomFileName();
            consoleData.persistanceSavedName = name;

            string fileName = $"{Application.persistentDataPath}/UNITY_LOGS_{name}.txt";
            WriteFile(fileName);
        }

        void WriteFile(string pathString)
        {
            try    
            {        
                if (File.Exists(pathString))    
                {    
                    File.Delete(pathString);    
                }

                FileStream fs = File.Create(pathString);
                fs.Close();       

                File.WriteAllLines(pathString, consoleData.persistenceLogs.ToArray());
                Debug.Log($"Successful saved logs in {pathString}");
            }    
            catch (Exception e)    
            {    
                string error = e.Message.ToString();
                Debug.LogError(error);
            } 
        }
    }
}