using UnityEngine;

public class BackgroundRow : MonoBehaviour {

    public GameObject floorTile;
    public GameObject holeTile;
    public GameObject wallTile;
    public GameObject powerup;

    public int numTiles = 11;

    public float tileWidth = 0.75f;

    public int maxObsticles = 5;

    // Use this for initialization
    private void Start () {

    }

    public void Create(float floorPercent, float holePercent, float wallPercent) {
        float pos = -(tileWidth * Mathf.Floor(numTiles / 2));

        int numObsticles = 0;

        for (int i = 0; i < numTiles; i++) {
            float n = Random.Range(0, 1f);

            if (n < floorPercent || numObsticles >= maxObsticles) {
                GameObject tile = GameObject.Instantiate(floorTile, this.transform);
                tile.transform.position = new Vector3(pos, 0, 0);
            }
            else if (n < floorPercent + holePercent) {
                GameObject tile = GameObject.Instantiate(holeTile, this.transform);
                tile.transform.position = new Vector3(pos, 0, 0);
                numObsticles++;
            }
            else if (n < floorPercent + holePercent + wallPercent) {
                GameObject tile = GameObject.Instantiate(wallTile, this.transform);
                tile.transform.position = new Vector3(pos, 0, 0);
                numObsticles++;
            }

            pos += tileWidth;
        }


    }

    // Update is called once per frame
    private void Update () {

    }
}