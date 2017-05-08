using System.Collections.Generic;
using UnityEngine;

namespace Level
{
    public class BackgroundManager : MonoBehaviour
    {
        #region Public Fields

        public float DifficultyDelay = 5;
        public float DifficultyIncrement = 0.05f;
        public float DifficultyMax = 0.6f;
        public BackgroundRow Row;

        public float ScreenBottom = -6;
        public float ScrollSpeed = 0.05f;
        public float TileHeight = 0.75f;

        #endregion Public Fields

        #region Private Fields

        private float _floorPercent = 1f;
        private float _holePercent;
        private int _rowNum = 20, _rowCurr;
        private List<BackgroundRow> _rows;
        private float _time;
        private float _top;
        private float _wallPercent;

        #endregion Private Fields

        #region Private Methods

        private void AddRow()
        {
            if (_rows.Count > 0)
                _top = _rows[_rows.Count - 1].transform.localPosition.y + TileHeight;

            BackgroundRow r = Instantiate(Row, transform);
            r.Create(_floorPercent, _holePercent, _wallPercent);
            r.transform.localPosition = new Vector3(0, _top, 0);
            _rows.Add(r);

            _rowCurr++;
        }

        private void IncrementDifficulty()
        {
            _floorPercent -= DifficultyIncrement;
            _holePercent += DifficultyIncrement / 2;
            _wallPercent += DifficultyIncrement / 2;
        }

        private void SetupBackground()
        {
            _top = ScreenBottom;

            while (_rowCurr < _rowNum)
            {
                AddRow();
            }
        }

        // Use this for initialization
        private void Start()
        {
            _rows = new List<BackgroundRow>();

            SetupBackground();

            _time = Time.time + DifficultyDelay;
        }

        // Update is called once per frame
        private void Update()
        {
            for (var i = 0; i < _rows.Count; i++)
            {
                BackgroundRow r = _rows[i];

                r.transform.localPosition = new Vector3(0, r.transform.position.y - ScrollSpeed);

                if (r.transform.localPosition.y < ScreenBottom)
                {
                    _rows.Remove(r);
                    Destroy(r.gameObject);
                    i--;
                    _rowCurr--;
                }
            }

            if (_floorPercent > DifficultyMax && _time < Time.time)
            {
                IncrementDifficulty();
                _time = Time.time + DifficultyDelay;
            }

            if (_rowCurr < _rowNum)
            {
                AddRow();
            }
        }

        #endregion Private Methods
    }
}