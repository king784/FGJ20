using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryPanelScript : MonoBehaviour
{
    void OnEnable()
    {
        StartCoroutine(BackToOverworld());   
    }

    IEnumerator BackToOverworld()
    {
        yield return new WaitForSeconds(3.0f);
        LevelManager.LevelMaster.ClearGlitchedWorld(SceneManager.GetActiveScene().name);
        LevelManager.LevelMaster.GoToLevel("OverWorld");
    }
}
