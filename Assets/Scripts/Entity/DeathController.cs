﻿using UnityEngine;

namespace Entity
{
    public class DeathController : MonoBehaviour
    {
        #region Public Fields

        public bool canFall;
        public Animator deathAnim;
        public float explosionTime = 0.5f;
        public bool isPlayer;

        #endregion Public Fields

        #region Protected Fields

        protected bool Dead;

        #endregion Protected Fields

        #region Public Methods

        public void Die()
        {
            Die(gameObject);
        }

        public virtual void Die(GameObject self)
        {
            Dead = true;

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
            if (Dead) return;

            if (coll.tag == "Bullet")
            {
                if (coll.GetComponent<EnemyLaserController>() && isPlayer || coll.GetComponent<LaserController>() && !isPlayer)
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

        #endregion Public Methods

        #region Private Methods

        private void KillSelf()
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

        private void OnBecameInvisible()
        {
            //            Debug.Log("I'm invisible");
            Invoke("KillSelf", 2);
        }

        #endregion Private Methods
    }
}