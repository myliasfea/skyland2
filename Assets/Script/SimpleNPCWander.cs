using UnityEngine;
using UnityEngine.AI;

public class SimpleNPCWander : MonoBehaviour
{
    public Transform[] waypoints;
    public float waitTime = 2f;

    private NavMeshAgent agent;
    private int currentIndex = 0;
    private float waitCounter = 0f;
    private bool waiting = false;

    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        if (waypoints.Length > 0)
        {
            agent.SetDestination(waypoints[currentIndex].position);
            animator?.SetBool("isWalking", true);
        }
    }

    void Update()
    {
        if (waypoints.Length == 0)
            return;

        // Check if NPC arrived
        if (!waiting && agent.remainingDistance < 0.5f && !agent.pathPending)
        {
            waiting = true;
            waitCounter = 0f;
            animator?.SetBool("isWalking", false);
        }

        // Wait before moving to next point
        if (waiting)
        {
            waitCounter += Time.deltaTime;
            if (waitCounter >= waitTime)
            {
                currentIndex = (currentIndex + 1) % waypoints.Length;
                agent.SetDestination(waypoints[currentIndex].position);
                waiting = false;
                animator?.SetBool("isWalking", true);
            }
        }
    }
}