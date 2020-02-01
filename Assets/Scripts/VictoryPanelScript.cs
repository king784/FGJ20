using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryPanelScript : MonoBehaviour
{
    void OnEnable()
    {
        StartCoroutine(BackToOverworld());   
    }

    IEnumerator BackToOverworld()
    {
        yield return new WaitForSeconds(3.0f);
        LevelManager.LevelMaster.GoToLevel("OverWorld");
    }
}
