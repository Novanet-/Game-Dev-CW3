using System;
using com.kleberswf.lib.core;
using Misc;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class StartUIController : Singleton<StartUIController>
    {
        public void PlayGame(bool isTimeAttack)
        {
            Debug.Log("Play");
            StateProperties.Instance.isTimeAttack = isTimeAttack;
            SceneManager.LoadSceneAsync("MainScene");
        }

        public void QuitGame()
        {
            Debug.Log("Quit");
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }
}