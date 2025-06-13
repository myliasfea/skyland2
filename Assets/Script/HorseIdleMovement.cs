using UnityEngine;

public class HorseIdleMovement : MonoBehaviour
{
    public float headMoveAmount = 5f;
    public float headMoveSpeed = 1f;
    public float bodySwayAmount = 0.05f;
    public float bodySwaySpeed = 1f;

    private Vector3 initialPosition;
    private Quaternion initialRotation;

    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    void Update()
    {
        // Goyang badan perlahan (atas-bawah)
        float sway = Mathf.Sin(Time.time * bodySwaySpeed) * bodySwayAmount;
        transform.position = initialPosition + new Vector3(0f, sway, 0f);

        // Goyang kepala (kiri-kanan rotation)
        float headTurn = Mathf.Sin(Time.time * headMoveSpeed) * headMoveAmount;
        transform.rotation = initialRotation * Quaternion.Euler(0f, headTurn, 0f);
    }
}
