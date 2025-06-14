using UnityEngine;

public class OrionTriggerZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MasterOrionAI orionAI = FindObjectOfType<MasterOrionAI>();

            if (orionAI != null)
            {
                Debug.Log("Player entered trigger.");
                orionAI.ActivateMovement();
            }
            else
            {
                Debug.LogWarning("MasterOrionAI not found in scene.");
            }
        }
    }
}