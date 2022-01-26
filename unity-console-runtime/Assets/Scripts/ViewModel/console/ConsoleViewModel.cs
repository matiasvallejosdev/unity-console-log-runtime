using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace ViewModel
{
    [CreateAssetMenu(fileName = "New DebugConsole", menuName = "Data/Debug Console")]
    public class ConsoleViewModel : ScriptableObject
    {
        public ReactiveProperty<LogData> logInput = new ReactiveProperty<LogData>(new LogData(){
                type = LogType.Log,
                body = ""
            });

        public int maxToDisplay;
        public bool showLogMessage;
        public bool showLogError;
        public bool showLogWarning;
        
        public List<string> persistenceLogs = new List<string>();
        public string persistanceSavedName = "";
    }
}
