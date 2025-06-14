using UnityEngine;
using TMPro;


public class ZoneMessageTrigger : MonoBehaviour
{
    public GameObject popupPanel;
    public TextMeshProUGUI warningText;
    [TextArea]
    public string messageToDisplay;

    private void Start()
    {
        if (popupPanel != null)
            popupPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            popupPanel.SetActive(true);
            warningText.text = messageToDisplay;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            popupPanel.SetActive(false);
        }
    }
}