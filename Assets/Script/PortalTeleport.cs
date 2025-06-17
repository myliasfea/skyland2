using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    public Transform teleportTarget; // Target location to teleport to

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Make sure your player is tagged as Player
        {
            other.transform.position = teleportTarget.position;
            Debug.Log("Teleported to: " + teleportTarget.name);
        }
    }
}