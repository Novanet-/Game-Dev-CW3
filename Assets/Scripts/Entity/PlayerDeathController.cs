using System.Collections;
using UnityEngine;

namespace Entity
{
    public class PlayerDeathController : DeathController
    {
        #region Public Fields

        public float respawnDelay = 1;

        #endregion Public Fields

        #region Private Fields

        private Collider2D coll;
        private PlayerMovementController movement;
        private SpriteRenderer sprite;

        #endregion Private Fields

        #region Public Methods

        public override void Die(GameObject self)
        {
            dead = true;

            if (self.tag != "Bullet")
            {
                Animator explosion = Instantiate(deathAnim, self.transform);
                explosion.transform.localPosition = new Vector3(0, 0, 0);

                Destroy(explosion.gameObject, explosionTime);
            }

            movement.SetCanMove(false);

            sprite.enabled = false;
            coll.enabled = false;

            StartCoroutine(Respawn());
        }

        public bool isDead()
        {
            return dead;
        }

        public void Start()
        {
            sprite = GetComponent<SpriteRenderer>();
            coll = GetComponent<Collider2D>();
            movement = GetComponent<PlayerMovementController>();
        }

        #endregion Public Methods

        #region Private Methods

        private IEnumerator Respawn()
        {
            yield return new WaitForSeconds(respawnDelay);

            transform.position = new Vector3(0, -6, 0);
            transform.localPosition = new Vector3(0, -6, 0);

            sprite.enabled = true;

            coll.enabled = true;

            movement.SetCanMove(true);

            dead = false;
        }

        #endregion Private Methods
    }
}