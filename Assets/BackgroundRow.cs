using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRow : MonoBehaviour {

    public GameObject floorTile;
    public GameObject holeTile;
    public GameObject wallTile;
    public GameObject powerup;

    public float floorPercent = 0.8f;
    public float holePercent = 0.1f;
    public float wallPercent = 0.1f;

    public int numTiles = 11;

    private float tileWidth = 1.25f;

    // Use this for initialization
    void Start () {
        float pos = -(tileWidth * Mathf.Floor(numTiles / 2));

        for (int i = 0; i < numTiles; i++) {
            float n = Random.Range(0, 1f);

            if (n < floorPercent) {
                GameObject tile = GameObject.Instantiate(floorTile, this.transform);
                tile.transform.position = new Vector3(pos, 0, 0);
            }
            else if (n < floorPercent + holePercent) {
                GameObject tile = GameObject.Instantiate(holeTile, this.transform);
                tile.transform.position = new Vector3(pos, 0, 0);
            }
            else if (n < floorPercent + holePercent + wallPercent) {
                GameObject tile = GameObject.Instantiate(wallTile, this.transform);
                tile.transform.position = new Vector3(pos, 0, 0);
            }

            pos += tileWidth;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
