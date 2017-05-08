using Entity;
using UnityEngine;

namespace Level
{
    public class EnemySpawner : MonoBehaviour
    {
        #region Public Fields

        public EnemyController Enemy;
        public float SpawnDelay = 1;

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
                Instantiate(Enemy, transform.position, transform.rotation, transform);
                _time = Time.time + SpawnDelay;
            }
        }

        #endregion Private Methods
    }
}