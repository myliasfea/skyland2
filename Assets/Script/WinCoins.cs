using UnityEngine;

public class WinCoins : MonoBehaviour
{
    public CoinCollector coinCollector;
    public int requiredCoins = 21;

    public GameObject bossNPC;
    public GameObject infoText;

    private bool hasTriggered = false;

    void Update()
    {
        // When player has enough coins
        if (!hasTriggered && coinCollector.coinCount >= requiredCoins)
        {
            hasTriggered = true;

            if (bossNPC != null)
                bossNPC.SetActive(true); // Activate the enemy or next quest

            if (infoText != null)
                infoText.SetActive(true); // Show the message
        }

        // Hide the message when player presses Enter (Return)
        if (hasTriggered && infoText != null && infoText.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Return)) // Return = Enter
            {
                infoText.SetActive(false);
            }
        }
    }
}