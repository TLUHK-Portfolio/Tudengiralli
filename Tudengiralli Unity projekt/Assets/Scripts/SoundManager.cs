using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //Drag a reference to the audio source which will play the sound effects.
    public AudioSource efxSource;
    //Drag a reference to the audio source which will play the music.
    public AudioSource musicSource;
    //Allows other scripts to call functions from the SoundManager
    public static SoundManager instance = null;
    //backround Music volume
    public float backroundMusicVolume = .2f;



    void Awake()
    {
        //Check if there is already an instance of SoundManager
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);

        efxSource.volume = PlayerPrefs.GetFloat("efx");
        musicSource.volume = PlayerPrefs.GetFloat("music");
    }


    //Used to play single sound clips.
    public void PlaySingle(AudioClip clip)
    {
        //Set the clip of our efxSource audio source to the clip passed in as a parameter.
        efxSource.clip = clip;

        //Play the clip.
        efxSource.Play();
    }

}
