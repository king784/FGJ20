using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class enterNameScript : MonoBehaviour
{
    public Button enterNameButton;
    public TextMeshProUGUI textmeshproinput;

    // Start is called before the first frame update
    void Start()
    {
        enterNameButton.onClick.AddListener(TestName);
    }

    void TestName()
    {
        if (textmeshproinput.text.CompareTo("your name") == 1)
        {
            Debug.Log(textmeshproinput.text + " is right");
        }
        else Debug.Log("fuck you " + textmeshproinput.text);
    }
}
