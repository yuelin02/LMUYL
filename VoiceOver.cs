using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOver : MonoBehaviour
{

    public AudioClip VoiceClip;
    public float Volume;
    public float DelayTime;
    AudioSource Audio;
    public bool alreadyPlayed = false;
    void Start()
    {

        Audio = GetComponent<AudioSource>();
    }

    public void VoiceTrigger()
    {
        if (!alreadyPlayed)
        {
            Audio.PlayOneShot(VoiceClip, Volume);
            alreadyPlayed = true;
        }
    }
}