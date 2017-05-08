using Misc;
using UnityEngine;

namespace Controls
{
    public class AimController : MonoBehaviour {
        public float MoveSpeed = 10f;


        // Use this for initialization
        private void Start() {
        }

        // Update is called once per frame
        private void Update() {
            float mouseX = UnityEngine.Input.GetAxis("Mouse X");
            float mouseY = UnityEngine.Input.GetAxis("Mouse Y");

            if (Mathf.Abs(mouseX) > 0 && Mathf.Abs(mouseY) > 0)
                MouseAim();
            else
                StickAim();

            HelperFunctions.ClampTransformToCameraView(transform);
        }

        private void MouseAim() {
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
            transform.position = new Vector3(cursorPosition.x, cursorPosition.y, transform.position.z);
        }

        private void StickAim() {
            float horizontal = UnityEngine.Input.GetAxis("RStickX");
            float vertical = UnityEngine.Input.GetAxis("RStickY");

            if (Mathf.Abs(horizontal) <= 0 && Mathf.Abs(vertical) <= 0) return;

            Vector3 currentPos = transform.position;
            float horizontalInc = horizontal * MoveSpeed;
            float verticalInc = vertical * MoveSpeed;

            Vector3 newPos = new Vector3(currentPos.x + horizontalInc, currentPos.y + verticalInc, currentPos.z);
            transform.position = Vector3.Lerp(currentPos, newPos, Time.deltaTime);
        }
    }
}