using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UniRx;
using ViewModel;
using Components;

namespace Editor.Tests.EditMode.Commands
{
    public class ConsoleApplicationCmdShould
    {
        private GameObject _gameObject;

        [SetUp]
        public void SetUp()
        {
            _gameObject = new GameObject();
        }

        [Test]
        public void add_log_console()
        {
            var consoleData = ScriptableObject.CreateInstance<ConsoleViewModel>();

            var type = LogType.Log;
            var logString = "Hello World";

            var cmd = new ConsoleApplicationCmd(consoleData, type, logString);
            cmd.Execute();
            
            Assert.AreEqual("Hello World", consoleData.logInput.Value.body);
        }
    }
}
