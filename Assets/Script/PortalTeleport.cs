using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    public Transform teleportTarget;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = teleportTarget.position;
            Debug.Log("Teleported to: " + teleportTarget.name);
        }
    }
}