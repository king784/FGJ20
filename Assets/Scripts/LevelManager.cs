using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public static LevelManager LevelMaster { get; private set; }
    public float Grade { get => grade; private set => grade = value; }

    // Start is called before the first frame update
    public List<string> LevelNames = new List<string>();

    Dictionary<string, bool> FixedGlitchedWorlds = new Dictionary<string, bool>();
    Dictionary<string, GameObject> AllGlitches = new Dictionary<string, GameObject>();
    float grade;
    Vector3 playerPositionBeforeGlitch;
    public string currentLevel;


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
                foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Glitch"))
                {
                    if(obj.GetComponent<GlitchChangeScene>().worldToGoto == entry.Key)
                    {
                        Destroy(obj);
                    }
                }
                // GameObject glitchToRemove;
                // foreach (KeyValuePair<string, GameObject> entry2 in AllGlitches)
                // {
                //     if(entry2.Key == entry.Key)
                //     {
                //         AllGlitches.Remove(entry.Key);//glitch has been cleared so delete it from allglitches list
                //         Destroy(entry2.Value.gameObject);//destroy the glitch gameobject
                //         break;
                //     }
                // }
                //AllGlitches.TryGetValue(entry.Key, out glitchToRemove);//try and find a gameobject with the same key as the cleared world and return it to the glitchtoremove variable
                // if (glitchToRemove)//if the same object was found in allglitches
                // {
                    
                // }
            }
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "OverWorld" && LevelNames.Contains(currentLevel))
        {
            checkFixedGlitches();
            playerPositionBeforeGlitch.x += 8.0f;
            GameObject.FindGameObjectWithTag("Player").transform.position = playerPositionBeforeGlitch;
            Camera.main.GetComponent<CameraFollowPlayer>().target = GameObject.Find(currentLevel).transform;
            GameObject.Find(currentLevel + "Wall").GetComponent<BoxCollider2D>().enabled = true;
            // foreach (KeyValuePair<string, bool> entry in FixedGlitchedWorlds)
            // {
            //     Debug.Log(entry.Key);
            //     Debug.Log(entry.Value);
            // }
        }
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void SavePlayerPosition()
    {
        playerPositionBeforeGlitch = GameObject.FindGameObjectWithTag("Player").transform.position;
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
                break;
            }
        }
    }

    public void AddToGrade(float amount)
    {
        Grade += amount;
        Grade = Mathf.Clamp(Grade, -9999, 5);
    }
}
