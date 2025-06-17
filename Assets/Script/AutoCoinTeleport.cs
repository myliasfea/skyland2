using UnityEngine;

public class AutoCoinTeleport : MonoBehaviour
{
    public Transform pointB;  // Set in Inspector
    public Transform pointC;
    public GameObject winPanel;

    private bool teleportedToB = false;
    private bool teleportedToC = false;
    private bool hasWon = false;

    public CoinCollector coinCollector; // Reference to your existing coin script

    void Update()
    {
        int coins = coinCollector.coinCount;

        if (coins >= 3 && !teleportedToB)
        {
            transform.position = pointB.position;
            teleportedToB = true;
            Debug.Log("✅ Teleported to Point B");
        }
        else if (coins >= 9 && !teleportedToC)
        {
            transform.position = pointC.position;
            teleportedToC = true;
            Debug.Log("✅ Teleported to Point C");
        }
        else if (coins >= 21 && !hasWon)
        {
            hasWon = true;
            Debug.Log("🎉 You Win!");
            if (winPanel != null)
                winPanel.SetActive(true);
        }
    }
}