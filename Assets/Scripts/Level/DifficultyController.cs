using System;
using com.kleberswf.lib.core;
using Misc;
using UI;
using UnityEngine;

namespace Level
{
    public class DifficultyController : Singleton<DifficultyController>
    {
        #region Public Fields

        public float DifficultyLevel;

        public float ScoreFactorMult;
        public float TimeFactorMult;

        #endregion Public Fields

        #region Private Fields

        [SerializeField] private float _maxDifficulty = 9f;
        [SerializeField] private float _minDifficulty = 0f;
        [SerializeField] private int _averageScoreForInterval;
        private float _difficultyAdjustmentInc;
        [SerializeField] private float _interval;
        private int _previousScore;
        private ScoreController _scoreController;
        private float _timer;
        private UIController _uiController;

        #endregion Private Fields

        #region Public Methods

        public void UpdateDifficulty(int scoreInInterval, int gameSecondsElapsed)
        {
            _difficultyAdjustmentInc = CalculateDifficultyAdjustmentInc(scoreInInterval, gameSecondsElapsed);
        }

        #endregion Public Methods

        #region Private Methods

        private float CalculateDifficultyAdjustmentInc(int scoreSinceLastInc, int gameSecondsElapsed)
        {
            //TODO: Replace with an actual heuristic
            float scoreFactor = scoreSinceLastInc * ScoreFactorMult;
            float timeFactor = gameSecondsElapsed * TimeFactorMult;
            float rawSkill = scoreFactor;
            int scoreCeiling = _averageScoreForInterval * 2;
            float remappedSkill = rawSkill.Remap(0, scoreCeiling, -1, 1);
            float clampedSkill = Mathf.Clamp(remappedSkill, -1, 1);
            Debug.Log(string.Format("Skill: {0}", clampedSkill));
            return clampedSkill;
        }

        // Use this for initialization
        private void Start()
        {
            _scoreController = ScoreController.Instance;
            _uiController = UIController.Instance;
            _previousScore = 0;
        }

        // Update is called once per frame
        private void Update()
        {
            DifficultyLevel = 10;
            _timer += Time.deltaTime;

            if (_timer < _interval) return;

            _timer -= _interval;

            int currentScore = _scoreController.CurrentScore;

            int scoreInInterval = currentScore - _previousScore;
            int secondsElapsed = _scoreController.TimeSurvived;

            UpdateDifficulty(scoreInInterval, secondsElapsed);

//            DifficultyLevel = Mathf.Clamp(DifficultyLevel + _difficultyAdjustmentInc, _minDifficulty, _maxDifficulty);

            float newDifficulty = DifficultyLevel + _difficultyAdjustmentInc;
            DifficultyLevel = newDifficulty.Clamp(_minDifficulty, _maxDifficulty);

            int roundedDifficulty = Convert.ToInt32(Mathf.Floor(DifficultyLevel));

            _uiController.UpdateDifficulty(roundedDifficulty);

            _previousScore = currentScore;

            Debug.Log(string.Format("Difficulty Level: {0}", DifficultyLevel));
        }

        #endregion Private Methods
    }
}