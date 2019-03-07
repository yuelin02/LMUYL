using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBallLayer : MonoBehaviour {

    public int layerOnEnter; //BallInHole
    public int layerOnExit; //BallOnTable

	void OnTriggerEnter (Collider other) {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.layer = layerOnEnter;
        }
		
	}

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.layer = layerOnExit;
        }

    }
}
