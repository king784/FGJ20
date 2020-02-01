using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource effectSource;                    //For effects
    public AudioSource musicSource;                  //For music
    public static SoundManager instance = null;        


    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void PlaySingle(AudioClip clip)
    {
        effectSource.clip = clip;

        effectSource.Play();
    }
}
