using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    

    public static SoundManager Instance;

    public AudioSource OneShotLooper;
    public AudioSource OneShot;

    public AudioClip Skating;
    public AudioClip wallBump;
    public AudioClip Hit;
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


    public void PlayOneShot(AudioClip audiofile)
    {
        //OneShotLooper.clip = audiofile;
        OneShotLooper.PlayOneShot(audiofile);
    }


}
