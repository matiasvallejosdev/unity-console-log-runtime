using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using Random=UnityEngine.Random;
using System.Linq;

namespace Components
{
    public class ConsoleButtonInput : MonoBehaviour
    {   
        void Start()
        {
            Debug.Log("Hello World!");
        }

        public void OnClickError(string lbl)
        {
            Debug.LogError($"{lbl}"); // Error
        }
        public void OnClickLog(string lbl)
        {
            Debug.Log($"{lbl}"); // Warning
        }
        public void OnClickWarning(string lbl)
        {
            Debug.LogWarning($"{lbl}"); // Warning
        }
    }
}
