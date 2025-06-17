using UnityEngine;

public class FPComboSword : MonoBehaviour
{
    public float swingSpeed = 5f;
    public float swingAngle = 45f;
    public float returnSpeed = 5f;

    private Quaternion idleRot;
    private Quaternion swingRot;
    private bool isSwinging = false;
    private bool isReturning = false;
    private float lerpT = 0f;

    void Start()
    {
        idleRot = transform.localRotation;
        swingRot = idleRot * Quaternion.Euler(-swingAngle, 0f, 0f); // Swing downwards
    }

    void Update()
    {
        // Start swing
        if (Input.GetKeyDown(KeyCode.F) && !isSwinging && !isReturning)
        {
            isSwinging = true;
            lerpT = 0f;
        }

        // Swing forward
        if (isSwinging)
        {
            lerpT += Time.deltaTime * swingSpeed;
            transform.localRotation = Quaternion.Slerp(idleRot, swingRot, lerpT);

            if (lerpT >= 1f)
            {
                isSwinging = false;
                isReturning = true;
                lerpT = 0f;
            }
        }
        // Return to idle
        else if (isReturning)
        {
            lerpT += Time.deltaTime * returnSpeed;
            transform.localRotation = Quaternion.Slerp(swingRot, idleRot, lerpT);

            if (lerpT >= 1f)
            {
                isReturning = false;
                // Optional: allow next combo immediately
            }
        }

        // Chained combo: press F again to restart swing mid-animation
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isReturning && !isSwinging)
            {
                isSwinging = true;
                isReturning = false;
                lerpT = 1f - lerpT; // Invert progress for smooth chain
            }
        }
    }
}