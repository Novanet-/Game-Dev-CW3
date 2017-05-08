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

        private bool canMove = true;
        private float curSpeed;
        private float maxSpeed;

        private Rigidbody2D rigidbody;

        #endregion Private Fields

        #region Public Methods

        public void SetCanMove(bool b)
        {
            canMove = b;
        }

        #endregion Public Methods

        // Use this for initialization

        #region Private Methods

        private void Controls()
        {
            if (!canMove) return;

            curSpeed = MoveSpeed;
            maxSpeed = curSpeed;
            // Move senteces
            rigidbody.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * curSpeed, 0.8f),
                Mathf.Lerp(0, Input.GetAxis("Vertical") * curSpeed, 0.8f));

            transform.up = rigidbody.velocity.normalized;
        }

        private void FixedUpdate()
        {
            Controls();

            HelperFunctions.ClampTransformToCameraView(transform);
        }

        private void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }

        #endregion Private Methods
    }
}