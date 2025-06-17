using UnityEngine;

public class WinCoins : MonoBehaviour
{
    public CoinCollector coinCollector; // Drag your Player's CoinCollector script here
    public int requiredCoins = 21;

    public GameObject bossNPC; // NPC or enemy to activate after collecting all coins
    public GameObject infoText; // Optional: show "You’re ready" text

    private bool hasTriggered = false;

    void Update()
    {
        if (!hasTriggered && coinCollector.coinCount >= requiredCoins)
        {
            hasTriggered = true;

            if (bossNPC != null)
                bossNPC.SetActive(true); // Activate boss or next challenge

            if (infoText != null)
                infoText.SetActive(true); // Optional UI that says "Prepare to fight"

            Debug.Log("Player collected all coins. Boss fight can begin!");
        }
    }
}