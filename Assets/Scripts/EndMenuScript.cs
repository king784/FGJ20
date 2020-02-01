using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndMenuScript : MonoBehaviour
{
    public Button mainMenuBtn;
    public Button exitGameBtn;
    // Start is called before the first frame update
    void Start()
    {
        mainMenuBtn.onClick.AddListener(ReturnToMenu);
        exitGameBtn.onClick.AddListener(ExitGame);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
