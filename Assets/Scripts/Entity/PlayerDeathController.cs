using System.Collections;
using UnityEngine;

namespace Entity
{
    public class PlayerDeathController : DeathController
    {
        #region Public Fields

        public float RespawnDelay = 1;

        #endregion Public Fields

        #region Private Fields

        private Collider2D _coll;
        private PlayerMovementController _movement;
        private SpriteRenderer _sprite;

        #endregion Private Fields

        #region Public Methods

        public override void Die(GameObject self)
        {
            Dead = true;

            if (self.tag != "Bullet")
            {
                Animator explosion = Instantiate(DeathAnim, self.transform);
                explosion.transform.localPosition = new Vector3(0, 0, 0);

                Destroy(explosion.gameObject, ExplosionTime);
            }

            _movement.SetCanMove(false);

            _sprite.enabled = false;
            _coll.enabled = false;

            StartCoroutine(Respawn());
        }

        public bool IsDead()
        {
            return Dead;
        }

        public void Start()
        {
            _sprite = GetComponent<SpriteRenderer>();
            _coll = GetComponent<Collider2D>();
            _movement = GetComponent<PlayerMovementController>();
        }

        #endregion Public Methods

        #region Private Methods

        private IEnumerator Respawn()
        {
            yield return new WaitForSeconds(RespawnDelay);

            transform.position = new Vector3(0, -6, 0);
            transform.localPosition = new Vector3(0, -6, 0);

            _sprite.enabled = true;

            _coll.enabled = true;

            _movement.SetCanMove(true);

            Dead = false;
        }

        #endregion Private Methods
    }
}