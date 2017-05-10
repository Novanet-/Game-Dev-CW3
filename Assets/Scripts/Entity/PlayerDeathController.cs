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

        private Collider2D _coll;
        private PlayerMovementController _movement;
        private PlayerFireController _firing;
        private SpriteRenderer _sprite;

        #endregion Private Fields

        #region Public Methods

        public override void Die(GameObject self)
        {
            Dead = true;

            if (self.tag != "Bullet")
            {
                Animator explosion = Instantiate(deathAnim, self.transform);
                explosion.transform.localPosition = new Vector3(0, 0, 0);

                Destroy(explosion.gameObject, explosionTime);
            }

            _movement.SetCanMove(false);
            _firing.SetCanShoot(false);
            _sprite.enabled = false;
            _coll.enabled = false;

            StartCoroutine(Respawn());
        }

        internal bool isDead()
        {
            return Dead;
        }

        public void Start()
        {
            _sprite = GetComponent<SpriteRenderer>();
            _coll = GetComponent<Collider2D>();
            _movement = GetComponent<PlayerMovementController>();
            _firing = GetComponent<PlayerFireController>();
        }

        #endregion Public Methods

        #region Private Methods

        private IEnumerator Respawn()
        {
            yield return new WaitForSeconds(respawnDelay);

            transform.position = new Vector3(0, -6, 0);
            transform.localPosition = new Vector3(0, -6, 0);

            _movement.SetCanMove(true);
            _firing.SetCanShoot(true);

            for (int i = 0; i < 6; i++) {
                _sprite.enabled = true;
                yield return new WaitForSeconds(0.1f);
                _sprite.enabled = false;
                yield return new WaitForSeconds(0.1f);                
            }

            _sprite.enabled = true;
            _coll.enabled = true;

            Dead = false;
        }

        #endregion Private Methods
    }
}