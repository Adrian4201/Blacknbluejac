using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Cardview 
{
    public GameObject Card {  get; private set; }
    public bool isFaceup { get; set; }

    public Cardview(GameObject card)
    {
        Card = card;
        isFaceup = false;
    }

    
}
