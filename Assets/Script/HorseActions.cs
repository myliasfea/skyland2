using UnityEngine;

/// <summary>
/// Horse performs two actions at once:
/// 1. Nodding up and down (like a "yes")
/// 2. Shaking its head side to side (like a "no")
/// </summary>
public class HorseActions : MonoBehaviour
{
    public float nodDistance = 0.2f;
    public float nodSpeed = 2f;

    public float shakeAngle = 15f;
    public float shakeSpeed = 2f;

    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private float timer = 0f;

    void Start()
    {
        initialPosition = transform.localPosition;
        initialRotation = transform.localRotation;
    }

    void Update()
    {
        timer += Time.deltaTime;

        // Nodding up and down
        float upDown = Mathf.Sin(timer * nodSpeed) * nodDistance;
        transform.localPosition = initialPosition + new Vector3(0, upDown, 0);

        // Shaking side to side
        float side = Mathf.Sin(timer * shakeSpeed) * shakeAngle;
        transform.localRotation = initialRotation * Quaternion.Euler(0, side, 0);
    }
}