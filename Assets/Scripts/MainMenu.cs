using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class MainMenu : MonoBehaviour
{
    public Button startBtn;
    public Button quitBtn;
    [SerializeField]
    Material glitchMat;
    int randValue = 0;
    Material startBtnMat, quitBtnMat;


    private void Start()
    {
        startBtn.interactable = false;
        startBtnMat = Instantiate(glitchMat);
        startBtnMat = glitchMat;
        startBtnMat.SetFloat("_RandValue", randValue);
        startBtn.GetComponent<Image>().material = startBtnMat;
        randValue += 1;
        quitBtn.interactable = false;
        quitBtnMat = Instantiate(glitchMat);
        quitBtnMat.SetFloat("_RandValue", randValue);
        quitBtn.GetComponent<Image>().material = quitBtnMat;
        randValue++;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void enablePlay()
    {
        startBtn.interactable = !startBtn.interactable;
        if(!startBtn.interactable)
        {
            startBtnMat.SetFloat("_RandValue", randValue);
            startBtn.GetComponent<Image>().material = startBtnMat;
            randValue += 1;
        }
        else
        {
            startBtn.GetComponent<Image>().material = null;
        }
    }

    public void enableQuit()
    {
        quitBtn.interactable = !quitBtn.interactable;
        if(!quitBtn.interactable)
        {
            quitBtnMat.SetFloat("_RandValue", randValue);
            quitBtn.GetComponent<Image>().material = quitBtnMat;
            randValue++;
        }
        else
        {
            quitBtn.GetComponent<Image>().material = null;
        }
    }
}
