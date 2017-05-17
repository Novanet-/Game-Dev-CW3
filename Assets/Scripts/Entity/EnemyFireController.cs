using Sound;
using UnityEngine;

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

        #region Protected Fields

        protected SpriteRenderer _spriteRenderer;

        #endregion Protected Fields

        #region Private Fields

        [SerializeField] private AudioClip _fireSound;

        #endregion Private Fields

        #region Public Properties

        public AudioClip FireSound
        {
            get { return _fireSound; }
            set { _fireSound = value; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected float CurrentTime { get; set; }
        protected float NextFireSlot { get; set; }
        protected SoundController SoundController { get; private set; }

        #endregion Protected Properties

        #region Private Methods

        protected void Start()
        {
            NextFireSlot = 0.5f;
            LaserContainer = GameObject.Find("LaserContainer");
            AimTarget = GameObject.Find("Player");
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            SoundController = SoundController.Instance;
        }

        private void Update()
        {
            CurrentTime += Time.deltaTime;

            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (CurrentTime <= NextFireSlot || _spriteRenderer == null) return;

            NextFireSlot = CurrentTime + FireInterval;

            if (AimTarget != null && _spriteRenderer != null && _spriteRenderer.isVisible)
            {
                SoundController.PlayFireSound(this);
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