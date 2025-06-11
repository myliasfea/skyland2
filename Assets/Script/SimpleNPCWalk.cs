using UnityEngine;

public class SimpleNPCWalk : MonoBehaviour
{
    public Transform[] points;
    public float speed = 2f;
    public float waitTime = 2f;

    private int currentIndex = 0;
    private float waitCounter = 0f;
    private bool isWaiting = false;

    void Update()
    {
        if (points.Length == 0) return;

        if (isWaiting)
        {
            waitCounter += Time.deltaTime;
            if (waitCounter >= waitTime)
            {
                isWaiting = false;
                currentIndex = (currentIndex + 1) % points.Length;
            }
            return;
        }

        Transform target = points[currentIndex];
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            isWaiting = true;
            waitCounter = 0f;
        }
    }
}
