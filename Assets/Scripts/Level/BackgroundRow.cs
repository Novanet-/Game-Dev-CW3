using UnityEngine;

namespace Level
{
    public class BackgroundRow : MonoBehaviour
    {

        #region Public Fields

        public GameObject floorTile;
        public GameObject holeTile;
        public int maxObsticles = 5;
        public int numTiles = 11;
        public GameObject powerup;
        public float tileWidth = 0.75f;
        public GameObject wallTile;

        #endregion Public Fields

        #region Internal Methods

        internal void Create(float floorPercent, float holePercent, float wallPercent)
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

        #endregion Internal Methods

        #region Private Methods

        // Use this for initialization
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
        }

        #endregion Private Methods

    }
}