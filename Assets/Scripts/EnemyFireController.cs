using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts {
    public class EnemyFireController : MonoBehaviour {
        public float LaserSpeed;
        public GameObject LaserType;
        public float FireInterval = 0.5F;
        internal GameObject AimTarget;
        internal GameObject LaserContainer;

        private float CurrentTime { get; set; }
        private float NextFireSlot { get; set; }

        private void Start() {
            NextFireSlot = 0.5f;
            LaserContainer = GameObject.Find("LaserContainer");
            AimTarget = GameObject.Find("Player");
        }

        private void Update() {
            CurrentTime += Time.deltaTime;

            var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (CurrentTime <= NextFireSlot) return;

            NextFireSlot = CurrentTime + FireInterval;

            if (AimTarget != null)
            {
                GameObject bullet = Instantiate(LaserType, transform.position, transform.rotation, transform);

                if (transform.rotation.eulerAngles.y > 90)
                {
                    bullet.transform.Rotate(new Vector3(0, 180, 0));
                }
            }

            NextFireSlot -= CurrentTime;
            CurrentTime = 0.0F;
        }
    }
}
