using System;
using UnityEngine;

namespace Entity
{
    public class LaserController : MonoBehaviour
    {
        public float LaserSpeed;

        // Use this for initialization
        private void Start()
        {
            PlayerFireController playerFireController = transform.GetComponentInParent<PlayerFireController>();
            float laserSpeedParentOverride = playerFireController.LaserSpeed;
            if (Math.Abs(LaserSpeed - laserSpeedParentOverride) > 0.01f)
            {
                if (laserSpeedParentOverride > 0) LaserSpeed = laserSpeedParentOverride;
            }

            var aimTargetPosition = new Vector3(playerFireController.AimTarget.transform.position.x, playerFireController.AimTarget.transform.position.y, transform.position.z);
            Vector3 laserDirection = aimTargetPosition - transform.position;

            laserDirection.Normalize();


            var r2d = GetComponent<Rigidbody2D>();
            r2d.velocity = laserDirection * LaserSpeed;

            //            var aimAingle = Vector2.Angle(Vector2.up, new Vector2(laserDirection.x, laserDirection.y)) % 180;
            float aimAingle = Mathf.Atan2(laserDirection.y, laserDirection.x) * Mathf.Rad2Deg;

            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, aimAingle - 90);
            transform.parent = playerFireController.LaserContainer.transform;
        }

        // Update is called once per frame
        private void Update()
        {
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}