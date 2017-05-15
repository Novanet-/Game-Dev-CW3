using UnityEngine;

namespace Entity
{
    public class EnemyFireControllerUnaimed : EnemyFireController
    {
        #region Private Fields

        private EnemyControllerSuppress _enemyController;

        #endregion Private Fields

        #region Private Methods

        private void Start()
        {
            base.Start();
            _enemyController = GetComponent<EnemyControllerSuppress>();
        }

        private void Update()
        {
            if (_enemyController.isDeployed)
            {
//                Debug.Log("Fire Ship deployed");

                CurrentTime += Time.deltaTime;

                Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                if (CurrentTime <= NextFireSlot) return;

                NextFireSlot = CurrentTime + FireInterval;

//                if (AimTarget != null && _spriteRenderer.isVisible)
                {
                    Sound.SoundController.Instance.PlayFireSound(this, 0.15f);
                    GameObject bullet = Instantiate(LaserType, transform.position, transform.rotation, transform);

                    if (transform.rotation.eulerAngles.y > 90)
                    {
                        bullet.transform.Rotate(new Vector3(0, 180, 0));
                    }
                }

                NextFireSlot -= CurrentTime;
                CurrentTime = 0.0F;
            }
        }

        #endregion Private Methods
    }
}