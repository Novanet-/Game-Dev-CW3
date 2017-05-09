using System;
using com.kleberswf.lib.core;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIController : Singleton<UIController>
    {
        #region Private Fields

        [SerializeField] private GameObject _txtScoreObject;
        [SerializeField] private GameObject _txtEnemiesKilledObject;
        [SerializeField] private GameObject _txtTimeObject;

        private Text _txtScore;
        private Text _txtEnemiesKilled;
        private Text _txtTime;

        #endregion Private Fields

        #region Public Methods

        internal void UpdateKills(int kills)
        {
            _txtEnemiesKilled.text = Convert.ToString(kills);
            Debug.Log(String.Format("Kills: {0}", kills));
        }

        internal void UpdateScore(int score)
        {
            _txtScore.text = Convert.ToString(score);
            Debug.Log(String.Format("Score: {0}", score));
        }

        internal void UpdateTime(int time)
        {
            _txtTime.text = Convert.ToString(time);
            Debug.Log(String.Format("Time: {0}", time));
        }

        #endregion Public Methods

        #region Private Methods

        // Use this for initialization
        private void Start()
        {
            _txtScore = _txtScoreObject.GetComponent<Text>();
            _txtEnemiesKilled = _txtEnemiesKilledObject.GetComponent<Text>();
            _txtTime = _txtTimeObject.GetComponent<Text>();
        }

        // Update is called once per frame
        private void Update()
        {
        }

        #endregion Private Methods
    }
}