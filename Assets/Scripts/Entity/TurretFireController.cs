using Sound;
using UnityEngine;

namespace Entity
{
    public class TurretFireController : MonoBehaviour
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

        private void Start()
        {
            NextFireSlot = 0.5f;
            _soundController = SoundController.Instance;

            LaserContainer = GameObject.Find("LaserContainer");
        }

        private void Update()
        {
            if (!_canShoot) return;

            if (AimTarget == null)
            {
                GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");

                if (targets.Length > 0)
                {
                    AimTarget = targets[0];
                }
                else return;
            }

            CurrentTime += Time.deltaTime;

            Vector3 position = AimTarget.transform.position;

            bool cantFireYet = CurrentTime <= NextFireSlot;

            if (cantFireYet) return;

            PlayFireSound();

            NextFireSlot = CurrentTime + FireInterval;
            Instantiate(LaserType, transform.position, transform.rotation, transform);

            NextFireSlot -= CurrentTime;
            CurrentTime = 0.0F;
        }

        #endregion Private Methods
    }
}