using Misc;
using System.Collections;
using UnityEngine;

namespace Entity

{
    public class PlayerMovementController : MonoBehaviour

    {
        #region Public Fields

        public float MoveSpeed = 10f;
        public float RotationOffset = -90f;
        public float TurnSpeed = 10f;
        public float JumpTime = 1f;
        public float JumpDelay = 3f;

        #endregion Public Fields

        #region Private Fields

        private bool _canMove = true;
        private float _curSpeed;
        private float _maxSpeed;
        private PlayerDeathController _deathControl;
        private bool _isJumping = false;
        private Rigidbody2D _rigidbody;
        public ParticleSystem _particles;

        #endregion Private Fields

        #region Public Methods

        internal void SetCanMove(bool b)
        {
            _canMove = b;
        }

        internal void Jump() {
            _deathControl.canFall = false;
            _isJumping = true;
            _particles.gameObject.SetActive(true);

            StartCoroutine(Land());
        }

        #endregion Public Methods

        // Use this for initialization

        #region Private Methods

        private void Controls()
        {
            if (!_canMove) return;

            _curSpeed = MoveSpeed;
            _maxSpeed = _curSpeed;
            // Move senteces
            _rigidbody.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * _curSpeed, 0.8f),
                Mathf.Lerp(0, Input.GetAxis("Vertical") * _curSpeed, 0.8f));

            transform.up = _rigidbody.velocity.normalized;

            if (!_isJumping && Input.GetKeyDown(KeyCode.Space)) {
                Jump();
            }
        }

        private void FixedUpdate()
        {
            Controls();

            HelperFunctions.ClampTransformToCameraView(transform);
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _deathControl = GetComponent<PlayerDeathController>();
            _particles = GetComponentInChildren<ParticleSystem>();
            _particles.gameObject.SetActive(false);
        }

        private IEnumerator Land() {
            yield return new WaitForSeconds(JumpTime);

            _deathControl.canFall = true;
            _particles.gameObject.SetActive(false);

            yield return new WaitForSeconds(JumpDelay);

            _isJumping = false;
        }

        #endregion Private Methods
    }
}