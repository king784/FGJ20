using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ThesisText : MonoBehaviour
{
    public TextMeshProUGUI givenText;
    public TextMeshProUGUI placeHolder;
    public TMP_InputField inputField;
    public GameObject oras;
    int nextWord = 1;
    private float delay = 0.05f;
    private string currentText = "";

    public GameObject endPanel;
    public GameObject vicPanel;
    public GameObject consolePanel;
    public GameObject fixText;

    bool Win = false;

    bool rightWord = false;

    bool debugMode = false;

    string[] inputs =
    {
        "World",
        "e the",
        "ng to",
        "to a programming",
        "t a compu",
        "o hell",
        "language",
        "mmable",
        "y an ex",
        "t book pr",
        "rian Kern",
        "hrase has been",
        "ma and excla",
        "t to specific variations,",
        "ers,"
    };

    private string fullText;

    private void Start()
    {
        AudioManager.instance.Play("Glich");
        //Debug.Log(inputs.Length);
        fullText = "A Hello, World! program generally is a computer program that outputs or displays the message Hello, World!." +
            " Such a program is very simple in most programming languages, " +
            "and is often used to illustrate the basic syntax of a programming language. " +
            "It is often the first program written by people learning to code. \n\n" +

            "Purpose\n" +
            "A Hello, World! program is traditionally used to introduce novice programmers to a programming language." +
            "Hello, World! is also traditionally used in a sanity test to make sure that a computer language is " +
            "correctly installed, and that the operator understands how to use it." +
            "Time to hello world (TTHW) is a metric for the time to author a Hello World program in a given" +
            " programming language and run it\n\n" +

            "History\n" +
            "While small test programs have existed since the development of programmable computers, " +
            "the tradition of using the phrase Hello, World! as a test message was influenced by an example " +
            "program in the seminal 1978 book The C Programming Language. The example program in that book prints " +
            "hello, world, and was inherited from a 1974 Bell Laboratories internal memorandum by Brian Kernighan, " +
            "Programming in C: A Tutorial:\n\n" +

            "main(){\n" +
            "\tprintf('hello, world!');\n" +
            "}\n\n" +

            "Variations\n" +
            "The phrase has been used in various deviations in punctuation and casing, " +
            "such as the presence of the comma and exclamation mark, and the capitalization of the leading H and W. " +
            "Some devices limit the format to specific variations," +
            " such as all-capitalized versions on systems that support only capital letters, " +
            "while some esoteric programming languages may have to print a slightly modified string. " +
            "For example, the first non-trivial Malbolge program printed HEllO WORld, " +
            "this having been determined to be good enough.";

        inputField.Select();
        inputField.ActivateInputField();


        StartCoroutine(ShowText());

    }

    private void Update()
    {
        // questions();
        if (Win)
            allDone();
    }

    public void questions()
    {
        string text = inputField.text.Trim((char)8203);
        // if (Input.GetKeyDown(KeyCode.Return))
        // {
            inputField.Select();
            inputField.ActivateInputField();
            if (nextWord == 1)
            {
                if (text == inputs[0])
                {
                    placeHolder.text = "";
                    givenText.text = "";
                    rightWord = true;
                    nextWord++;
                    fixText.SetActive(false);
                }
            }
            else if (nextWord == 2)
            {
                if (text == inputs[1])
                {
                    placeHolder.text = "";
                    givenText.text = "";
                    rightWord = true;
                    nextWord++;
                    fixText.SetActive(false);
                }
            }
            else if (nextWord == 3)
            {
                if (text == inputs[2])
                {
                    placeHolder.text = "";
                    givenText.text = "";
                    rightWord = true;
                    nextWord++;
                    fixText.SetActive(false);
                }
            }
            else if (nextWord == 4)
            {
                if (text == inputs[3])
                {
                    placeHolder.text = "";
                    rightWord = true;
                    nextWord++;
                    fixText.SetActive(false);
                }
            }

            else if (nextWord == 5)
            {
                if (text == inputs[4])
                {
                    placeHolder.text = "";
                    rightWord = true;
                    nextWord++;
                    fixText.SetActive(false);
                }
            }
            else if (nextWord == 6)
            {
                if (text == inputs[5])
                {
                    placeHolder.text = "";
                    rightWord = true;
                    nextWord++;
                    fixText.SetActive(false);
                }
            }
            else if (nextWord == 7)
            {
                if (text == inputs[6])
                {
                    placeHolder.text = "";
                    rightWord = true;
                    nextWord++;
                    fixText.SetActive(false);
                }
            }
            else if (nextWord == 8)
            {
                if (text == inputs[7])
                {
                    placeHolder.text = "";
                    rightWord = true;
                    nextWord++;
                    fixText.SetActive(false);
                }
            }
            else if (nextWord == 9)
            {
                if (text == inputs[8])
                {
                    placeHolder.text = "";
                    rightWord = true;
                    nextWord++;
                    fixText.SetActive(false);
                }
            }
            else if (nextWord == 10)
            {
                if (text == inputs[9])
                {
                    placeHolder.text = "";
                    rightWord = true;
                    nextWord++;
                    fixText.SetActive(false);
                }
            }
            else if (nextWord == 11)
            {
                if (text == inputs[10])
                {
                    placeHolder.text = "";
                    rightWord = true;
                    nextWord++;
                    fixText.SetActive(false);
                }
            }
            else if (nextWord == 12)
            {
                if (text == inputs[11])
                {
                    placeHolder.text = "";
                    rightWord = true;
                    nextWord++;
                    fixText.SetActive(false);
                }
            }
            else if (nextWord == 13)
            {
                if (text == inputs[12])
                {
                    placeHolder.text = "";
                    rightWord = true;
                    nextWord++;
                    fixText.SetActive(false);
                }
            }
            else if (nextWord == 14)
            {
                if (text == inputs[13])
                {
                    placeHolder.text = "";
                    rightWord = true;
                    nextWord++;
                    fixText.SetActive(false);
                }
            }
            else if (nextWord == 15)
            {
                if (text == inputs[14])
                {
                    placeHolder.text = "";
                    rightWord = true;
                    nextWord++;
                    fixText.SetActive(false);
                }
            }
            else if (nextWord == 16)
            {
                if (text == inputs[15])
                {
                    placeHolder.text = "";
                    rightWord = true;
                    nextWord++;
                    fixText.SetActive(false);
                }
            }
            inputField.text = "";
        // }

    }

    IEnumerator ShowText()
    {
        AudioManager.instance.Play("Typewriter");
        for (int i = 0; i <= fullText.Length; i++)
        {

            currentText = fullText.Substring(0, i);
            if (!debugMode)
            {

                if (i == 100)
                {
                    AudioManager.instance.Stop("Typewriter");
                    placeHolder.text = inputs[0];
                    fixText.SetActive(true);
                    yield return new WaitUntil(() => rightWord == true);
                    AudioManager.instance.Play("Typewriter");
                    rightWord = false;
                }
                if (i == 200)
                {
                    AudioManager.instance.Stop("Typewriter");
                    placeHolder.text = inputs[1];
                    fixText.SetActive(true);
                    yield return new WaitUntil(() => rightWord == true);
                    AudioManager.instance.Play("Typewriter");
                    rightWord = false;
                }
                if (i == 300)
                {
                    AudioManager.instance.Stop("Typewriter");
                    placeHolder.text = inputs[2];
                    fixText.SetActive(true);
                    yield return new WaitUntil(() => rightWord == true);
                    AudioManager.instance.Play("Typewriter");
                    rightWord = false;
                }

                if (i == 400)
                {
                    AudioManager.instance.Stop("Typewriter");
                    placeHolder.text = inputs[3];
                    fixText.SetActive(true);
                    yield return new WaitUntil(() => rightWord == true);
                    AudioManager.instance.Play("Typewriter");
                    rightWord = false;
                }
                if (i == 500)
                {
                    AudioManager.instance.Stop("Typewriter");
                    placeHolder.text = inputs[4];
                    fixText.SetActive(true);
                    yield return new WaitUntil(() => rightWord == true);
                    AudioManager.instance.Play("Typewriter");
                    rightWord = false;
                }


                if (i == 600)
                {
                    AudioManager.instance.Stop("Typewriter");
                    placeHolder.text = inputs[5];
                    fixText.SetActive(true);
                    yield return new WaitUntil(() => rightWord == true);
                    AudioManager.instance.Play("Typewriter");
                    rightWord = false;
                }
                if (i == 700)
                {
                    AudioManager.instance.Stop("Typewriter");
                    placeHolder.text = inputs[6];
                    fixText.SetActive(true);
                    yield return new WaitUntil(() => rightWord == true);
                    AudioManager.instance.Play("Typewriter");
                    rightWord = false;
                }
                if (i == 800)
                {
                    AudioManager.instance.Stop("Typewriter");
                    placeHolder.text = inputs[7];
                    fixText.SetActive(true);
                    yield return new WaitUntil(() => rightWord == true);
                    AudioManager.instance.Play("Typewriter");
                    rightWord = false;
                }
                if (i == 900)
                {
                    AudioManager.instance.Stop("Typewriter");
                    placeHolder.text = inputs[8];
                    fixText.SetActive(true);
                    yield return new WaitUntil(() => rightWord == true);
                    AudioManager.instance.Play("Typewriter");
                    rightWord = false;
                }
                if (i == 1000)
                {
                    AudioManager.instance.Stop("Typewriter");
                    placeHolder.text = inputs[9];
                    fixText.SetActive(true);
                    yield return new WaitUntil(() => rightWord == true);
                    AudioManager.instance.Play("Typewriter");
                    rightWord = false;
                }
                if (i == 1100)
                {
                    AudioManager.instance.Stop("Typewriter");
                    placeHolder.text = inputs[10];
                    fixText.SetActive(true);
                    yield return new WaitUntil(() => rightWord == true);
                    AudioManager.instance.Play("Typewriter");
                    rightWord = false;
                }
                if (i == 1200)
                {
                    AudioManager.instance.Stop("Typewriter");
                    placeHolder.text = inputs[11];
                    fixText.SetActive(true);
                    yield return new WaitUntil(() => rightWord == true);
                    AudioManager.instance.Play("Typewriter");
                    rightWord = false;
                }
                if (i == 1300)
                {
                    AudioManager.instance.Stop("Typewriter");
                    placeHolder.text = inputs[12];
                    fixText.SetActive(true);
                    yield return new WaitUntil(() => rightWord == true);
                    AudioManager.instance.Play("Typewriter");
                    rightWord = false;
                }
                if (i == 1400)
                {
                    AudioManager.instance.Stop("Typewriter");
                    placeHolder.text = inputs[13];
                    fixText.SetActive(true);
                    yield return new WaitUntil(() => rightWord == true);
                    AudioManager.instance.Play("Typewriter");
                    rightWord = false;
                }
                if (i == 1500)
                {
                    AudioManager.instance.Stop("Typewriter");
                    placeHolder.text = inputs[14];
                    fixText.SetActive(true);
                    yield return new WaitUntil(() => rightWord == true);
                    AudioManager.instance.Play("Typewriter");
                    rightWord = false;
                }
            }

            this.GetComponent<TextMeshProUGUI>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
        Win = true;
    }
    float speed = 0;

    void allDone()
    {
        inputField.gameObject.SetActive(false);
        consolePanel.SetActive(false);
        oras.active = false;

        speed += 0.7f * Time.deltaTime;
        endPanel.GetComponent<Image>().color = new Color(0,0,0,Mathf.Lerp(0,1,speed));
        vicPanel.SetActive(true);
    }
}
