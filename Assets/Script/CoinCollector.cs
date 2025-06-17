using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour
{
    public int coinCount = 0;
    public Text coinText; // UI text for coin display

    public GameObject portalA;
    public GameObject portalB;
    public GameObject portalC;

    private int currentStage = 1;
    private int[] stageGoals = { 3, 9, 21 };

    public void AddCoin(int amount)
    {
        coinCount += amount;
        UpdateUI();
        CheckStageProgress();
    }

    private void UpdateUI()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + coinCount;
        }
    }

    private void CheckStageProgress()
    {
        if (currentStage <= stageGoals.Length && coinCount >= stageGoals[currentStage - 1])
        {
            if (currentStage == 1 && portalA != null)
                portalA.SetActive(true);
            else if (currentStage == 2 && portalB != null)
                portalB.SetActive(true);
            else if (currentStage == 3 && portalC != null)
                portalC.SetActive(true);

            currentStage++;
        }
    }
}