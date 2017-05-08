using UnityEngine;

namespace Entity
{
    public class DeathController : MonoBehaviour
    {
        public bool canFall = false;
        public bool isPlayer = false;

        public Animator deathAnim;
        public float explosionTime = 0.5f;

        protected bool dead = false;

        public void Die()
        {
            Die(this.gameObject);
        }

        public virtual void Die(GameObject self)
        {
            dead = true;

            Destroy(self, explosionTime);

            if (self.tag != "Bullet" && deathAnim != null)
            {
                Animator explosion = Instantiate(deathAnim, self.transform);
                explosion.transform.localPosition = new Vector3(0, 0, 0);

                Destroy(explosion, explosionTime);
            }
        }

        public void OnTriggerEnter2D(Collider2D coll)
        {
            if (dead) return;

            if (coll.tag == "Bullet")
            {
                if ((coll.GetComponent<EnemyLaserController>() && isPlayer) || (coll.GetComponent<LaserController>() && !isPlayer))
                {
                    if (isPlayer)
                        Die();
                    else
                    {
                        Die(GetComponentInParent<EnemyController>().gameObject);
                    }

                    Die(coll.gameObject);
                }
            }
            else if (canFall && coll.tag == "Hole")
            {
                Die(GameObject.Find("Player"));
            }
            else if (isPlayer && coll.tag == "Enemy")
            {
                Die(GameObject.Find("Player"));
                Die(coll.GetComponentInParent<EnemyController>().gameObject);
            }
        }

        void OnBecameInvisible()
        {
//            Debug.Log("I'm invisible");
            Invoke("KillSelf", 2);
        }

        void KillSelf()
        {
//            Debug.Log(String.Format("Visible: {0}",GetComponent<SpriteRenderer>().isVisible));
            var spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer != null && !spriteRenderer.isVisible)
            {
                Transform self = transform;
                if (self.parent != null && self.parent.gameObject != null)
                {
                    GameObject killTarget = self.parent.gameObject;
                    Die(killTarget);
                }
            }
        }
    }
}