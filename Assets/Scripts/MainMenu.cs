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


    private void Start()
    {
        startBtn.interactable = false;
        quitBtn.interactable = false;
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
    }

    public void enableQuit()
    {
        quitBtn.interactable = !quitBtn.interactable;
    }
}
