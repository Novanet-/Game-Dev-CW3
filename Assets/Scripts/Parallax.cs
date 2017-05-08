using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {
    public float step = 0.5f;

    public Renderer[] backgrounds;

    void Update() {
        foreach (Renderer r in backgrounds) {
            if (!r.isVisible && r.transform.position.y > 0)
                r.transform.position = r.transform.position - Vector3.up * (r.bounds.size.y * 2);
            else
                r.transform.position = r.transform.position + Vector3.up * step;
        }
    }
}