using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class enterNameScript : MonoBehaviour
{
    public Button enterNameButton;
    public TextMeshProUGUI textmeshproinput;
    public Dialogue dialogue;
    public Dialogue wrongDialogue;
    public bool alreadyInUse = false;

    // Start is called before the first frame update
    void Start()
    {
        enterNameButton.onClick.AddListener(TestName);
    }

    void TestName()
    {
        if (!alreadyInUse)
        {
            if (textmeshproinput.text.CompareTo("your name") == 1)
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                alreadyInUse = true;
            }
            else
            {
                FindObjectOfType<DialogueManager>().StartDialogue(wrongDialogue);
                alreadyInUse = true;
            }
        }
    }
}
