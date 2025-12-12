using System.Collections;
using System.Collections.Generic;
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
        if (DealersFirstCard < 0)
        {
            DealersFirstCard = card;
        }
        Dealer.Push(card);
        if(Dealer.CardCount >= 2)
        {
            CardStackView view = Dealer.GetComponent<CardStackView>();
            view.Toggle(card, true);
        }
    }
    public IEnumerator DealersTurn()
    {
      
        while (Dealer.HandValue() < 17)
        {
            HitDealer();
            yield return new WaitForSeconds(1f);
        }
        //CardStackView view = Dealer.GetComponent<CardStackView>();
        //view.Toggle(DealersFirstCard, true);

    }
}
