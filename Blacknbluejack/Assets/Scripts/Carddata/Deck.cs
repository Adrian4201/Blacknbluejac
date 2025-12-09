using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<CardData> cards = new();
    public Sprite[] CardSprites;

    private string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
    private string[] ranks = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

    void Start()
    {
        Shuffle();
        CreateDeck();
    }

    public void CreateDeck()
    {
        cards.Clear();
        int spriteIndex = 0;

        foreach (string suit in suits)
        {
            foreach (string rank in ranks)
            {
                CardData card = new CardData();
                card.suit = suit;
                card.rank = rank;

                // Assign Blackjack values
                if (rank == "J" || rank == "Q" || rank == "K")
                    card.value = 10;
                else if (rank == "A")
                    card.value = 11;
                else
                    card.value = int.Parse(rank);

                // Assign the sprite (based on load order or naming)
                card.Image = CardSprites[spriteIndex];
                spriteIndex++;

                cards.Add(card);
            }
        }
    }

    public void Shuffle()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            int randomIndex = Random.Range(i, cards.Count);
            (cards[i], cards[randomIndex]) = (cards[randomIndex], cards[i]);
        }
    }

    public CardData DrawCard()
    {
        if (cards.Count == 0) return null;
        CardData card = cards[0];
        cards.RemoveAt(0);
        return card;
    }


}
