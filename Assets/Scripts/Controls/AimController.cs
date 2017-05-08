using Misc;
using UnityEngine;

namespace Controls
{
    public class AimController : MonoBehaviour
    {
        #region Public Fields

        public float MoveSpeed = 10f;

        #endregion Public Fields

        #region Private Methods

        private void MouseAim()
        {
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(cursorPosition.x, cursorPosition.y, transform.position.z);
        }

        // Use this for initialization
        private void Start()
        {
        }

        private void StickAim()
        {
            float horizontal = Input.GetAxis("RStickX");
            float vertical = Input.GetAxis("RStickY");

            if (Mathf.Abs(horizontal) <= 0 && Mathf.Abs(vertical) <= 0) return;

            Vector3 currentPos = transform.position;
            float horizontalInc = horizontal * MoveSpeed;
            float verticalInc = vertical * MoveSpeed;

            var newPos = new Vector3(currentPos.x + horizontalInc, currentPos.y + verticalInc, currentPos.z);
            transform.position = Vector3.Lerp(currentPos, newPos, Time.deltaTime);
        }

        // Update is called once per frame
        private void Update()
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            if (Mathf.Abs(mouseX) > 0 && Mathf.Abs(mouseY) > 0)
                MouseAim();
            else
                StickAim();

            HelperFunctions.ClampTransformToCameraView(transform);
        }

        #endregion Private Methods
    }
}