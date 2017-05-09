using Misc;
using UnityEngine;

namespace Entity

{
    public class PlayerMovementController : MonoBehaviour

    {
        #region Public Fields

        public float MoveSpeed = 10f;
        public float RotationOffset = -90f;
        public float TurnSpeed = 10f;

        #endregion Public Fields

        #region Private Fields

        private bool _canMove = true;
        private float _curSpeed;
        private float _maxSpeed;

        private Rigidbody2D _rigidbody;

        #endregion Private Fields

        #region Public Methods

        internal void SetCanMove(bool b)
        {
            _canMove = b;
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
        }

        private void FixedUpdate()
        {
            Controls();

            HelperFunctions.ClampTransformToCameraView(transform);
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        #endregion Private Methods
    }
}