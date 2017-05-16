using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Powerup {
    public class Life : MonoBehaviour {

        #region Private Fields

        private Entity.PlayerDeathController _player;

        #endregion Private Fields

        #region Public Methods

        // Use this for initialization
        void Start() {
            _player = GameObject.Find("Player").GetComponent<Entity.PlayerDeathController>();
        }

        public void OnTriggerEnter2D(Collider2D coll) {
            if (coll.tag == "Player") {
                _player.AddLife();

                Destroy(this.gameObject);
            }
        }

        #endregion Public Methods
    }
}