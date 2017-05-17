using Misc;
using System.Collections;
using Powerup;
using UI;
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
        public TurretController turret;
        public ParticleSystem jumpJet;

        #endregion Public Fields

        #region Private Fields

        private bool _canMove = true;
        private float _curSpeed;
        private float _maxSpeed;
        private PlayerDeathController _deathControl;
        private bool _isJumping = false;
        private Rigidbody2D _rigidbody;
        private Powerup.Powerup.Activate _currPower;
        private GameObject _powerupInstance;
        private ParticleSystem _currJumpJet;

        #endregion Private Fields

        #region Public Methods

        internal void SetCanMove(bool b)
        {
            _canMove = b;
        }

        internal void Jump()
        {
            Jump(JumpTime);
        }

        internal void Jump(float time)
        {
            _deathControl.canFall = false;
            _isJumping = true;

            _currJumpJet = Instantiate(jumpJet, this.transform);
            _currJumpJet.transform.localPosition = new Vector3(0, 0, -1);

            StartCoroutine(Land(time));
        }

        internal void SetPowerup(Powerup.Powerup.Activate pow)
        {
            _currPower = pow;
        }

        internal void DeployTurret()
        {
            TurretController t = Instantiate(turret);
            t.transform.position = transform.position;
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

            if (!_isJumping && Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }

            if (Input.GetButtonDown("Fire2"))
            {
                UsePowerup();
            }
        }

        private void FixedUpdate()
        {
            Controls();

            HelperFunctions.ClampTransformToCameraView(transform);
        }

        private void UsePowerup()
        {
            if (_currPower != null)
            {
                UIController.Instance.RemovePowerup();
                _currPower();
                _currPower = null;
            }
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _deathControl = GetComponent<PlayerDeathController>();
        }

        private IEnumerator Land(float time)
        {
            yield return new WaitForSeconds(time);

            _deathControl.canFall = true;
            Destroy(_currJumpJet.gameObject);

            yield return new WaitForSeconds(JumpDelay);

            _isJumping = false;
        }

        #endregion Private Methods
    }
}