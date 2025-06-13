using UnityEngine;
using UnityEngine.AI;

public class FoxMoveAndSit : MonoBehaviour
{
    public Transform player;          // Assign Player in Inspector
    public Transform targetPoint;     // Where the fox should walk to
    public float detectionRange = 5f; // Distance to start moving

    private NavMeshAgent agent;
    private Animator anim;
    private bool hasMoved = false;
    private bool hasSat = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        // Step 1: If player is nearby and fox hasn't moved yet
        if (!hasMoved && distance <= detectionRange)
        {
            agent.SetDestination(targetPoint.position);
            anim?.SetBool("isWalking", true);
            hasMoved = true;
        }

        // Step 2: When fox reaches the target
        if (hasMoved && !hasSat && !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            anim?.SetBool("isWalking", false); // Stop walking
            anim?.SetTrigger("sit");           // Sit animation
            agent.isStopped = true;
            hasSat = true;

            // Face the player
            Vector3 lookDirection = player.position - transform.position;
            lookDirection.y = 0; // Ignore vertical
            transform.rotation = Quaternion.LookRotation(lookDirection);
        }
    }
}
