using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    

    public static SoundManager Instance;

    public AudioSource OneShotLooper;

    public AudioClip Skating;
    private void Awake()
    {
        Instance = this;
    }


    public void PlayOneShotLoop(AudioClip audiofile)
    {
        OneShotLooper.clip = audiofile;
        OneShotLooper.Play();
    }

    public void StopOneShotLoop()
    {
        OneShotLooper.Stop();
    }


}
