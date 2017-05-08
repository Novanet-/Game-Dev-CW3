using UnityEngine;

namespace Level
{
    public class BackgroundRow : MonoBehaviour
    {
        public GameObject floorTile;
        public GameObject holeTile;
        public GameObject wallTile;
        public GameObject powerup;

        public int numTiles = 11;

        public float tileWidth = 0.75f;

        public int maxObsticles = 5;

        // Use this for initialization
        private void Start()
        {
        }

        public void Create(float floorPercent, float holePercent, float wallPercent)
        {
            float pos = -(tileWidth * Mathf.Floor(numTiles / 2));

            var numObsticles = 0;

            for (var i = 0; i < numTiles; i++)
            {
                float n = Random.Range(0, 1f);

                if (n < floorPercent || numObsticles >= maxObsticles)
                {
                    GameObject tile = Instantiate(floorTile, transform);
                    tile.transform.position = new Vector3(pos, 0, 0);
                }
                else if (n < floorPercent + holePercent)
                {
                    GameObject tile = Instantiate(holeTile, transform);
                    tile.transform.position = new Vector3(pos, 0, 0);
                    numObsticles++;
                }
                else if (n < floorPercent + holePercent + wallPercent)
                {
                    GameObject tile = Instantiate(wallTile, transform);
                    tile.transform.position = new Vector3(pos, 0, 0);
                    numObsticles++;
                }

                pos += tileWidth;
            }
        }

        // Update is called once per frame
        private void Update()
        {
        }
    }
}