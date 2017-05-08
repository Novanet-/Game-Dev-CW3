using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public float TurnSpeed = 10f;
    public float RotationOffset = -90f;

    private float curSpeed;
    private float maxSpeed;

    private Rigidbody2D rigidBody2d;

    // Use this for initialization
    private void Start() {
        rigidBody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate() {
        Controls();
        HelperFunctions.ClampTransformToCameraView(transform);
    }

    private void Controls() {
        curSpeed = MoveSpeed;
        maxSpeed = curSpeed;

        // Move senteces
        rigidBody2d.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * curSpeed, 0.8f),
            Mathf.Lerp(0, Input.GetAxis("Vertical") * curSpeed, 0.8f));

        transform.up = rigidBody2d.velocity.normalized;
    }
}