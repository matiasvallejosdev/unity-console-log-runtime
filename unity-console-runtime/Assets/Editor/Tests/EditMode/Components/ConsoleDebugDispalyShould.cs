using System.Collections;
using System.Collections.Generic;
using Components;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.TestTools;
using ViewModel;
using UniRx;
using System.Linq;
using System;

namespace Editor.Tests.EditMode.Components
{
    public class ConsoleDebugDispalyShould
    {
        private GameObject _gameObject;
        private TextMeshProUGUI _textField;

        [SetUp]
        public void SetUp()
        {
            _gameObject = new GameObject();
            _textField = _gameObject.AddComponent<TextMeshProUGUI>();
            _textField.text = "";
        }

        [Test]
        public void show_log_console()
        {
            var component = _gameObject.AddComponent<ConsoleDebugDisplay>();
            component.consoleLabel = _textField;
            component.debugConsole = ScriptableObject.CreateInstance<ConsoleViewModel>();
            component.debugConsole.maxToDisplay = 10;
            component.debugConsole.showLogError = true;
            component.debugConsole.showLogMessage = true;
            component.debugConsole.showLogWarning = true;
            
            component.Start();

            component.debugConsole.logInput.Value = new LogData(){
                    time = DateTime.Now.ToString("HH:mm:ss"),
                    type = LogType.Log,
                    body = "Hello World"
                };
                
            var reverse = _textField.text.Split(' ').Reverse();
            string output = reverse.Take(2).Last() + " " + reverse.Take(1).Last();

            Assert.AreEqual("Hello World", output);
            Assert.IsNotEmpty(_textField.text);
        }
    }
}
