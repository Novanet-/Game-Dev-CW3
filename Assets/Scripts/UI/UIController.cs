using System;
using System.Collections;
using System.Collections.Generic;
using Misc;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class UIController : MonoBehaviour
    {
        #region Public Fields

        public Image _iconFlight;
        public Image _iconRof;
        public Image _iconTurret;

        #endregion Public Fields

        #region Private Fields

        [SerializeField] public Text _lblPowerupGained;
        private Image _pauseImage;

        [SerializeField] public float _powerupGainDisplayTime;
        private Stack<GameObject> _powerupIcons;
        [SerializeField] private GameObject _powerupImage;
        [SerializeField] private GameObject _powerupPanel;
        private Text _txtDifficulty;
        [SerializeField] private GameObject _txtDifficultyObject;
        private Text _txtEnemiesKilled;
        [SerializeField] private GameObject _txtEnemiesKilledObject;
        private Text _txtHealth;
        [SerializeField] private GameObject _txtHealthObject;
        private Text _txtLives;
        [SerializeField] private GameObject _txtLivesObject;
        private Text _txtPaused;
        [SerializeField] private GameObject _txtPausedObject;

        private Text _txtScore;
        [SerializeField] private GameObject _txtScoreObject;

        private Text _txtTime;
        [SerializeField] private GameObject _txtTimeObject;

        #endregion Private Fields

        #region Public Methods

        public void AddPowerup(Image powerupIcon)
        {
            Debug.Log("Add powerup");
            var image = _powerupImage.GetComponent<Image>();
            image.enabled = true;
            image.sprite = powerupIcon.sprite;
            DisplayPowerupGainedText(powerupIcon.gameObject);
        }

        public void RemovePowerup()
        {
            Debug.Log("Remove powerup");
            var image = _powerupImage.GetComponent<Image>();
            image.enabled = false;
            image.sprite = null;
        }

        #endregion Public Methods

        #region Internal Methods

        internal string GetScore()
        {
            return _txtScore.text;
        }

        internal void TogglePauseUI()
        {
            _pauseImage.enabled = !_pauseImage.enabled;
            _txtPaused.enabled = !_txtPaused.enabled;
        }

        internal void UpdateDifficulty(int difficulty)
        {
            _txtDifficulty.text = Convert.ToString(difficulty);
        }

        internal void UpdateKills(int kills)
        {
            _txtEnemiesKilled.text = Convert.ToString(kills);
            //            Debug.Log(String.Format("Kills: {0}", kills));
        }

        internal void UpdateLives(int lives)
        {
            if (lives <= -1)
                _txtLives.text = "∞";
            else
                _txtLives.text = Convert.ToString(lives);
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

        internal void UpdateHealth(int health) {
            _txtHealth.text = Convert.ToString(health);
        }

        #endregion Internal Methods

        #region Private Methods

        private void DisplayPowerupGainedText(GameObject powerupImage)
        {
            var powerupDictionary = new Dictionary<string, string>
            {
                {"iconFlight", "Flight"},
                {"iconRof", "Rate of Fire"},
                {"iconTurret", "Turret"}
            };
            string targetString = String.Empty;
            powerupDictionary.TryGetValue(powerupImage.name, out targetString);
            targetString = string.Format("{0} powerup gained", targetString);
            StartCoroutine(DisplayTextForTime(targetString, _lblPowerupGained, _powerupGainDisplayTime));
        }

        public IEnumerator<WaitForSeconds> DisplayTextForTime(string targetstring, Text textcontainer, float displayTime)
        {
            textcontainer.text = targetstring;
            yield return new WaitForSeconds(displayTime);

            textcontainer.text = string.Empty;
        }

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
            if (_txtLivesObject != null) _txtLives = _txtLivesObject.GetComponent<Text>();
            if (_txtHealthObject != null) _txtHealth = _txtHealthObject.GetComponent<Text>();

            _pauseImage = GetComponent<Image>();
            _powerupIcons = new Stack<GameObject>();

            if (GameObject.Find("StateProperties").GetComponent<StateProperties>().isTimeAttack)
            {
                GameObject.Find("lblTime").GetComponent<Text>().text = "Time Remaining:";
            }
        }

        // Update is called once per frame
        private void Update()
        {
        }

        #endregion Private Methods

        //            public IEnumerator RemovePowerup(GameObject powerupIconObject, float delayTime)
        //        {
        //            yield return new WaitForSeconds(delayTime);
        //            Debug.Log("Remove powerup");
        //            Destroy(powerupIconObject);
        //        }
    }
}