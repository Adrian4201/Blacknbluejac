using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cardanimation : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Cardmodel cardmodel;

    public AnimationCurve AniCuvre;
    public float duration = 0.5f;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        cardmodel = GetComponent<Cardmodel>();
        
    }

    public void FlipCard(Sprite Startimage, Sprite Endimage, int CardIndex)
    {
        StopCoroutine(FlipSprite(Startimage,Endimage, CardIndex));
        StartCoroutine(FlipSprite(Startimage,Endimage, CardIndex));

    }
    IEnumerator FlipSprite(Sprite Startimage, Sprite Endimage, int CardIndex)
    {
        spriteRenderer.sprite = Startimage;

        float time = 0f;
        while (time <= 1)
        {
            float scale = AniCuvre.Evaluate(time);
            time = time + Time.deltaTime / duration;

            Vector3 localScal = transform.localScale;
            localScal.x = scale;
            transform.localScale = localScal;

            if(time >+0)
            {
                spriteRenderer.sprite = Endimage;
            }
            yield return new WaitForFixedUpdate();
        }
    }
}
