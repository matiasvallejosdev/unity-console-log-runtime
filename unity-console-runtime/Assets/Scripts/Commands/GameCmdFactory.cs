using UnityEngine;
using ViewModel;

namespace Commands
{    
    [CreateAssetMenu(fileName = "GameCmdFactory", menuName = "unity-console-runtime/GameCmdFactory", order = 0)]
    public class GameCmdFactory : ScriptableObject 
    {
        public ConsoleApplicationCmd consoleApplication(ConsoleViewModel consoleData, LogType type, string logString)
        {
            return new ConsoleApplicationCmd(consoleData, type, logString);
        }    
        public ConsoleApplicationPersistanceSaveCmd consoleSave(ConsoleViewModel consoleData)
        {
            return new ConsoleApplicationPersistanceSaveCmd(consoleData);
        }    
    }
}
