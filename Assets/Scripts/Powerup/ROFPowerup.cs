using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Powerup {
    public class ROFPowerup : Powerup {
        #region Public Fields

        public float rofUpgradeInterval = 0.1f;
        public float rofTime = 10;

        #endregion Public Fields

        #region Private Fields

        private Entity.PlayerFireController _fireController;

        #endregion Private Fields

        #region Public Methods

        public override void Use() {
            _fireController.BuffFireRate(rofUpgradeInterval, rofTime);
        }

        #endregion Public Methods

        #region Private Methods

        void Start() {
            _player = GameObject.Find("Player").GetComponent<Entity.PlayerMovementController>();
            _fireController = GameObject.Find("Player").GetComponent<Entity.PlayerFireController>();
        }

        #endregion Private Methods
    }
}