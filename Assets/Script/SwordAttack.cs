using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public float damage = 10f;
    public float attackCooldown = 0.5f;
    private bool canAttack = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canAttack)
        {
            canAttack = false;
            StartCoroutine(Attack());
        }
    }

    private System.Collections.IEnumerator Attack()
    {
        // Enable sword trigger for a moment
        GetComponent<Collider>().enabled = true;
        yield return new WaitForSeconds(0.1f);
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}