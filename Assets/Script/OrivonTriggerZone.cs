using UnityEngine;

public class OrivonTriggerZone : MonoBehaviour
{
    public MasterOrivonAI orivonScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            orivonScript.ActivateMovement();
            gameObject.SetActive(false); // disable trigger after use
        }
    }
}