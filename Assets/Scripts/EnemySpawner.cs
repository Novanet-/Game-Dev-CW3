using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts {
    public class EnemySpawner : MonoBehaviour {
        public EnemyController enemy;
        public float spawnDelay = 1;

        private float time;

        // Use this for initialization
        void Start() {
            time = Time.time;
        }

        // Update is called once per frame
        void Update() {
            if (time < Time.time) {
                Instantiate(enemy, transform);
                time = Time.time + spawnDelay;
            }
        }
    }
}