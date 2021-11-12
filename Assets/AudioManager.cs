using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private AudioSource audiosource;

    public AudioClip correctSound;

    public AudioClip finishSound;

    void Awake () {
        // if the singleton hasn't been initialized yet
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return; //Avoid doing anything else
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);

        audiosource = GetComponent<AudioSource>();
    }

    public void PlayCorrect()
    {
        audiosource.PlayOneShot(correctSound);
    }

    public void PlayFinish()
    {
        audiosource.PlayOneShot(finishSound);
    }
}
