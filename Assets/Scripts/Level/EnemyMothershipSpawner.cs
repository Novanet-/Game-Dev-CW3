using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level {
    public class EnemyMothershipSpawner : MonoBehaviour {
        #region Public Fields

        public GameObject enemy;

        #endregion Public Fields

        #region Public Methods

        public void Spawn() {
            Instantiate(enemy, transform.position, transform.rotation, transform);
        }

        #endregion Public Methods
        
    }
}