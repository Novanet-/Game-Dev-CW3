using System.Collections;
using System.Collections.Generic;
using Sound;
using UnityEngine;

namespace Powerup {
    public class Powerup : MonoBehaviour {
        #region Protected Fields

        protected Entity.PlayerMovementController _player;
        protected bool _started = false;
        protected float t;

        #endregion Protected Fields

        #region Public Methods

        public void OnTriggerEnter2D(Collider2D coll) {
            if (coll.tag == "Player") {
                _player.SetPowerup(Use);

                SoundController.Instance.PlaySingle(Sounds.Instance.PickUpPowerup, 0.9f);

                Destroy(this.gameObject);
            }
        }

        public delegate void Activate();

        public virtual void Use() { }

        #endregion Public Methods

        #region Private Methods

        private void OnBecameInvisible() {
            if (_started)
                Destroy(gameObject);
        }

        // Use this for initialization
        void Start() {
            _player = GameObject.Find("Player").GetComponent<Entity.PlayerMovementController>();
            t = Time.time + 5;
        }

        void Update() {
            if (t < Time.time)
                _started = true;
        }

        #endregion Private Methods
    }
}