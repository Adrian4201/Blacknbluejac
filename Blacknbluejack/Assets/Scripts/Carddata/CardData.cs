using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardData : MonoBehaviour
{
    public string suit;   // e.g. "Hearts", "Spades"

    public string rank;   // e.g. "A", "10", "K"

    public int value;     // Blackjack value (A=1 or 11, J/Q/K=10, others=rank number)

    public Sprite Image;
}
