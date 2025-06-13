using UnityEngine;

public class OrivonSimpleIdle : MonoBehaviour
{
    public Transform player;
    public float turnSpeed = 2f;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Make Orivon rotate to face the player slowly
        Vector3 direction = player.position - transform.position;
        direction.y = 0f;

        if (direction.magnitude > 0.1f)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
        }

        // Optional: Play idle or loop anim if needed
        if (anim != null)
        {
            anim.SetBool("isIdle", true); // if your animator uses idle bool
        }
    }
}
