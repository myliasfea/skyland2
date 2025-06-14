using UnityEngine;

public class DialogueZoneTrigger : MonoBehaviour
{
    public DialogueZone dialogueZone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueZone.BeginDialogue();
        }
    }
}