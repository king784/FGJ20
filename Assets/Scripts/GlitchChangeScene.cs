using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlitchChangeScene : MonoBehaviour
{

    public string worldToGoto = "";

    public void moveToGlitchedWorld()
    {
        LevelManager.LevelMaster.SavePlayerPosition();
        LevelManager.LevelMaster.GoToLevel(worldToGoto);
    }
}
