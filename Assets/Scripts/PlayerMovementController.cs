using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public float TurnSpeed = 10f;
    public float RotationOffset = -90f;

    private float curSpeed;
    private float maxSpeed;

    private Rigidbody2D rigidbody;

    // Use this for initialization
    private void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
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
        float horizontalVelocity = Mathf.Lerp(0, Input.GetAxis("Horizontal") * curSpeed, 0.8f);
        float verticalVelocity = Mathf.Lerp(0, Input.GetAxis("Vertical") * curSpeed, 0.8f);
        rigidbody.velocity = new Vector2(horizontalVelocity, verticalVelocity);

        transform.up = rigidbody.velocity.normalized;
    }
}