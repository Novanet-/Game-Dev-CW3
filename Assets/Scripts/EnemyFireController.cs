using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts {
    public class EnemyFireController : MonoBehaviour {
        public float LaserSpeed;
        public GameObject LaserType;
        public float FireInterval = 0.5F;
        public GameObject AimTarget;
        public GameObject LaserContainer;

        private float CurrentTime { get; set; }
        private float NextFireSlot { get; set; }

        private void Start() {
            NextFireSlot = 0.5f;
        }

        private void Update() {
            CurrentTime += Time.deltaTime;

            var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (CurrentTime <= NextFireSlot) return;

            NextFireSlot = CurrentTime + FireInterval;
            Instantiate(LaserType, transform.position, transform.rotation, transform);

            NextFireSlot -= CurrentTime;
            CurrentTime = 0.0F;
        }
    }
}