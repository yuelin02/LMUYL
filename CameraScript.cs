using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class CameraScript : MonoBehaviour {

    private Quaternion rotation;

    bool IsInBambooH;

    public GameObject targetB;
	public GameObject targetC;
	public Material[] materialB;
	public Material[] materialC;
	Renderer[] rendB;
	Renderer[] rendC;

    public AudioClip[] audioB;
    public AudioClip[] audioC;

    void Start () 
	{
        //AudioSource audioB = GetComponent<AudioSource>();
        //AudioSource audioC = GetComponent<AudioSource>();
        IsInBambooH = true;

		rendB = targetB.GetComponentsInChildren<Renderer> (); 
		foreach(Renderer rb in rendB)
			rb.enabled = true;

		rendC = targetC.GetComponentsInChildren<Renderer> (); 
		foreach(Renderer rc in rendC)
			rc.enabled = false;
		//rendB.sharedMaterial = materialB [0];
		//rendC.sharedMaterial = materialC [0];
	}

	void Update () {
		this.rotation = InputTracking.GetLocalRotation (VRNode.CenterEye);
		print ("x:" + rotation.eulerAngles.x + " y: " + rotation.eulerAngles.y + " z: " + rotation.eulerAngles.z);
		SetMode();
	}

	public void SetMode(){
		if (rotation.eulerAngles.y >= 90 && rotation.eulerAngles.y <= 270) {
            IsInBambooH = false;

			rendB = targetB.GetComponentsInChildren<Renderer> (); 
			foreach(Renderer rb in rendB)
				rb.enabled = false;
			
			rendC = targetC.GetComponentsInChildren<Renderer> (); 
			foreach(Renderer rc in rendC)
				rc.enabled = true;
		} else {
            IsInBambooH = true;

            rendB = targetB.GetComponentsInChildren<Renderer> (); 
			foreach(Renderer rb in rendB)
				rb.enabled = true;
			
			rendC = targetC.GetComponentsInChildren<Renderer> (); 
			foreach(Renderer rc in rendC)
				rc.enabled = false;
		}
	}


//    void playSound(int clip)
//    {
//        audio.clip = AudioB[0];

//    }
}
