using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LosePanelScript : MonoBehaviour
{
    void OnEnable()
    {
        StartCoroutine(Restart());
    }


    IEnumerator Restart()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
