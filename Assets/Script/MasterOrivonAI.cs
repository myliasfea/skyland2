using UnityEngine;
using UnityEngine.AI;

public class MasterOrionAI : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;
    private Animator animator;

    private bool hasStarted = false;
    private bool hasTalked = false;
    private float talkDistance = 2f; // Distance at which NPC starts talking

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        if (agent == null)
            Debug.LogError("NavMeshAgent missing.");
        if (animator == null)
            Debug.LogError("Animator missing.");
        if (player == null)
            Debug.LogError("Player Transform not set.");
    }

    public void ActivateMovement()
    {
        Debug.Log("ActivateMovement called.");

        if (agent && !hasStarted && player)
        {
            hasStarted = true;
            agent.isStopped = false;
            agent.SetDestination(player.position);
            Debug.Log("Destination set to " + player.position);
            animator?.SetTrigger("StartWalk");
        }
    }

    private void Update()
    {
        if (hasStarted && !hasTalked && !agent.pathPending &&
            Vector3.Distance(transform.position, player.position) <= talkDistance)
        {
            agent.isStopped = true;
            animator?.SetTrigger("StartTalk"); // Talk now
            hasTalked = true;
            Debug.Log("StartTalk triggered.");
        }
    }
}