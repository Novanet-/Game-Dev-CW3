using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entity {
    public class EnemyControllerMothership : EnemyController {

        private float _time;
        private Transform parent;

        void Start() {
            _time = Time.timeSinceLevelLoad + 8;
            parent = GetComponentInParent<EnemyController>().transform.parent;
            print(parent);
        }

        // Update is called once per frame
        void Update() {
            if (Time.timeSinceLevelLoad <= _time) {
                parent.localPosition = new Vector3(parent.localPosition.x, parent.localPosition.y-0.01f, parent.localPosition.z);
            }
            transform.Rotate(new Vector3(0, 0, 1));
        }
    }
}