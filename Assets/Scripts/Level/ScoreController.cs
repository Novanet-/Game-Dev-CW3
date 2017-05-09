using System;
using com.kleberswf.lib.core;
using Entity;
using UI;
using UnityEngine;

namespace Level
{
    public class ScoreController : Singleton<ScoreController>
    {
        #region Private Fields

        private UIController _uiController;

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

        #endregion Internal Methods

        #region Private Methods

        // Use this for initialization
        private void Start()
        {
            CurrentScore = 0;
            EnemiesKilled = 0;
            TimeSurvived = 0;
        }

        // Update is called once per frame
        private void Update()
        {
            _uiController = UIController.Instance;
        }

        #endregion Private Methods
    }
}