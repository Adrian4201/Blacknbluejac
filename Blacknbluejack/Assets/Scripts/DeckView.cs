using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TheDeck))]
public class DeckView : MonoBehaviour
{
    TheDeck Deck;

    public Vector3 start;
    public float cardOFFset;
    public GameObject cardPrefab;

    void Start()
    {
        Deck = GetComponent<TheDeck>();
        ShowCards();
    }
    
    void ShowCards()
    {
        int cardCount = 0;

        foreach(int i in Deck.GetCards())
        {
            float co = cardOFFset * cardCount;

            GameObject cardCopy = (GameObject)Instantiate(cardPrefab);
            Vector3 temp = start + new Vector3(co, 0f);
            cardCopy.transform.position = start;

            Cardmodel cardModel = cardCopy.GetComponent<Cardmodel>();
            cardModel.index = i;
            cardModel.ToggleFace(true);

            cardCount++;
        }
    }
}
