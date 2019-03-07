using UnityEngine;
using System.Collections;

public class CameraOrbit : MonoBehaviour {

	public Transform target;
	public float rotSpeed = 15f;

//	public float rotSpeed = 0.5f;

	public void MoveHorizontal(bool left){
		float dir = 1;
		if (!left)
			dir *= -1;
		transform.RotateAround (target.position, Vector3.up, 10*Time.deltaTime * rotSpeed * dir);
	}
	public void MoveVertical(bool up){
		float dir = 1;
		if (!up)
			dir *= -1;
		transform.RotateAround (target.position, transform.TransformDirection(Vector3.right), 10*Time.deltaTime * rotSpeed * dir);
	}
}