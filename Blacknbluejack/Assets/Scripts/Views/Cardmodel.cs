using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Cardmodel : MonoBehaviour
{
    SpriteRenderer Sd;
    public Sprite[] Cardface;
    public Sprite cardBack;

    public int index;

    public void ToggleFace(bool showface)
    {
        if (showface)
        {
            Sd.sprite = Cardface[index];
        }
        else
        {
            Sd.sprite= cardBack;
        }

    }
    void Awake()
    {
        Sd = GetComponent<SpriteRenderer>();
    }
}
