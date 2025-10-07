using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Cardview : MonoBehaviour
{
    [SerializeField] private Image cardImage;

    [SerializeField] private TMP_Text cardNumber;

    [SerializeField] private TMP_Text cardNumberTopr;

    [SerializeField] private TMP_Text cardNumberbttmL;

    [SerializeField] private TMP_Text cardNumberbttmR;
    public void SetCard(CardData data)
    {
        if (data.Image != null)

            cardImage.sprite = data.Image;

        cardNumber.text = data.rank;
        cardNumberTopr.text = data.rank;
        cardNumberbttmL.text = data.rank;
        cardNumberbttmR.text = data.rank;
    }
}
