using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class UIConsole : MonoBehaviour
{
    private float delay = 0.05f;
    public string fullText;
    private string currentText = "";

    Animator anim;

    private string[] words={
        "FIX THAT!!",
        "Write that again!!!",
        "Are you an engineer or what?!!",
        "This is not a research...",
        "Do you think you going to graduate this year??",
        "Hmm... I don't think so...",
        "Hurry up now!!",
        "Less images, more text.",
        "More images, more pages..",
        "It's data table not a actual table."
    };

    private void Start()
    {

        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        int rnd = Random.Range(0, words.Length);
        for(int i = 0; i <= words[rnd].Length; i++)
        {
            currentText = words[rnd].Substring(0, i);
            this.GetComponent<TextMeshProUGUI>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
        StartCoroutine(ShowText());
    }


}
