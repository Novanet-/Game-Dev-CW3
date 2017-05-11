using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Powerup {
    public class FlightPowerup : Powerup {
        #region Public Fields

        public float flyTime = 10;

        #endregion Public Fields

        #region Public Methods

        public override void Use() {
            Entity.PlayerMovementController player = _player.GetComponent<Entity.PlayerMovementController>();

            player.Jump(flyTime);
        }

        #endregion Public Methods
    }
}