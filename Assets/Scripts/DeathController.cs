using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour {
    public bool canFall = false;

    public void Die() {
        Destroy(this.gameObject);
    }

    public void Die(GameObject self) {
        Destroy(self);
    }

    public void OnTriggerEnter2D(Collider2D coll) {
        print(canFall + " " + coll.tag);
        if (coll.tag == "Bullet") {
            Die();
        }
        else if (canFall && coll.tag == "Hole") {
            Die(GameObject.Find("Player"));
        }
    }
}
