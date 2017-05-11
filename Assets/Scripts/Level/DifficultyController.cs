using System;
using com.kleberswf.lib.core;
using UnityEngine;

namespace Level
{
    public class DifficultyController : Singleton<DifficultyController>
    {
        #region Public Fields

        public float DifficultyLevel;

        #endregion Public Fields

        #region Private Fields

        private float _difficultyAdjustmentInc;
        [SerializeField] private float _interval;
        private float _timer;
        private ScoreController _scoreController;
        private int _previousScore;
        private int _previousKills;

        #endregion Private Fields

        #region Public Methods

        public void UpdateDifficulty(int enemiesKilledSinceLastInc, int secondsSinceLastHit, int gameSecondsElapsed)
        {
            _difficultyAdjustmentInc = CalculateDifficultyAdjustmentInc(enemiesKilledSinceLastInc, secondsSinceLastHit, gameSecondsElapsed);
        }

        #endregion Public Methods

        #region Private Methods

        private float CalculateDifficultyAdjustmentInc(int scoreSinceLastInc, int enemiesKilledSinceLastInc, int gameSecondsElapsed)
        {
            //TODO: Replace with an actual heuristic
            return scoreSinceLastInc + enemiesKilledSinceLastInc + gameSecondsElapsed;
        }

        // Use this for initialization
        private void Start()
        {
            _scoreController = ScoreController.Instance;
            _previousScore = 0;
            _previousKills = 0;
        }

        // Update is called once per frame
        private void Update()
        {

            _timer += Time.deltaTime;

            if (_timer < _interval) return;

            _timer -= _interval;

            var currentScore = _scoreController.CurrentScore;
            var currentKills = _scoreController.EnemiesKilled;

            var scoreInInterval = currentScore - _previousScore;
            var killsInInterval = currentKills - _previousKills;
            var secondsElapsed = _scoreController.TimeSurvived;

            UpdateDifficulty(scoreInInterval, killsInInterval, secondsElapsed);

            DifficultyLevel += _difficultyAdjustmentInc;

            _previousScore = currentScore;
            _previousKills = currentKills;

//            Debug.Log(string.Format("Difficulty Level: {0}", DifficultyLevel));
        }

        #endregion Private Methods
    }
}