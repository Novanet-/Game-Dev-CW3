using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entity {
    public class DeathControllerMothership : DeathController {

        public void OnTriggerEnter2D(Collider2D coll) {
            if (Dead) return;

            if (coll.tag == "Bullet") {
                if (coll.GetComponent<EnemyLaserController>() && isPlayer || coll.GetComponent<LaserController>() && !isPlayer) {
                    if (isPlayer)
                        Die();
                    else {
                        health--;

                        if (health <= 0)
                            Die(transform.parent.parent.gameObject);
                    }

                    Die(coll.gameObject);
                }
            }
            else if (canFall && coll.tag == "Hole") {
                Die(GameObject.Find("Player"));
            }
            else if (isPlayer && coll.tag == "Enemy") {
                Die(GameObject.Find("Player"));
                Die(coll.GetComponentInParent<EnemyController>().gameObject);
            }
        }
    }
}