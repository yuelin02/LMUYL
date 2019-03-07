using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour
{

	public AudioClip SoundToPlay;
	public float Volume;
	AudioSource audio;
	public bool alreadyPlayed = false;
	public GameObject VrCam;
	private int StoryIsTelling;
	public CameraTrigger CamTrigger;
	void Start()
	{
		audio = GetComponent<AudioSource>();
	}
		
	void Update(){
		audio = GetComponent<AudioSource>();
		StoryIsTelling = VrCam.GetComponent<CameraTrigger>()._StoryIsTelling;

		if(audio.isPlaying == false && StoryIsTelling>1){
			CamTrigger.StoryIsTellingMinus();
			gameObject.GetComponent<PlaySound>().enabled = false;
		}
	}
	void OnTriggerEnter(Collider other)
	{
		StoryIsTelling = VrCam.GetComponent<CameraTrigger>()._StoryIsTelling;
		if (other.gameObject.name == "NVRPlayer" || other.gameObject.transform.parent.name == "NVRPlayer") {
			if (!alreadyPlayed && StoryIsTelling < 1)
			{
				CamTrigger.StoryIsTellingAdd();
				audio.PlayOneShot(SoundToPlay, Volume);
				alreadyPlayed = true; 
			}
		}
	}
}
