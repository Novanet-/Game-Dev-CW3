using System;
using com.kleberswf.lib.core;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class UIController : Singleton<UIController>
    {
        #region Private Fields

        private Image _pauseImage;

        private Text _txtEnemiesKilled;
        [SerializeField] private GameObject _txtEnemiesKilledObject;

        private Text _txtPaused;
        [SerializeField] private GameObject _txtPausedObject;

        private Text _txtScore;
        [SerializeField] private GameObject _txtScoreObject;

        private Text _txtTime;
        [SerializeField] private GameObject _txtTimeObject;

        private Text _txtDifficulty;
        [SerializeField] private GameObject _txtDifficultyObject;

        #endregion Private Fields

        #region Internal Methods

        internal void TogglePauseUI()
        {
            _pauseImage.enabled = !_pauseImage.enabled;
            _txtPaused.enabled = !_txtPaused.enabled;
        }

        internal void UpdateKills(int kills)
        {
            _txtEnemiesKilled.text = Convert.ToString(kills);
            //            Debug.Log(String.Format("Kills: {0}", kills));
        }

        internal void UpdateScore(int score)
        {
            _txtScore.text = Convert.ToString(score);
            //            Debug.Log(String.Format("Score: {0}", score));
        }

        internal void UpdateTime(int time)
        {
            _txtTime.text = Convert.ToString(time);
            //            Debug.Log(String.Format("Time: {0}", time));
        }
        internal void UpdateDifficulty(int difficulty)
        {
            _txtDifficulty.text = Convert.ToString(difficulty);
        }

        #endregion Internal Methods

        #region Private Methods

        // Use this for initialization
        private void Start()
        {
            Scene currentScene = SceneManager.GetActiveScene();

            if (!currentScene.name.Equals("MainScene")) return;

                if (_txtScoreObject != null) _txtScore = _txtScoreObject.GetComponent<Text>();
            if (_txtEnemiesKilledObject != null) _txtEnemiesKilled = _txtEnemiesKilledObject.GetComponent<Text>();
            if (_txtTimeObject != null) _txtTime = _txtTimeObject.GetComponent<Text>();
            if (_txtPausedObject != null) _txtPaused = _txtPausedObject.GetComponent<Text>();
            if (_txtDifficultyObject != null) _txtDifficulty = _txtDifficultyObject.GetComponent<Text>();
            _pauseImage = GetComponent<Image>();
        }

        // Update is called once per frame
        private void Update()
        {
        }

        #endregion Private Methods
    }
}