using System.Collections;
using System.Collections.Generic;
using Components;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.TestTools;

namespace Editor.Tests.EditMode.Scenes
{    
    public class ExampleSceneShould
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            EditorSceneManager.OpenScene("Assets/Scenes/Example.unity");
        }
        
        [Test]
        public void contain_console_debug_display()
        {
            var component = Object.FindObjectOfType<ConsoleDebugDisplay>();
            component.Start();
            
            Assert.NotNull(component.consoleLabel);
            Assert.NotNull(component.debugConsole);
        }

        [Test]
        public void contain_console_application_log_input()
        {
            var component = Object.FindObjectOfType<ConsoleApplicationLogInput>();
            
            Assert.NotNull(component.gameCmdFactory);
            Assert.NotNull(component.consoleData);
        }

        [Test]
        public void contain_console_application_persistance_input()
        {
            var component = Object.FindObjectOfType<ConsoleApplicationPersistanceInput>();
            
            Assert.NotNull(component.gameCmdFactory);
            Assert.NotNull(component.consoleData);
        }
    }
}
