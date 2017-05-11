using System.Collections;
using System.Collections.Generic;
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

        #endregion Public Methods
    }
}