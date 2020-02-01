using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowToSpriteRenderer : MonoBehaviour
{
    SpriteRenderer sr;
    bool doStuff;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        doStuff = true;
        StartCoroutine(colourChange());
    }

    IEnumerator colourChange()
    {
        float lerp = 0.0f;
        while (doStuff)
        {
            lerp = 0f;
            Color start = sr.color;
            Color end = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));

            while (lerp < 1)
            {
                sr.color=Color.Lerp(start,end, lerp);
                lerp += Time.deltaTime / .8f;
                yield return null;
            }
        }
        yield return null;
    }
}
