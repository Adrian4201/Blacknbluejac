using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CardStack))]
public class CardStackView : MonoBehaviour
{
    CardStack Deck;
    Dictionary<int, GameObject> FetchedCard;
    int lastCount;

    public Vector3 start;
    public float cardOFFset;
    public bool faceup = false;
    public bool ReverselayerOrder = false;
    public GameObject cardPrefab;

    void Start()
    {
        FetchedCard = new Dictionary<int, GameObject>();
        Deck = GetComponent<CardStack>();
        ShowCards();
        lastCount = Deck.CardCount;

        Deck.cardRemover += Deck_cardRemover;
    }

    private void Deck_cardRemover(object sender, cardRemovedEventargs e)
    {
        if (FetchedCard.ContainsKey(e.cardIndex)) 
        {
            Destroy(FetchedCard[e.cardIndex]);
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
    void ShowCards()
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
        spriteRenderer.sortingOrder = positionindex;


        FetchedCard.Add(Cardindex, cardCopy);

    }
}
