using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entity {
    public class EnemyLaserControllerUnaimed : EnemyLaserController {

        void Start() {
            var fireController = transform.GetComponentInParent<EnemyFireController>();

            Vector3 laserDirection = transform.rotation.eulerAngles;

            Vector2 dir = (Vector2)(Quaternion.Euler(0, 0, laserDirection.z + 90) * Vector2.right);

            var r2d = GetComponent<Rigidbody2D>();
            r2d.velocity = new Vector2(dir.x * fireController.LaserSpeed, dir.y * fireController.LaserSpeed);
            
            transform.parent = fireController.LaserContainer.transform;
        }
    }
}