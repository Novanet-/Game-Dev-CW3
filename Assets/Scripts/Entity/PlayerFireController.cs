using System.Collections;
using UnityEngine;

namespace Entity
{
    public class PlayerFireController : MonoBehaviour
    {
        #region Public Fields

        public GameObject AimTarget;
        public float FireInterval = 0.5F;
        public GameObject LaserContainer;
        public float LaserSpeed;
        public GameObject LaserType;

        #endregion Public Fields

        #region Private Properties

        private float CurrentTime { get; set; }
        private float NextFireSlot { get; set; }
        private bool _canShoot = true;

        #endregion Private Properties

        #region Public Methods

        public void SetCanShoot(bool b) {
            _canShoot = b;
        }

        public void BuffFireRate(float newRate, float rofTime) {
            float originalROF = FireInterval;

            FireInterval = newRate;

            StartCoroutine(SetBack(originalROF, rofTime));
        }

        #endregion Public Methods

        #region Private Methods

        private void Start()
        {
            NextFireSlot = 0.5f;
        }

        private void Update()
        {
            if (!_canShoot) return;

            CurrentTime += Time.deltaTime;

            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            bool mouseFire = Input.GetButton("Fire1");
            bool controllerFire = Input.GetAxis("RTFire1") > 0;

            bool fireButtonPressed = mouseFire || controllerFire;
            bool cantFireYet = CurrentTime <= NextFireSlot;

            if (!fireButtonPressed || cantFireYet) return;

            NextFireSlot = CurrentTime + FireInterval;
            Instantiate(LaserType, transform.position, transform.rotation, transform);

            NextFireSlot -= CurrentTime;
            CurrentTime = 0.0F;
        }

        private IEnumerator SetBack(float val, float rofTime) {
            yield return new WaitForSeconds(rofTime);

            FireInterval = val;
        }

        #endregion Private Methods
    }
}