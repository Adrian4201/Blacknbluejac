using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CardStack))]
public class CardStackView : MonoBehaviour
{
    CardStack Deck;
    Dictionary<int, Cardview> FetchedCard;
    int lastCount;

    public Vector3 start;
    public float cardOFFset;
    public bool faceup = false;
    public bool ReverselayerOrder = false;
    public GameObject cardPrefab;

    public void Toggle(int card, bool isFaceup)
    {
        FetchedCard[card].isFaceup = isFaceup;

    }
    void Awake()
    {
        FetchedCard = new Dictionary<int, Cardview>();
        Deck = GetComponent<CardStack>();
        ShowCards();
        lastCount = Deck.CardCount;

        Deck.cardRemover += Deck_cardRemover;
        Deck.CardAdded += Deck_CardAdded;
    }

    private void Deck_CardAdded(object sender, cardEventargs e)
    {
        
        float co = cardOFFset * Deck.CardCount;
        Vector3 temp = start + new Vector3(co, 0f);
        AddCard(temp, e.cardIndex, Deck.CardCount);
    }

    private void Deck_cardRemover(object sender, cardEventargs e)
    {
        if (FetchedCard.ContainsKey(e.cardIndex)) 
        {
            Destroy(FetchedCard[e.cardIndex].Card);
            FetchedCard.Remove(e.cardIndex);
        }
        
    }

    private void Update()
    {
        if(lastCount != Deck.CardCount)
        {
            lastCount = Deck.CardCount;
            ShowCards();
        }
    }
    public void ShowCards()
    {
        int cardCount = 0;
        if (Deck.HasCards)
        {
            foreach (int i in Deck.GetCards())
            {
                float co = cardOFFset * cardCount;
                Vector3 temp = start + new Vector3(co, 0f);
                AddCard(temp,i,cardCount);
                cardCount++;
            }
        }
    }
    void AddCard(Vector3 postion, int Cardindex, int positionindex)
    {
        if (FetchedCard.ContainsKey(Cardindex))
        {
            if (!faceup)
            {
                Cardmodel model  = FetchedCard[Cardindex].Card.GetComponent<Cardmodel>();
                model.ToggleFace(FetchedCard[Cardindex].isFaceup);
            }
            return;
        }

        GameObject cardCopy = (GameObject)Instantiate(cardPrefab);
        cardCopy.transform.position = postion;

        Cardmodel cardModel = cardCopy.GetComponent<Cardmodel>();
        cardModel.index = Cardindex;
        cardModel.ToggleFace(faceup);

        SpriteRenderer spriteRenderer = cardCopy.GetComponent<SpriteRenderer>();
        if (ReverselayerOrder)
        {
            spriteRenderer.sortingOrder = 51 - positionindex;
        }
        else
        {
            spriteRenderer.sortingOrder = positionindex;
        }
        FetchedCard.Add(Cardindex, new Cardview(cardCopy));
        Debug.Log("Hand value = " + Deck.HandValue());
    }
}
