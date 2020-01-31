using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class typeyournameScript : MonoBehaviour
{
    public TextMeshProUGUI textmeshproinput;   
    
    void Start()
    {
        
    }

    public void EnterName(TextMeshProUGUI name)
    {
        name.text = textmeshproinput.text;

        if (name.text != "your name")
        {
            Debug.Log("not your name! Try again");
        }
        else
            Debug.Log("Correct!");
    }
}
