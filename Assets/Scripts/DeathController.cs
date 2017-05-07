﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour {
    public bool canFall = false;
    public bool isPlayer = false;

    public void Die() {
        Destroy(this.gameObject);
    }

    public void Die(GameObject self) {
        Destroy(self);
    }

    public void OnTriggerEnter2D(Collider2D coll) {
        print(isPlayer + " " + coll.tag);
        if (coll.tag == "Bullet") {
            if ((coll.GetComponent<EnemyLaserController>() && isPlayer) || (coll.GetComponent<LaserController>() && !isPlayer))
                Die();
        }
        else if (canFall && coll.tag == "Hole") {
            Die(GameObject.Find("Player"));
        }
        else if (isPlayer && coll.tag == "Enemy") {
            Die(GameObject.Find("Player"));
        }
    }
}