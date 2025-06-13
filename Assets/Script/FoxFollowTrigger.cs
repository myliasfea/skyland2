using UnityEngine;
using UnityEngine.AI;

public class FoxFollowTrigger : MonoBehaviour
{
    public Transform player;
    public Transform targetPoint;
    public float detectionRange = 5f;

    private NavMeshAgent agent;
    private Animator anim;
    private bool hasMoved = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (!hasMoved && distance <= detectionRange)
        {
            agent.SetDestination(targetPoint.position);
            anim?.SetBool("isWalking", true);
            hasMoved = true;
        }

        // Stop walking when reached
        if (hasMoved && !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            anim?.SetBool("isWalking", false);
        }
    }
}
