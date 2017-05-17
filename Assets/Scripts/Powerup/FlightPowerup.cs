using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace Powerup
{
    public class FlightPowerup : Powerup
    {
        #region Public Fields

        public float flyTime = 10;

        #endregion Public Fields

        #region Public Methods

        public override void Use()
        {
            Entity.PlayerMovementController player = _player.GetComponent<Entity.PlayerMovementController>();

            player.Jump(flyTime);

        }

        private void OnTriggerEnter2D(Collider2D other) {
            base.OnTriggerEnter2D(other);
            if (other.tag == "Player") {
                GameObject.Find("UICanvas").GetComponent<UI.UIController>().AddPowerup(GameObject.Find("UICanvas").GetComponent<UI.UIController>()._iconFlight);
            }
        }

        #endregion Public Methods
    }
}