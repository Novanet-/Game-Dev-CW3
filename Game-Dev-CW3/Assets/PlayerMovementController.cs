using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{

    public float MoveSpeed = 10f;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal") * MoveSpeed;
        var vertical = Input.GetAxis("Vertical") * MoveSpeed;
        var currentPos = transform.position;
        transform.position = Vector3.Lerp(currentPos, new Vector3(currentPos.x + horizontal, currentPos.y + vertical, currentPos.z), Time.deltaTime);
    }
}