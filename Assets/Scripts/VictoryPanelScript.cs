using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryPanelScript : MonoBehaviour
{
    void OnEnable()
    {
        if(SceneManager.GetActiveScene().name == "Tarita test")
        {
            StartCoroutine(GoToMoras());
        }
        else if(SceneManager.GetActiveScene().name == "RikunScene")
        {
            StartCoroutine(GoToGameOver());
        }
        else
        {
            StartCoroutine(BackToOverworld());
        }   
    }

    IEnumerator BackToOverworld()
    {
        yield return new WaitForSeconds(3.0f);
        LevelManager.LevelMaster.ClearGlitchedWorld(SceneManager.GetActiveScene().name);
        LevelManager.LevelMaster.GoToLevel("OverWorld");
    }

    IEnumerator GoToMoras()
    {
        yield return new WaitForSeconds(3.0f);
        LevelManager.LevelMaster.ClearGlitchedWorld(SceneManager.GetActiveScene().name);
        LevelManager.LevelMaster.GoToLevel("RikunScene");
    }

    IEnumerator GoToGameOver()
    {
        yield return new WaitForSeconds(3.0f);
        LevelManager.LevelMaster.ClearGlitchedWorld(SceneManager.GetActiveScene().name);
        LevelManager.LevelMaster.GoToLevel("GameOver");
    }
}
