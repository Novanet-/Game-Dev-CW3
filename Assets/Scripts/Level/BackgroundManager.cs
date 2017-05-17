using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level
{
    public class BackgroundManager : MonoBehaviour
    {
        #region Public Fields

        public float difficultyDelay = 5;
        public float difficultyIncrement = 0.05f;
        public float holePercentMax = 0.2f;
        public float wallPerceneMax = 0.2f;
        public BackgroundRow row;

        public float screenBottom = -6;
        public float scrollSpeed = 0.05f;
        public float tileHeight = 0.75f;

        #endregion Public Fields

        #region Private Fields

        private float _floorPercent = 1f;
        private float _holePercent;
        private int _rowNum = 20, _rowCurr;
        private List<BackgroundRow> _rows;
        private float _time;
        private float _top;
        private float _wallPercent;
        private GameController _gameController;
        private float _difficultyMax;

        #endregion Private Fields

        #region Public Methods

        public void playerFall() {
            if (_holePercent - difficultyIncrement >= 0) {
                _holePercent -= difficultyIncrement;
                _floorPercent += difficultyIncrement;
            }
        }

        #endregion Public Methods

        #region Private Methods

        private void addRow()
        {
            if (_rows.Count > 0)
                _top = _rows[_rows.Count - 1].transform.localPosition.y + tileHeight;

            BackgroundRow r = Instantiate(row, transform);
            r.Create(_floorPercent, _holePercent, _wallPercent);
            r.transform.localPosition = new Vector3(0, _top, 0);
            _rows.Add(r);

            _rowCurr++;
        }

        private void incrementDifficulty()
        {
            if (_floorPercent > _difficultyMax)
                _floorPercent -= difficultyIncrement;

            if (_holePercent < holePercentMax)
                _holePercent += difficultyIncrement / 2;

            if (_wallPercent < wallPerceneMax)
                _wallPercent += difficultyIncrement / 2;
        }

        private void SetupBackground()
        {
            _top = screenBottom;

            while (_rowCurr < _rowNum)
            {
                addRow();
            }
        }

        // Use this for initialization
        private void Start()
        {
            _difficultyMax = 1 - (holePercentMax + wallPerceneMax);

            Scene currentScene = SceneManager.GetActiveScene();
            _rows = new List<BackgroundRow>();

            SetupBackground();

            _time = Time.time + difficultyDelay;
            if (currentScene.name.Equals("MainScene")) _gameController = GameObject.Find("GameController").GetComponent<Level.GameController>();
        }

        // Update is called once per frame
        private void Update()
        {
            if (_gameController != null && _gameController.IsPaused) return;

            for (var i = 0; i < _rows.Count; i++)
            {
                BackgroundRow r = _rows[i];

                r.transform.localPosition = new Vector3(0, r.transform.position.y - scrollSpeed);

                if (r.transform.localPosition.y < screenBottom)
                {
                    _rows.Remove(r);
                    Destroy(r.gameObject);
                    i--;
                    _rowCurr--;
                }
            }

            if (_time < Time.time)
            {
                incrementDifficulty();
                _time = Time.time + difficultyDelay;
            }

            if (_rowCurr < _rowNum)
            {
                addRow();
            }
        }

        #endregion Private Methods
    }
}