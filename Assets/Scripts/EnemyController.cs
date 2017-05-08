﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyController : MonoBehaviour
    {
        private GameObject player;
        public float speed = 10;

        // Use this for initialization
        void Start()
        {
            player = GameObject.Find("Player");
        }

        // Update is called once per frame
        void Update()
        {
            if (player != null && !player.GetComponent<PlayerDeathController>().isDead())
            {
                //rotate to look at player
                transform.LookAt(player.transform.position);
                transform.Rotate(new Vector3(0, -90, 0), Space.Self);

                //move towards player
                transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));

                if (transform.eulerAngles.y < 90)
                    transform.rotation = Quaternion.Euler(transform.eulerAngles.x, 0, transform.eulerAngles.z);
                else
                    transform.rotation = Quaternion.Euler(transform.eulerAngles.x, 180, transform.eulerAngles.z);


                transform.Rotate(new Vector3(0, 0, -90));
            }
            else
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);}
        }


    }
}