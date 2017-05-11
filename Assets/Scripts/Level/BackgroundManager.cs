using System.Collections.Generic;
using UnityEngine;

namespace Level
{
    public class BackgroundManager : MonoBehaviour
    {
        #region Public Fields

        public float difficultyDelay = 5;
        public float difficultyIncrement = 0.05f;
        public float difficultyMax = 0.6f;
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

        #endregion Private Fields

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
            _floorPercent -= difficultyIncrement;
            _holePercent += difficultyIncrement / 2;
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
            _rows = new List<BackgroundRow>();

            SetupBackground();

            _time = Time.time + difficultyDelay;
            _gameController = GameController.Instance;
        }

        // Update is called once per frame
        private void Update()
        {
            if (_gameController.IsPaused) return;

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

            if (_floorPercent > difficultyMax && _time < Time.time)
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