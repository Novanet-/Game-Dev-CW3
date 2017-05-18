using System;
using System.Collections;
using System.Collections.Generic;
using com.kleberswf.lib.core;
using Misc;
using UnityEngine;

namespace Level
{
    public partial class SpawnerController : Singleton<SpawnerController>
    {
        #region Public Fields

        public Dictionary<string, SpawnerStruct> SpawnerDict;
        public float BossTime;

        #endregion Public Fields

        #region Private Fields

        private DifficultyController _difficultyController;
        private int _previousDifficulty = -1;
        [SerializeField] private List<SpawnerStruct> _spawnerList;
        [SerializeField] private EnemyMothershipSpawner _bossSpawner;
        private float _bossTimer;
        private bool _bossWave = false;

        #endregion Private Fields

        #region Private Methods

        // Use this for initialization
        private void Start()
        {
            SpawnerDict = new Dictionary<string, SpawnerStruct>();
            foreach (SpawnerStruct spawner in _spawnerList)
            {
                GameObject spawnerObject = spawner.SpawnerObject;
                Vector3 positionOverride = spawner.SpawnerPositionOverride;

                if (!positionOverride.Equals(Vector3.zero)) spawnerObject.transform.position = positionOverride;
                SpawnerDict.Add(spawner.SpawnerName, spawner);
            }

            _difficultyController = DifficultyController.Instance;

            _bossTimer = BossTime;
        }

        // Update is called once per frame
        private void Update()
        {
            if (_bossWave) return;

            if (Time.timeSinceLevelLoad >= _bossTimer) {
                _bossTimer = Time.timeSinceLevelLoad + BossTime;

                StartCoroutine(BossWave());

                return;
            }

            var currentDifficulty = Convert.ToInt32(Mathf.Floor(_difficultyController.DifficultyLevel));
            if (currentDifficulty == _previousDifficulty) return;

            IEnumerable<SpawnerStruct> spawnersToBeEnabled;
            IEnumerable<SpawnerStruct> spawnersToBeDisabled;
            _spawnerList.Fork(spawner => spawner.SpawnerDifficultyThreshold <= currentDifficulty, out spawnersToBeEnabled, out spawnersToBeDisabled );
            foreach (SpawnerStruct spawnerStruct in spawnersToBeEnabled)
            {
                spawnerStruct.SpawnerObject.GetComponent<EnemySpawner>().enabled = true;
            }
            foreach (SpawnerStruct spawnerStruct in spawnersToBeDisabled)
            {
                spawnerStruct.SpawnerObject.GetComponent<EnemySpawner>().enabled = false;
            }

            _previousDifficulty = Convert.ToInt32(Mathf.Floor(currentDifficulty));
        }

        private IEnumerator BossWave() {
            _bossWave = true;

            foreach (SpawnerStruct spawner in _spawnerList) {
                spawner.SpawnerObject.GetComponent<EnemySpawner>().enabled = false;
            }

            _bossSpawner.Spawn();

            yield return new WaitForSeconds(20);

            _bossWave = false;
        }

        #endregion Private Methods
    }
}