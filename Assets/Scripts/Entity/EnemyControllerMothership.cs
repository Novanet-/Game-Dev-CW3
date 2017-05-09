using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entity {
    public class EnemyControllerMothership : EnemyController {

        // Update is called once per frame
        void Update() {
            print(transform.rotation.eulerAngles);
            transform.Rotate(new Vector3(0, 0, 1));
        }
    }
}