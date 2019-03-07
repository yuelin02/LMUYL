using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXControll : MonoBehaviour {
    /*
    public AudioClip SoundToPlay;
    public float Volume;
    public float DelayTime;
    AudioSource Audio;
    public bool alreadyPlayed = false;
    void Start()
    {

        Audio = GetComponent<AudioSource>();
    }

    public void SoundTrigger()
    {
        if (!alreadyPlayed)
        {
            Audio.PlayOneShot(SoundToPlay, Volume); 
            alreadyPlayed = true;
        }
    }

    */
    public GameObject soundHub;
    AudioSource[] sounds;

   void Start()
    {
        sounds = soundHub.GetComponents<AudioSource>();
    }


     void Update()
    {
        sounds[0].Play(); 

   
     
    }




}