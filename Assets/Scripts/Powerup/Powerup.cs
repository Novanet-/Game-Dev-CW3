using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Powerup {
    public class Powerup : MonoBehaviour {
        #region Protected Fields

        protected Entity.PlayerMovementController _player;

        #endregion Protected Fields

        #region Public Methods

        public void OnTriggerEnter2D(Collider2D coll) {
            print(coll.tag);
            if (coll.tag == "Player") {
                _player.SetPowerup(Use);

                Destroy(this.gameObject);
            }
        }

        public delegate void Activate();

        public virtual void Use() { }

        #endregion Public Methods

        #region Private Methods

        private void OnBecameInvisible() {
            Destroy(gameObject);
        }

        // Use this for initialization
        void Start() {
            _player = GameObject.Find("Player").GetComponent<Entity.PlayerMovementController>();
        }
        
        #endregion Private Methods
    }
}