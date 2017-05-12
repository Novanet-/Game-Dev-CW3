using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Powerup {
    public class PowerupSpawner : MonoBehaviour {
        #region Public Fields

        public Powerup[] powerups;
        public int timeDelay = 20;

        #endregion Public Fields

        #region Private Fields

        private float time;

        #endregion Private Fields

        #region Private Methods

        // Use this for initialization
        void Start() {
            time = Time.time + timeDelay;
        }

        // Update is called once per frame
        void Update() {
            if (time < Time.time) {
                time += timeDelay;

                float f = Random.Range(0, powerups.Length);

                for (int i = 0; i < powerups.Length; i++) {
                    if (f <= i) {
                        Instantiate(powerups[i]);
                        return;
                    }
                }
            }
        }

        #endregion Private Methods
    }
}