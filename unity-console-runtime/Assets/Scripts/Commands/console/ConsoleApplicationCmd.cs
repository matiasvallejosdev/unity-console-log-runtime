
using System;
using UnityEngine;
using ViewModel;

public class ConsoleApplicationCmd : ICommand
{
    private readonly ConsoleViewModel consoleData;
    private LogType type;
    private string logString;

    public ConsoleApplicationCmd(ConsoleViewModel consoleData, LogType type, string logString)
    {
        this.consoleData = consoleData;
        this.type = type;
        this.logString = logString;
    }

    public void Execute()
    {
        consoleData.logInput.Value = new LogData{
           time = DateTime.Now.ToString("HH:mm:ss"),
           type = type,
           body = logString
       };

        string log = $"[{type.ToString().Substring(0,1).ToUpper()}][{consoleData.logInput.Value.time}] " + consoleData.logInput.Value.body;
        consoleData.persistenceLogs.Add(log);
    }
}
