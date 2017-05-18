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
        [SerializeField] GameObject _startScreenCanvas;
        [SerializeField] GameObject _controlsCanvas;

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

        public void ShowControls()
        {
            _startScreenCanvas.SetActive(false);

            _controlsCanvas.SetActive(true);
            var backButton = GameObject.Find("btnBack").GetComponent<Button>();
            backButton.Select();
        }

        public void HideControls()
        {
            _controlsCanvas.SetActive(false);

            _startScreenCanvas.SetActive(true);
            var playGameButton = GameObject.Find("btnPlayGame").GetComponent<Button>();
            playGameButton.Select();
        }
    }
}