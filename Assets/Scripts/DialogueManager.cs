using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    private Queue<string> sentences;
    public enterNameScript ens;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.Play("GlitchGame");
        sentences = new Queue<string>();   
    }

    public void StartDialogue(Dialogue dialogue)
    {
        AudioManager.instance.Stop("GlitchGame");
        AudioManager.instance.Play("Type");
        sentences.Clear();

            foreach (string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }
            DisplayNextSentence();
    }

    IEnumerator NextSentence(string sentence)
    {
        AudioManager.instance.Play("Type");
        dialogueText.text = "";
        DisplayNextSentence();
        yield return null;
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
            string sentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(1);
        StartCoroutine(NextSentence(sentence));
    }

    void EndDialogue()
    {
        if(ens.correct)
        {
            AudioManager.instance.Stop("Type");
            ens.victoryPanel.SetActive(true);
        }
        ens.alreadyInUse = false;
    }
}
