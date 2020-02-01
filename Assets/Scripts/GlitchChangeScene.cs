using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlitchChangeScene : MonoBehaviour
{

    public string worldToGoto = "";

    public void moveToGlitchedWorld()
    {
        SceneManager.LoadScene(worldToGoto);
    }
}
