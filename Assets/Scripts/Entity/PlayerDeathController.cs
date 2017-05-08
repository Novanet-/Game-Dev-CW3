using System.Collections;
using UnityEngine;

namespace Entity {
    public class PlayerDeathController : DeathController {
        public float respawnDelay = 1;

        private SpriteRenderer sprite;
        private Collider2D coll;
        private PlayerMovementController movement;

        public void Start() {
            sprite = GetComponent<SpriteRenderer>();
            coll = GetComponent<Collider2D>();
            movement = GetComponent<PlayerMovementController>();
        }

        public override void Die(GameObject self) {
            dead = true;

            if (self.tag != "Bullet") {
                Animator explosion = Instantiate(deathAnim, self.transform);
                explosion.transform.localPosition = new Vector3(0, 0, 0);

                Destroy(explosion.gameObject, explosionTime);
            }

            movement.SetCanMove(false);

            sprite.enabled = false;
            coll.enabled = false;

            StartCoroutine( Respawn());
        }

        private IEnumerator Respawn() {
            yield return new WaitForSeconds(respawnDelay);

            transform.position = new Vector3(0, -6, 0);
            transform.localPosition = new Vector3(0, -6, 0);
            
            sprite.enabled = true;

            coll.enabled = true;

            movement.SetCanMove(true);

            dead = false;
        }

        public bool isDead() {
            return dead;
        }
    }
}
