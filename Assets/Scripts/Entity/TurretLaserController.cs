using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entity {
    public class TurretLaserController : LaserController {
        #region Public Fields

        #endregion Public Fields

        #region Private Methods

        private void OnBecameInvisible() {
            Destroy(gameObject);
        }

        // Use this for initialization
        private void Start() {
            TurretFireController laserFireController = transform.GetComponentInParent<TurretFireController>();
            float laserSpeedParentOverride = laserFireController.LaserSpeed;
            if (Mathf.Abs(LaserSpeed - laserSpeedParentOverride) > 0.01f) {
                if (laserSpeedParentOverride > 0) LaserSpeed = laserSpeedParentOverride;
            }

            var aimTargetPosition = new Vector3(laserFireController.AimTarget.transform.position.x,
                laserFireController.AimTarget.transform.position.y, transform.position.z);
            Vector3 laserDirection = aimTargetPosition - transform.position;

            laserDirection.Normalize();

            var r2d = GetComponent<Rigidbody2D>();
            r2d.velocity = laserDirection * LaserSpeed;

            //            var aimAingle = Vector2.Angle(Vector2.up, new Vector2(laserDirection.x, laserDirection.y)) % 180;
            float aimAingle = Mathf.Atan2(laserDirection.y, laserDirection.x) * Mathf.Rad2Deg;

            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, aimAingle - 90);
            transform.parent = laserFireController.LaserContainer.transform;
        }

        // Update is called once per frame
        private void Update() {
        }

        #endregion Private Methods
    }
}
