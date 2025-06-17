using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    public Transform teleportTarget; // Assign this in Inspector
    public string playerTag = "Player"; // Make sure your player is tagged "Player"

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            CharacterController cc = other.GetComponent<CharacterController>();
            if (cc != null)
                cc.enabled = false;

            other.transform.position = teleportTarget.position;

            if (cc != null)
                cc.enabled = true;

            Debug.Log("Player teleported to " + teleportTarget.position);
        }
    }
}