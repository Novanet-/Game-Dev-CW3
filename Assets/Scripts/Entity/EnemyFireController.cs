﻿using UnityEngine;

namespace Entity
{
    public class EnemyFireController : MonoBehaviour
    {
        #region Public Fields

        public float FireInterval = 0.5F;
        public float LaserSpeed;
        public GameObject LaserType;

        #endregion Public Fields

        #region Internal Fields

        internal GameObject AimTarget;
        internal GameObject LaserContainer;

        #endregion Internal Fields

        #region Private Fields

        private SpriteRenderer _spriteRenderer;

        #endregion Private Fields

        #region Private Properties

        private float CurrentTime { get; set; }
        private float NextFireSlot { get; set; }

        #endregion Private Properties

        #region Private Methods

        private void Start()
        {
            NextFireSlot = 0.5f;
            LaserContainer = GameObject.Find("LaserContainer");
            AimTarget = GameObject.Find("Player");
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        private void Update()
        {
            CurrentTime += Time.deltaTime;

            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (CurrentTime <= NextFireSlot) return;

            NextFireSlot = CurrentTime + FireInterval;

            if (AimTarget != null && _spriteRenderer.isVisible)
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

        #endregion Private Methods
    }
}