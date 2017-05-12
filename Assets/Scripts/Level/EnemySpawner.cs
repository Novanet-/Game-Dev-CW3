using Entity;
using UnityEngine;

namespace Level
{
    public class EnemySpawner : MonoBehaviour
    {
        #region Public Fields

        public EnemyController enemy;
        public float spawnDelay = 1;
        public float spawnChance = 1.0f;

        #endregion Public Fields

        #region Private Fields

        private float _time;

        #endregion Private Fields

        #region Private Methods

        // Use this for initialization
        private void Start()
        {
            _time = Time.time;
        }

        // Update is called once per frame
        private void Update()
        {
            if (_time < Time.time)
            {
                float rand = Random.value;
                if (rand < spawnChance)
                {
                    Instantiate(enemy, transform.position, transform.rotation, transform);
                }
                _time = Time.time + spawnDelay;
            }
        }

        #endregion Private Methods
    }
}