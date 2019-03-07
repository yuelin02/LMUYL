using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class Trigger : MonoBehaviour
{

    private Quaternion rotation;
    bool IsInBambooM;

    public GameObject BambooS;
    public GameObject BambooV;
    public GameObject ConcreteS;
    public GameObject ConcreteV;

    AudioSource[] BambooA;

    public GameObject targetB;
    public GameObject targetC;
    Renderer[] rendB;
    Renderer[] rendC;

    AudioClip[] audioB;
    AudioClip[] audioC;

    void Start()
    {
        BambooM();
        //sounds = 
    }

    void Update()
    {
        this.rotation = InputTracking.GetLocalRotation(VRNode.CenterEye);
        print("x:" + rotation.eulerAngles.x + " y: " + rotation.eulerAngles.y + " z: " + rotation.eulerAngles.z);
        SetMode();
    }

    public void SetMode()
    {
        if (rotation.eulerAngles.y >= 90 && rotation.eulerAngles.y <= 270)
        {
            IsInBambooM = false;
            ConcreteM();
        }
        else
        {
            IsInBambooM = true;
            BambooM();
        }
    }

    void BambooM()
    {
        rendB = targetB.GetComponentsInChildren<Renderer>();
        foreach (Renderer rb in rendB)
            rb.enabled = true;

        rendC = targetC.GetComponentsInChildren<Renderer>();
        foreach (Renderer rc in rendC)
            rc.enabled = false;
    }

    void ConcreteM()
    {
        rendB = targetB.GetComponentsInChildren<Renderer>();
        foreach (Renderer rb in rendB)
            rb.enabled = false;

        rendC = targetC.GetComponentsInChildren<Renderer>();
        foreach (Renderer rc in rendC)
            rc.enabled = true;
    }


    //    void playSound(int clip)
    //    {
    //        audio.clip = AudioB[0];

    //    }
}
