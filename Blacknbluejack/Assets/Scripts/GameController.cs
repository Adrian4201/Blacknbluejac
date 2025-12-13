using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    int DealersFirstCard =  -1;
    public CardStack Player;
    public CardStack Dealer;
    public CardStack Deck;

    public Button hitButton;
    public Button StandButton;

    public TMP_Text WinningText;
    public TMP_Text LosesText;

    private DealDamage damage;
    /*
     * Cards dealt to player
     * First player hits/sticks/bust
     * Dealer turn; must have minimum of 17 score hand
     * Dealers cards; first card is hidden, subsquen cards are facing
     */
    public void hit()
    {
        Player.Push(Deck.Pop());
        if(Player.HandValue()> 21)
        {
            hitButton.interactable = false;
            StandButton.interactable = false;
            StartCoroutine(DealersTurn());
        }
    }
    public void Stand()
    {
        
        hitButton.interactable = false;
        StandButton.interactable= false;
     

        StartCoroutine(DealersTurn());
    }
    private void Start()
    {
        WinningText.gameObject.SetActive(false);
        LosesText.gameObject.SetActive(false);
        damage = GetComponent<DealDamage>();
        if (damage == null)
        {
            Debug.LogError("DealDamage component not found on this GameObject!");
        }
        StartGame();
    }
    void StartGame()
    {
        for (int i = 0; i < 2; i++)
        {
            Player.Push(Deck.Pop());
            HitDealer();
        }
    }
    void HitDealer()
    {
        int card = Deck.Pop();
        if ((DealersFirstCard < 0))
        {
            DealersFirstCard = card;
            Dealer.Push(card);
        }
        else
        {
            Dealer.Push(card);
            if (Dealer.CardCount == 2)
            {
                // After second card is dealt, make sure first stays face-down
                CardStackView view = Dealer.GetComponent<CardStackView>();
                view.Toggle(DealersFirstCard, false);
            }
        }
        //if (Dealer.CardCount >= 2)
        //{
        //    CardStackView view = Dealer.GetComponent<CardStackView>();
        //    view.Toggle(DealersFirstCard, true);
        //}
    }
    public IEnumerator DealersTurn()
    {
       
        CardStackView view = Dealer.GetComponent<CardStackView>();
        view.Toggle(DealersFirstCard, true);
        view.ShowCards();
        yield return new WaitForSeconds(1f);

        while (Dealer.HandValue() < 17)
        {
            HitDealer();
            yield return new WaitForSeconds(1f);
        }

        bool playerWinsRound = false;
        bool dealerWinsRound = false;

        if (Player.HandValue() > 21 || (Dealer.HandValue() >= Player.HandValue() && Dealer.HandValue() <= 21))
        {
            dealerWinsRound = true;
        }
        else if( Dealer.HandValue() > 21 || (Player.HandValue() <= 21 && Player.HandValue() > Dealer.HandValue()))
        {
            playerWinsRound = true;
        }
        else
        {
            dealerWinsRound = true;
        }

        if (playerWinsRound)
        {
            damage.PlayerWins();
        }
        else if (dealerWinsRound)
        {
            damage.DealerWins();
        }
        // --- Check actual game over ---
        if (damage.DealerDead)
        {
            WinningText.gameObject.SetActive(true);   // FULL VICTORY
            hitButton.interactable = false;
            StandButton.interactable = false;
        }
        else if (damage.PlayerDead)
        {
            LosesText.gameObject.SetActive(true);     // FULL LOSS
            hitButton.interactable = false;
            StandButton.interactable = false;
        }
        else
        {
            // Start new round automatically
            yield return new WaitForSeconds(1f);
            ResetRound();
        }

    }
    void ResetRound()
    {
        while (Dealer.HasCards)
        {
            int card = Dealer.Pop();
            Deck.Push(card);
        }

        while (Player.HasCards)
        {
            int card = Player.Pop();
            Deck.Push(card);
        }

        DealersFirstCard = -1;

        // Clear displayed cards (visual cleanup)
        Dealer.GetComponent<CardStackView>().ShowCards();
        Player.GetComponent<CardStackView>().ShowCards();

        // Re-enable buttons
        hitButton.interactable = true;
        StandButton.interactable = true;

        // Deal new hands
        StartGame();
    }
}
