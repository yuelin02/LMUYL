using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	CameraOrbit cam;
	private Touch initTouch = new Touch();

	// Use this for initialization
	void Start () {
		cam = GetComponent<CameraOrbit>();
	}
	
	// Update is called once per frame
	void Update () {
//		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
//			cam.MoveHorizontal (true);
//		} else if(Input.GetKeyDown (KeyCode.RightArrow)){
//			cam.MoveHorizontal (false);
//		}else if(Input.GetKeyDown (KeyCode.UpArrow)){
//			cam.MoveVertical (true);
//		}else if(Input.GetKeyDown (KeyCode.DownArrow)){
//			cam.MoveVertical (false);
//		}

		foreach (Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Began) {
				initTouch = touch;
			}else if(touch.phase == TouchPhase.Moved) {
				float deltaX = initTouch.position.x - touch.position.x;
				if (deltaX > 20) {
					cam.MoveHorizontal (true);
				} else if (deltaX < -20) {
					cam.MoveHorizontal (false);
				}
			}
		}
	}
}
