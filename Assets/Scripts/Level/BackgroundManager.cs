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

        private float floorPercent = 1f;
        private float holePercent;
        private int rowNum = 20, rowCurr;
        private List<BackgroundRow> rows;
        private float time;
        private float top;
        private float wallPercent;

        #endregion Private Fields

        #region Private Methods

        private void addRow()
        {
            if (rows.Count > 0)
                top = rows[rows.Count - 1].transform.localPosition.y + tileHeight;

            BackgroundRow r = Instantiate(row, transform);
            r.Create(floorPercent, holePercent, wallPercent);
            r.transform.localPosition = new Vector3(0, top, 0);
            rows.Add(r);

            rowCurr++;
        }

        private void incrementDifficulty()
        {
            floorPercent -= difficultyIncrement;
            holePercent += difficultyIncrement / 2;
            wallPercent += difficultyIncrement / 2;
        }

        private void SetupBackground()
        {
            top = screenBottom;

            while (rowCurr < rowNum)
            {
                addRow();
            }
        }

        // Use this for initialization
        private void Start()
        {
            rows = new List<BackgroundRow>();

            SetupBackground();

            time = Time.time + difficultyDelay;
        }

        // Update is called once per frame
        private void Update()
        {
            for (var i = 0; i < rows.Count; i++)
            {
                BackgroundRow r = rows[i];

                r.transform.localPosition = new Vector3(0, r.transform.position.y - scrollSpeed);

                if (r.transform.localPosition.y < screenBottom)
                {
                    rows.Remove(r);
                    Destroy(r.gameObject);
                    i--;
                    rowCurr--;
                }
            }

            if (floorPercent > difficultyMax && time < Time.time)
            {
                incrementDifficulty();
                time = Time.time + difficultyDelay;
            }

            if (rowCurr < rowNum)
            {
                addRow();
            }
        }

        #endregion Private Methods
    }
}