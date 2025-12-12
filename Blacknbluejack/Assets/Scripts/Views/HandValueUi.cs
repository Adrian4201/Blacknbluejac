using TMPro;
using UnityEngine;

public class HandValueUI : MonoBehaviour
{
    [Header("References")]
    public CardStack playerStack;
    public CardStack dealerStack;

    [Header("UI Text")]
    public TMP_Text playerValueText;
    public TMP_Text dealerValueText;

    private void OnEnable()
    {
        // Subscribe to card events
        playerStack.CardAdded += UpdateValues;
        playerStack.cardRemover += UpdateValues;

        dealerStack.CardAdded += UpdateValues;
        dealerStack.cardRemover += UpdateValues;
    }

    private void OnDisable()
    {
        // Unsubscribe
        playerStack.CardAdded -= UpdateValues;
        playerStack.cardRemover -= UpdateValues;

        dealerStack.CardAdded -= UpdateValues;
        dealerStack.cardRemover -= UpdateValues;
    }

    void UpdateValues(object sender, cardEventargs e)
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (playerValueText != null)
            playerValueText.text = "Player:  " + playerStack.HandValue().ToString();

        if (dealerValueText != null)
            dealerValueText.text = "Dealer:  " + dealerStack.HandValue().ToString();
    }
}
