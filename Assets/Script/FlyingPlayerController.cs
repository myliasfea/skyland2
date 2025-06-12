using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FlyingPlayerController : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float airControlSpeed = 4f;
    public float verticalSpeed = 4f;
    public float gravity = -2f;

    private CharacterController controller;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Forward, back, strafe
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Vertical (flying up/down)
        if (Input.GetKey(KeyCode.Space))
        {
            velocity.y = verticalSpeed; // Fly up
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            velocity.y = -verticalSpeed; // Fly down
        }
        else
        {
            velocity.y = gravity; // Hover or slow fall
        }

        controller.Move((move * moveSpeed + velocity) * Time.deltaTime);
    }
}
