using System;
using com.kleberswf.lib.core;
using UnityEngine;

namespace Level
{
    public class GameController : Singleton<GameController>
    {
        #region Public Properties

        public float GameTimeElapsed { get; private set; }

        #endregion Public Properties

        private ScoreController _scoreController;
        private float _lastTimeRecorded;

        #region Private Methods

        // Use this for initialization
        private void Start()
        {
            _scoreController = ScoreController.Instance;
            GameTimeElapsed = 0;
        }

        // Update is called once per frame
        private void Update()
        {
            GameTimeElapsed = Time.time;
            if (Mathf.Floor(GameTimeElapsed) > Mathf.Floor(_scoreController.TimeSurvived)) _scoreController.UpdateTimeSurvived(GameTimeElapsed);
        }

        #endregion Private Methods
    }
}