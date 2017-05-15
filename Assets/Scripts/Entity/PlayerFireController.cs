using System.Collections;
using Sound;
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

        #region Private Fields

        private bool _canShoot = true;
        [SerializeField] private AudioClip _fireSound;
        private SoundController _soundController;

        #endregion Private Fields

        #region Private Properties

        private float CurrentTime { get; set; }
        private float NextFireSlot { get; set; }

        #endregion Private Properties

        #region Public Methods

        public void BuffFireRate(float newRate, float rofTime)
        {
            float originalROF = FireInterval;

            FireInterval = newRate;

            StartCoroutine(SetBack(originalROF, rofTime));
        }

        public void SetCanShoot(bool b)
        {
            _canShoot = b;
        }

        #endregion Public Methods

        #region Protected Methods

        protected void PlayFireSound()
        {
            _soundController.PlaySingle(_fireSound, 0.5f);
        }

        #endregion Protected Methods

        #region Private Methods

        private IEnumerator SetBack(float val, float rofTime)
        {
            yield return new WaitForSeconds(rofTime);

            FireInterval = val;
        }

        private void Start()
        {
            NextFireSlot = 0.5f;
            _soundController = SoundController.Instance;
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

            PlayFireSound();

            NextFireSlot = CurrentTime + FireInterval;
            Instantiate(LaserType, transform.position, transform.rotation, transform);

            NextFireSlot -= CurrentTime;
            CurrentTime = 0.0F;
        }

        #endregion Private Methods
    }
}