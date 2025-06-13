using UnityEngine;
using UnityEngine.AI;

public class ZephMovement : MonoBehaviour
{
    public Transform targetPoint;

    private NavMeshAgent agent;
    private Animator anim;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        agent.SetDestination(targetPoint.position);
        anim.SetBool("isWalking", true);
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            anim.SetBool("isWalking", false);
        }
    }
}

