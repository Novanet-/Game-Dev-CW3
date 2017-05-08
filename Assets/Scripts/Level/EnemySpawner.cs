using Entity;
using UnityEngine;

namespace Level
{
    public class EnemySpawner : MonoBehaviour
    {
        #region Public Fields

        public EnemyController enemy;
        public float spawnDelay = 1;

        #endregion Public Fields

        #region Private Fields

        private float time;

        #endregion Private Fields

        #region Private Methods

        // Use this for initialization
        private void Start()
        {
            time = Time.time;
        }

        // Update is called once per frame
        private void Update()
        {
            if (time < Time.time)
            {
                Instantiate(enemy, transform.position, transform.rotation, transform);
                time = Time.time + spawnDelay;
            }
        }

        #endregion Private Methods
    }
}