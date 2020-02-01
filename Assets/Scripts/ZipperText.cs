﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ZipperText : MonoBehaviour
{
    private float delay = 0.005f;
    public string fullText;
    private string currentText = "";



    private void Start()
    {

        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            this.GetComponent<TextMeshProUGUI>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }
}
