using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UniRx;
using ViewModel;
using Components;
using System;
using Commands;
using System.IO;

namespace Editor.Tests.EditMode.Commands
{
    public class ConsoleApplicationPersistanceCmdShould
    {
        private GameObject _gameObject;

        [SetUp]
        public void SetUp()
        {
            _gameObject = new GameObject();
        }

        [Test]
        public void save_log_console()
        {
            var date = DateTime.Now.ToShortDateString();
            var consoleData = ScriptableObject.CreateInstance<ConsoleViewModel>();
            bool exists_log_file = false;

            consoleData.persistenceLogs.Add("[L] First Log!");
            consoleData.persistenceLogs.Add("[E] Second Log!");

            var cmd = new ConsoleApplicationPersistanceSaveCmd(consoleData);
            cmd.Execute();
            
            string name = consoleData.persistanceSavedName;
            string fileName = $"{Application.persistentDataPath}/UNITY_LOGS_{name}.txt";
            
            if(File.Exists(fileName))
            {
                exists_log_file = true;
            }
            
            Assert.AreEqual(true, exists_log_file);
        }
    }
}
