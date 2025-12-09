using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CardStack))]
public class DeckView : MonoBehaviour
{
    CardStack Deck;

    public Vector3 start;
    public float cardOFFset;
    public GameObject cardPrefab;

    void Start()
    {
        Deck = GetComponent<CardStack>();
        ShowCards();
    }
    
    void ShowCards()
    {
        int cardCount = 0;
        if (Deck.HasCards)
        {
            foreach (int i in Deck.GetCards())
            {
                float co = cardOFFset * cardCount;

                GameObject cardCopy = (GameObject)Instantiate(cardPrefab);
                Vector3 temp = start + new Vector3(co, 0f);
                cardCopy.transform.position = start;

                Cardmodel cardModel = cardCopy.GetComponent<Cardmodel>();
                cardModel.index = i;
                cardModel.ToggleFace(true);

                SpriteRenderer spriteRenderer = cardCopy.GetComponent<SpriteRenderer>();
                spriteRenderer.sortingOrder =   cardCount;
                cardCount++;
            }
        }
    }
    void AddCard(Vector3 postion, int Cadindex)
    {

    }
}
