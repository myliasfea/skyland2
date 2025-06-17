using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator attackAnimator;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            attackAnimator.SetTrigger("Attack");
        }
    }
}