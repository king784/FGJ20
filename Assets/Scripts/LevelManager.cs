using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public static LevelManager LevelMaster { get; private set; }
    // Start is called before the first frame update

    Dictionary<string, bool> FixedGlitchedWorlds = new Dictionary<string, bool>();

    public string[] LevelNames;

    private void Awake()
    {
        if (LevelMaster == null)//singleton
        {
            LevelMaster = this;
            DontDestroyOnLoad(gameObject);

            foreach(string level in LevelNames){//initialize all worlds to false, none have been cleared yet
                FixedGlitchedWorlds.Add(level, false);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GoToLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
