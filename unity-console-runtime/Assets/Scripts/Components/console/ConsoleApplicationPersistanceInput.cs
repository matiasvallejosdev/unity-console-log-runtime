 using UnityEngine;
 using System.Collections;
using TMPro;
using System;
using Commands;
using ViewModel;

namespace Components
{    
    public class ConsoleApplicationPersistanceInput : MonoBehaviour
    {
        public GameCmdFactory gameCmdFactory;
        public ConsoleViewModel consoleData;

        void OnDestroy () => gameCmdFactory.consoleSave(consoleData).Execute();
    }
}