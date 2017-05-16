using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Powerup {
    public class LifeSpawner : MonoBehaviour {
        #region Public Fields

        public Life powerup;
        public int timeDelay = 20;

        #endregion Public Fields

        #region Private Fields

        private float time;

        #endregion Private Fields

        #region Private Methods

        // Use this for initialization
        void Start() {
            time = Time.time + timeDelay + 5;
        }

        // Update is called once per frame
        void Update() {
            if (time < Time.time) {
                time += timeDelay;

                Instantiate(powerup);
            }
        }

        #endregion Private Methods
    }
}
