using com.kleberswf.lib.core;
using Misc;
using Sound;
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
        private StateProperties _stateProperties;
        private Scene _currentScene;
        [SerializeField] private float _timeAttackLimit;
        private bool _gameFinished = false;

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
            _stateProperties = StateProperties.Instance;
            GameTimeElapsed = 0;

            SoundController.Instance.PlayMusic(Music.Instance.ExampleMusicClip);
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
            if (!_currentScene.name.Equals("MainScene") || _gameFinished) return;

            if (Input.GetButtonDown("Pause"))
            {
                TogglePauseGame();
//                Debug.Log("Press");
            }
            GameTimeElapsed = Time.time;
            bool timeAttackElapsed = GameTimeElapsed > _timeAttackLimit * 60;
            if (_stateProperties.isTimeAttack && timeAttackElapsed) EndGame();
            if (Mathf.Floor(GameTimeElapsed) > Mathf.Floor(_scoreController.TimeSurvived)) {
                if (_stateProperties.isTimeAttack)
                    _scoreController.UpdateTimeAttack(GameTimeElapsed, (_timeAttackLimit*60));
                else
                    _scoreController.UpdateTimeSurvived(GameTimeElapsed);
            }
        }

        private void EndGame()
        {
            _gameFinished = true;
            //Debug.Log("Game ended lol");
            GameObject.Find("Player").GetComponent<Entity.PlayerDeathController>().GameOver();
        }

        #endregion Private Methods
    }
}