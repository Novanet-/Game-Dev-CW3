using UnityEngine;

namespace Entity
{
    public class PlayerFireController : MonoBehaviour
    {

        public float LaserSpeed;
        public GameObject LaserType;
        public float FireInterval = 0.5F;
        public GameObject AimTarget;
        public GameObject LaserContainer;

        private float CurrentTime { get; set; }
        private float NextFireSlot { get; set; }


        private void Start()
        {
            NextFireSlot = 0.5f;
        }

        private void Update()
        {
            CurrentTime += Time.deltaTime;

            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            bool mouseFire = Input.GetButton("Fire1");
            bool controllerFire = Input.GetAxis("RTFire1") > 0;

            bool fireButtonPressed = mouseFire || controllerFire;
            bool cantFireYet = CurrentTime <= NextFireSlot;

            if (!fireButtonPressed || cantFireYet) return;

            NextFireSlot = CurrentTime + FireInterval;
            Instantiate(LaserType, transform.position, transform.rotation, transform);

            NextFireSlot -= CurrentTime;
            CurrentTime = 0.0F;
        }
    }
}