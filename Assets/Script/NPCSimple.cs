using UnityEngine;
using UnityEngine.AI;

public class NPCSimple : MonoBehaviour
{
    public Transform player;
    public float activateDistance = 10f;
    public float stopDistance = 2f;

    private NavMeshAgent agent;
    private Animator anim;
    private bool isWalking = false;
    private bool hasTalked = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        if (agent == null) Debug.LogError("NavMeshAgent missing!");
        if (anim == null) Debug.LogError("Animator missing!");
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (!isWalking && !hasTalked && distance < activateDistance && distance > stopDistance)
        {
            // Start walking
            isWalking = true;
            agent.isStopped = false;
            agent.SetDestination(player.position);
            anim.SetBool("isWalking", true);
        }
        else if (isWalking && distance <= stopDistance && !hasTalked)
        {
            // Stop and talk
            isWalking = false;
            hasTalked = true;
            agent.isStopped = true;
            anim.SetBool("isWalking", false);
            anim.SetTrigger("talk"); // make sure you have "talk" trigger in Animator
        }
    }
}