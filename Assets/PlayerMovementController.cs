using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public float TurnSpeed = 10f;
    public float RotationOffset = -90f;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
//        var horizontal = Input.GetAxis("Horizontal") * MoveSpeed;
//        var vertical = Input.GetAxis("Vertical") * MoveSpeed;
//        var currentPos = transform.position;
//        transform.position = Vector3.Lerp(currentPos, new Vector3(currentPos.x + horizontal, currentPos.y + vertical, currentPos.z), Time.deltaTime);

        Controls();
    }

    void Controls()
    {
        var horizontal = Input.GetAxis("Horizontal") * MoveSpeed;
        var vertical = Input.GetAxis("Vertical") * MoveSpeed;


        var currentPos = transform.position;
        var newPos = new Vector3(currentPos.x + horizontal, currentPos.y + vertical, currentPos.z);
        transform.position = Vector3.Lerp(currentPos, newPos, Time.deltaTime);

        //        transform.position = Vector3.Lerp(currentPos, newPos, Time.deltaTime);
        //        transform.position += moveDirection * MoveSpeed * Time.deltaTime;

        if (Mathf.Abs(horizontal) <= 0 && Mathf.Abs(vertical) <= 0) return;
        //
        //        float angle = Mathf.Atan2(horizontal * 1 * -1, vertical * 1) * Mathf.Rad2Deg;
        //        var currentRotation = transform.rotation;
        //        var newRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        //        transform.rotation = Quaternion.Slerp(currentRotation, newRotation, Time.deltaTime);

        Vector3 moveDirection = newPos - currentPos;
        moveDirection.z = 0;
        moveDirection.Normalize();

        float targetAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;

        Quaternion currentRotation = transform.rotation;
        Quaternion newRotation = Quaternion.Euler(0, 0, targetAngle + RotationOffset);
        transform.rotation = Quaternion.Slerp(currentRotation, newRotation, Time.deltaTime * TurnSpeed);
    }
}