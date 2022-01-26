 using UnityEngine;
 using System.Collections;
using TMPro;
using System;
using Commands;
using ViewModel;

namespace Components
{    
    public class ConsoleApplicationLogInput : MonoBehaviour
    {
        public GameCmdFactory gameCmdFactory;
        public ConsoleViewModel consoleData;

        void OnEnable () => Application.logMessageReceived += OnLogHandler;
        void OnDisable () => Application.logMessageReceived -= OnLogHandler;

        private void OnLogHandler(string logString, string stackTrace, LogType type)
        {
            gameCmdFactory.consoleApplication(consoleData, type, logString).Execute();
        }
    }
}