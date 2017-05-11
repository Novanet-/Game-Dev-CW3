using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entity {
    public class TurretController : MonoBehaviour {
        #region Public Fields

        public float rotSpeed = 1;
        public float lifetime = 10;

        #endregion Public Fields

        #region Private Properties

        private TurretFireController _fireController;

        #endregion Private Properties

        #region Public Methods

        #endregion Public Methods

        #region Private Methods

        private void Start() {
            _fireController = GetComponent<TurretFireController>();

            StartCoroutine(Die());
        }

        private IEnumerator Die() {
            yield return new WaitForSeconds(lifetime);

            Destroy(this.gameObject);
        }

        private void Update() {
            if (_fireController.AimTarget != null) {
                Vector3 vectorToTarget = _fireController.AimTarget.transform.position - transform.position;
                float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;
                Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotSpeed);
            }
        }

        #endregion Private Methods
    }
}