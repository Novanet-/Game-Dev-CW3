using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace Powerup {
    public class TurretPowerup : Powerup {
        #region Public Fields

        public float time = 10;

        #endregion Public Fields

        #region Public Methods

        public override void Use() {
            _player.DeployTurret();
        }

        private void OnTriggerEnter2D(Collider2D other) {
            base.OnTriggerEnter2D(other);
            if (other.tag == "Player") {
                GameObject.Find("UICanvas").GetComponent<UI.UIController>().AddPowerup(GameObject.Find("UICanvas").GetComponent<UI.UIController>()._iconTurret);
            }
        }

        #endregion Public Methods
    }
}