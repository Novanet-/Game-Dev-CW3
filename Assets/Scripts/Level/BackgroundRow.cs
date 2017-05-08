using UnityEngine;

namespace Level
{
    public class BackgroundRow : MonoBehaviour
    {
        #region Public Fields

        public GameObject FloorTile;
        public GameObject HoleTile;
        public int MaxObsticles = 5;
        public int NumTiles = 11;
        public GameObject Powerup;
        public float TileWidth = 0.75f;
        public GameObject WallTile;

        #endregion Public Fields

        #region Public Methods

        public void Create(float floorPercent, float holePercent, float wallPercent)
        {
            float pos = -(TileWidth * Mathf.Floor(NumTiles / 2));

            var numObsticles = 0;

            for (var i = 0; i < NumTiles; i++)
            {
                float n = Random.Range(0, 1f);

                if (n < floorPercent || numObsticles >= MaxObsticles)
                {
                    GameObject tile = Instantiate(FloorTile, transform);
                    tile.transform.position = new Vector3(pos, 0, 0);
                }
                else if (n < floorPercent + holePercent)
                {
                    GameObject tile = Instantiate(HoleTile, transform);
                    tile.transform.position = new Vector3(pos, 0, 0);
                    numObsticles++;
                }
                else if (n < floorPercent + holePercent + wallPercent)
                {
                    GameObject tile = Instantiate(WallTile, transform);
                    tile.transform.position = new Vector3(pos, 0, 0);
                    numObsticles++;
                }

                pos += TileWidth;
            }
        }

        #endregion Public Methods

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