using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public static LevelManager LevelMaster { get; private set; }
    public float Grade { get => grade; private set => grade = value; }

    // Start is called before the first frame update
    public string[] LevelNames;

    Dictionary<string, bool> FixedGlitchedWorlds = new Dictionary<string, bool>();
    Dictionary<string, GameObject> AllGlitches = new Dictionary<string, GameObject>();
    float grade;


    private void Awake()
    {
        if (LevelMaster == null)//singleton
        {
            LevelMaster = this;
            DontDestroyOnLoad(gameObject);

            foreach (string level in LevelNames)
            {//initialize all worlds to false, none have been cleared yet
                FixedGlitchedWorlds.Add(level, false);
            }
            Grade = 5;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        foreach (GameObject glitch in GameObject.FindGameObjectsWithTag("Glitch"))//find all objects tagged as glitch and add them to a list containig all glitches
        {
            AllGlitches.Add(glitch.GetComponent<GlitchChangeScene>().worldToGoto, glitch);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void checkFixedGlitches()
    {
        foreach (KeyValuePair<string, bool> entry in FixedGlitchedWorlds)
        {
            if (entry.Value == true)
            {
                GameObject glitchToRemove;
                AllGlitches.TryGetValue(entry.Key, out glitchToRemove);//try and find a gameobject with the same key as the cleared world and return it to the glitchtoremove variable
                if (glitchToRemove)//if the same object was found in allglitches
                {
                    AllGlitches.Remove(entry.Key);//glitch has been cleared so delete it from allglitches list
                    Destroy(glitchToRemove);//destroy the glitch gameobject
                }
            }
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "OverWorld")
        {
            checkFixedGlitches();
        }
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void GoToLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void ClearGlitchedWorld(string sceneName)
    {
        foreach (KeyValuePair<string, bool> entry in FixedGlitchedWorlds)
        {
            if (entry.Key.Equals(sceneName))//if item with same key as scene name has been found
            {
                FixedGlitchedWorlds[entry.Key] = true;//set value of item to true, the glitch has been fixed
            }
        }
    }

    public void AddToGrade(float amount)
    {
        Grade += amount;
        Grade = Mathf.Clamp(Grade, -9999, 5);
    }
}
