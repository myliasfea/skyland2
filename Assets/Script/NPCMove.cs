using UnityEngine;
using UnityEngine.AI;

public class NPCMove : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;
    public Transform[] targets;
    public float[] idleTime;
    public int targetIndex = 0;
    public float countUp = 0.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        float distToTarget = Vector3.Distance(targets[targetIndex].position, transform.position);
        agent.destination = targets[targetIndex].position;
        if (distToTarget < 0.7f)
        {
            anim.SetBool("isWalking", false);
            countUp += Time.deltaTime;
            if (countUp > idleTime[targetIndex])
            {
                if (targetIndex < targets.Length - 1)
                {
                    targetIndex++;
                }
                else
                {
                    targetIndex = 0;
                }
                countUp = 0.0f;
            }
        }
        else
        {
            anim.SetBool("isWalking", true);
        }
    }
}


