using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerMovementController : MonoBehaviour
    {
        public float MoveSpeed = 10f;
        public float TurnSpeed = 10f;
        public float RotationOffset = -90f;
        // Use this for initialization
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
            Controls();
            HelperFunctions.ClampTransformToCameraView(transform);
        }

        private void Controls()
        {
            var horizontal = Input.GetAxis("Horizontal") * MoveSpeed;
            var vertical = Input.GetAxis("Vertical") * MoveSpeed;


            var currentPos = transform.position;
            var newPos = new Vector3(currentPos.x + horizontal, currentPos.y + vertical, currentPos.z);
            transform.position = Vector3.Lerp(currentPos, newPos, Time.deltaTime);

            if (Mathf.Abs(horizontal) <= 0 && Mathf.Abs(vertical) <= 0) return;


            Vector3 moveDirection = newPos - currentPos;
            moveDirection.z = 0;
            moveDirection.Normalize();

            float targetAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;

            Quaternion currentRotation = transform.rotation;
            Quaternion newRotation = Quaternion.Euler(0, 0, targetAngle + RotationOffset);
            transform.rotation = Quaternion.Slerp(currentRotation, newRotation, Time.deltaTime * TurnSpeed);
        }
    }
}