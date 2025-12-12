using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardStack : MonoBehaviour
{
    List<int> cards;
    public bool isGammeDeck;
    public bool HasCards
    {
       
        get{ return cards != null && cards.Count > 0; }
    }
    public event CardEventHandeler cardRemover;
    public event CardEventHandeler CardAdded;
    public int CardCount
    {
        get 
        { 
            if(cards == null)
            {
                return 0;
            }
            else
            {  
                return cards.Count; 
            }
        }
    }
    public IEnumerable<int> GetCards()
    {
        foreach (int i in cards)
        {
            yield return i;
        }
    }
    public int Pop()
    {
        int temp = cards[0];
        cards.RemoveAt(0);

        if (cardRemover != null) 
        {
            cardRemover(this, new cardEventargs(temp));
        
        }

        return temp;

    }

    public void  Push(int card)
    {
        cards.Add(card);
        if (CardAdded != null) 
        {
            CardAdded(this, new cardEventargs(card));
        }
    }
    public int HandValue()
    {
        int total = 0;
        int aces = 0;

        foreach (int card in GetCards()) 
        {

            int cardRak = card % 13;

            if (cardRak <= 8) 
            {
                cardRak += 2;
                total = total + cardRak;
            }
            else if(cardRak > 8  && cardRak < 12)
            {
                cardRak = 10;
                total = total + cardRak;
            }
            else
            {
                aces++;
            }
        }

        for (int i = 0; i <aces;i++)
        {
            if(total + 11 <= 21)
            {
                total = total + 11;
            }
            else
            {
                total = total + 1;
            }
        }


        return total;
    }
    public void CreateDeck()
    {
       
        for (int i = 0; i < 52; i++)
        {
            cards.Add(i);
        }
        int n = cards.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            int temp = cards[k];
            cards[k] = cards[n];
            cards[n] = temp;
        }
    }
    public void ClearStack()
    {
        if (cards == null) return;
        for (int i = cards.Count - 1; i >= 0; i--)
        {
            int c = cards[i];
            cards.RemoveAt(i);
            cardRemover?.Invoke(this, new cardEventargs(c));
        }
    }

    private void Awake()
    {
        cards = new List<int>();
        if (isGammeDeck)
        {
            CreateDeck();

        }
    }
    
}
