using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour {
    public BackgroundRow row;

    private List<BackgroundRow> rows;

    public float scrollSpeed = 0.05f;

    private float time;

    public float screenBottom = -6;

    private int rowNum = 20, rowCurr = 0;

    public float tileHeight = 0.75f;

    private float top;

    private float floorPercent = 1f;
    private float holePercent = 0f;
    private float wallPercent = 0f;

    public float difficultyDelay = 5;
    public float difficultyIncrement = 0.05f;
    public float difficultyMax = 0.6f;

    // Use this for initialization
    private void Start () {
        rows = new List<BackgroundRow>();

        SetupBackground();

        time = Time.time + difficultyDelay;
    }

    private void SetupBackground() {
        top = screenBottom;

        while (rowCurr < rowNum) {
            addRow();
        }
    }

    private void addRow() {
        if (rows.Count > 0)
            top = rows[rows.Count - 1].transform.localPosition.y + tileHeight;

        BackgroundRow r = GameObject.Instantiate(row, this.transform);
        r.Create(floorPercent, holePercent, wallPercent);
        r.transform.localPosition = new Vector3(0, top, 0);
        rows.Add(r);

        rowCurr++;
    }

    // Update is called once per frame
    private void Update () {
        for (int i = 0; i < rows.Count; i++) {
            BackgroundRow r = rows[i];

            r.transform.localPosition = new Vector3(0, r.transform.position.y - scrollSpeed);

            if (r.transform.localPosition.y < screenBottom) {
                rows.Remove(r);
                Destroy(r.gameObject);
                i--;
                rowCurr--;
            }
        }

        if (floorPercent > difficultyMax && time < Time.time) {
            incrementDifficulty();
            time = Time.time + difficultyDelay;
        }

        if (rowCurr < rowNum) {
            addRow();
        }
    }

    private void incrementDifficulty() {
        floorPercent -= difficultyIncrement;
        holePercent += difficultyIncrement / 2;
        wallPercent += difficultyIncrement / 2;
    }
}