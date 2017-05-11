using com.kleberswf.lib.core;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level
{
    public class GameController : Singleton<GameController>
    {
        #region Private Fields

        private float _lastTimeRecorded;
        private ScoreController _scoreController;
        private UIController _uiController;
        private Scene _currentScene;

        #endregion Private Fields

        #region Public Properties

        public float GameTimeElapsed { get; private set; }

        public bool IsPaused { get; set; }

        #endregion Public Properties

        #region Private Methods

        // Use this for initialization
        private void Start()
        {
            _currentScene = SceneManager.GetActiveScene();
            if (!_currentScene.name.Equals("MainScene")) return;

            _scoreController = ScoreController.Instance;
            _uiController = UIController.Instance;
            GameTimeElapsed = 0;
        }

        private void TogglePauseGame()
        {
            IsPaused = !IsPaused;
            Time.timeScale = 1 - Time.timeScale;
            _uiController.TogglePauseUI();
        }

        // Update is called once per frame
        private void Update()
        {
            if (!_currentScene.name.Equals("MainScene")) return;

            if (Input.GetButtonDown("Pause"))
            {
                TogglePauseGame();
//                Debug.Log("Press");
            }
            GameTimeElapsed = Time.time;
            if (Mathf.Floor(GameTimeElapsed) > Mathf.Floor(_scoreController.TimeSurvived)) _scoreController.UpdateTimeSurvived(GameTimeElapsed);
        }

        #endregion Private Methods
    }
}