﻿using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class EnemyLaserController : MonoBehaviour {

    public float LaserSpeed;

    // Use this for initialization
    private void Start() {
        EnemyFireController fireController = transform.GetComponentInParent<EnemyFireController>();
        float laserSpeedParentOverride = fireController.LaserSpeed;

        if (Mathf.Abs(LaserSpeed - laserSpeedParentOverride) > 0.01f) {
            if (laserSpeedParentOverride > 0) LaserSpeed = laserSpeedParentOverride;
        }

        Vector3 airTargetPosition = fireController.AimTarget.transform.position;
        var aimTargetPositionFlattened = new Vector3(airTargetPosition.x, airTargetPosition.y, transform.position.z);
        Vector3 laserDirection = aimTargetPositionFlattened - transform.position;

        laserDirection.Normalize();

        var r2d = GetComponent<Rigidbody2D>();
        r2d.velocity = laserDirection * LaserSpeed;

        //            var aimAingle = Vector2.Angle(Vector2.up, new Vector2(laserDirection.x, laserDirection.y)) % 180;
        float aimAingle = Mathf.Atan2(laserDirection.y, laserDirection.x) * Mathf.Rad2Deg;

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, aimAingle - 90);
        transform.parent = fireController.LaserContainer.transform;
    }

    // Update is called once per frame
    private void Update() {
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
}