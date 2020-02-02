using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SuperDebug : MonoBehaviour
{
    public static SuperDebug SuperDebuggi { get; private set; }

     private void Awake()
    {
        if (SuperDebuggi == null)//singleton
        {
            SuperDebuggi = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha8))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        if(Input.GetKeyDown(KeyCode.Alpha9))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
