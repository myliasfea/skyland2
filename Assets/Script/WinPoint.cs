using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPoint : MonoBehaviour
{
    public GameObject winUI; // Optional: assign a UI panel or text in Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player wins the game!");

            if (winUI != null)
                winUI.SetActive(true); // Show Win message

            // Optional: freeze time
            Time.timeScale = 0f;

            // OR: Load another scene if you want
            // SceneManager.LoadScene("WinScene");
        }
    }
}