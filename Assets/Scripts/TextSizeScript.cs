using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextSizeScript : MonoBehaviour
{
    TextMeshProUGUI tmp;

    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        tmp.fontSize = 4.0f * Mathf.Sin(Time.time * 5.0f) + 40.0f;
    }
}
