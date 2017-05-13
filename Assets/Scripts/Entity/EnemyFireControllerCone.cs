using UnityEngine;

namespace Entity
{
    public class EnemyFireControllerCone : EnemyFireController
    {
        #region Private Methods

        // Update is called once per frame
        private void Update()
        {
            CurrentTime += Time.deltaTime;

            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (CurrentTime <= NextFireSlot) return;

            NextFireSlot = CurrentTime + FireInterval;

            if (AimTarget != null && _spriteRenderer.isVisible)
            {
                SoundController.PlayFireSound(this);
                for (int i = -20; i <= 20; i += 20)
                {
                    GameObject bullet = Instantiate(LaserType, transform.position, transform.rotation, transform);

                    if (transform.rotation.eulerAngles.y > 90)
                    {
                        bullet.transform.Rotate(new Vector3(0, 180, 0));
                    }

                    bullet.transform.Rotate(new Vector3(0, 0, i));
                }
            }

            NextFireSlot -= CurrentTime;
            CurrentTime = 0.0F;
        }

        #endregion Private Methods
    }
}