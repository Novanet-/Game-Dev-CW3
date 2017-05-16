using System;
using com.kleberswf.lib.core;
using Entity;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level
{
    public class ScoreController : Singleton<ScoreController>
    {
        #region Private Fields

        private UIController _uiController;
        private Scene _currentScene;

        #endregion Private Fields

        #region Public Properties

        public int CurrentScore { get; private set; }
        public int EnemiesKilled { get; private set; }
        public int TimeSurvived { get; private set; }

        #endregion Public Properties

        #region Internal Methods

        internal void AddKilledEnemy(EnemyController enemy)
        {
            CurrentScore += enemy.ScoreValue;
            ++EnemiesKilled;
            _uiController.UpdateScore(CurrentScore);
            _uiController.UpdateKills(EnemiesKilled);
        }

        internal void UpdateTimeSurvived(float currentGameTimeElapsed)
        {
            TimeSurvived = Convert.ToInt32(Mathf.Floor(currentGameTimeElapsed));
            _uiController.UpdateTime(TimeSurvived);
        }

        internal void UpdateTimeAttack(float timeElapsed, float timeMax) {
            TimeSurvived = Convert.ToInt32(Mathf.Floor(timeElapsed));
            _uiController.UpdateTime((int)timeMax - TimeSurvived);
        }

        #endregion Internal Methods

        #region Private Methods

        // Use this for initialization
        private void Start()
        {
            _currentScene = SceneManager.GetActiveScene();
            if (!_currentScene.name.Equals("MainScene")) return;

            CurrentScore = 0;
            EnemiesKilled = 0;
            TimeSurvived = 0;
            _uiController = UIController.Instance;
        }

        // Update is called once per frame
        private void Update()
        {
        }

        #endregion Private Methods
    }
}