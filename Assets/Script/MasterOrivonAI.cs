using UnityEngine;
using UnityEngine.AI;

public class MasterOrivonAI : MonoBehaviour
{
    public Transform player;
    public Animator animator;
    public float stopDistance = 1f;
    private NavMeshAgent agent;
    private bool hasStarted = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (hasStarted && !agent.pathPending)
        {
            float distance = Vector3.Distance(transform.position, player.position);
            if (distance <= stopDistance)
            {
                agent.isStopped = true;
                animator.SetTrigger("StartTalk");
                hasStarted = false; // prevent repeat
            }
        }
    }

    public void ActivateMovement()
    {
        if (!hasStarted)
        {
            hasStarted = true;
            agent.SetDestination(player.position);
            animator.SetTrigger("StartWalk");
        }
    }
}