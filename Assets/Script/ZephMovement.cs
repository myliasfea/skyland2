using UnityEngine;
using UnityEngine.AI;

public class ZephMovement : MonoBehaviour
{
    public Transform targetPoint;
    public Transform player; // Add this in Inspector

    private NavMeshAgent agent;
    private Animator anim;
    private bool hasSat = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        agent.SetDestination(targetPoint.position);
        anim.SetBool("isWalking", true);
    }

    void Update()
    {
        if (!hasSat && !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.isStopped = true;
            anim.SetBool("isWalking", false);
            anim.SetTrigger("sit");
            hasSat = true;
        }

        // Make Zeph look at player after sitting
        if (hasSat && player != null)
        {
            Vector3 lookDir = player.position - transform.position;
            lookDir.y = 0f; // Ignore up/down
            Quaternion targetRotation = Quaternion.LookRotation(lookDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2f);
        }
    }
}



