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
    public bool correct = false;
    public GameObject victoryPanel;

    // Start is called before the first frame update
    void Start()
    {
        enterNameButton.onClick.AddListener(TestName);
    }

    void TestName()
    {
        if (!alreadyInUse)
        {
            string text = textmeshproinput.text.Trim((char)8203);
            if (text == "your name") //.CompareTo("your name") == 1)
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                alreadyInUse = true;
                correct = true;
            }
            else
            {
                FindObjectOfType<DialogueManager>().StartDialogue(wrongDialogue);
                LevelManager.LevelMaster.AddToGrade(-0.1f);
                alreadyInUse = true;
            }
        }
    }
}
