using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entity {
    public class EnemyFireControllerUnaimed : EnemyFireController {
        void Update() {
            CurrentTime += Time.deltaTime;

            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (CurrentTime <= NextFireSlot) return;

            NextFireSlot = CurrentTime + FireInterval;

            if (AimTarget != null && _spriteRenderer.isVisible) {
                GameObject bullet = Instantiate(LaserType, transform.position, transform.rotation, transform);

                if (transform.rotation.eulerAngles.y > 90) {
                    bullet.transform.Rotate(new Vector3(0, 180, 0));
                }
            }

            NextFireSlot -= CurrentTime;
            CurrentTime = 0.0F;
        }
    }
}