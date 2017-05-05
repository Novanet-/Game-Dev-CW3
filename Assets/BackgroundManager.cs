using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour {
    public BackgroundRow row;

    private List<BackgroundRow> rows;

    public float scrollSpeed = 0.01f;
    public float scrollInreaseIncrement = 0.01f;
    public float scrollIncreaseDelay = 5;

    private float time;

    public float screenBottom = -6;

    private int rowNum = 20, rowCurr = 0; 

	// Use this for initialization
	void Start () {
        rows = new List<BackgroundRow>();

        time = Time.time + scrollIncreaseDelay;
	}
	
	// Update is called once per frame
	void Update () {
		if (rowCurr < rowNum) {
            BackgroundRow newRow = GameObject.Instantiate(row);
            rows.Add(newRow);
        }
        foreach(BackgroundRow r in rows) {
            row.transform.position = new Vector3(0, row.transform.position.y + scrollSpeed);
            if (row.transform.position.y < screenBottom) {
                rows.Remove(row);
                GameObject.Destroy(row);
            }
        }
        if (Time.time > time) {
            time += scrollIncreaseDelay;
            scrollSpeed += scrollInreaseIncrement;
        }
	}
}
