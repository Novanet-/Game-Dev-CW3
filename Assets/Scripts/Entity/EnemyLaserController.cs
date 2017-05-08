using UnityEngine;

namespace Entity
{
    public class EnemyLaserController : MonoBehaviour
    {
        #region Public Fields

        public float LaserSpeed;

        #endregion Public Fields

        #region Private Methods

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }

        // Use this for initialization
        private void Start()
        {
            var fireController = transform.GetComponentInParent<EnemyFireController>();
            float laserSpeedParentOverride = fireController.LaserSpeed;

            if (Mathf.Abs(LaserSpeed - laserSpeedParentOverride) > 0.01f)
            {
                if (laserSpeedParentOverride > 0) LaserSpeed = laserSpeedParentOverride;
            }

            Vector3 airTargetPosition = fireController.AimTarget.transform.position;
            var aimTargetPositionFlattened = new Vector3(airTargetPosition.x, airTargetPosition.y, transform.position.z);
            Vector3 laserDirection = aimTargetPositionFlattened - transform.position;

            laserDirection.Normalize();

            var r2d = GetComponent<Rigidbody2D>();
            r2d.velocity = laserDirection * LaserSpeed;

            //            var aimAingle = Vector2.Angle(Vector2.up, new Vector2(laserDirection.x, laserDirection.y)) % 180;
            float aimAingle = Mathf.Atan2(laserDirection.y, laserDirection.x) * Mathf.Rad2Deg;

            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, aimAingle - 90);
            transform.parent = fireController.LaserContainer.transform;
        }

        // Update is called once per frame
        private void Update()
        {
        }

        #endregion Private Methods
    }
}