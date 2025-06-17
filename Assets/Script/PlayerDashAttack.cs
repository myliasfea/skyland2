using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerDashAttack : MonoBehaviour
{
    public float dashForce = 20f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 2f;

    private CharacterController controller;
    private bool isDashing = false;
    private float dashTimer = 0f;
    private float lastDashTime = -999f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!isDashing && Input.GetKeyDown(KeyCode.F) && Time.time >= lastDashTime + dashCooldown)
        {
            isDashing = true;
            dashTimer = 0f;
            lastDashTime = Time.time;
        }

        if (isDashing)
        {
            dashTimer += Time.deltaTime;
            Vector3 dashDirection = transform.forward;
            controller.Move(dashDirection * dashForce * Time.deltaTime);

            if (dashTimer >= dashDuration)
            {
                isDashing = false;
            }
        }
    }
}