using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMouse : MonoBehaviour {

	private const float yMax = 100.0f;
	private const float yMin = -100.0f;



	public Transform follow;
	public Transform camTransform;



	private Camera cam;


	private float distance = 2.0f;
    private float currentX = 0.0f;
	private float currentY = 0.0f;
	private float sensitivityX = 4.0f;
	private float sensitivityY = 1.0f;

	private void start(){
		camTransform = transform;
		cam = Camera.main;
	}

	private void Update(){
		 
		currentX += Input.GetAxis ("Mouse X");
		currentY -= Input.GetAxis ("Mouse Y");

		currentY = Mathf.Clamp (currentY, yMin, yMax);
	}


	private void LateUpdate(){

		Vector3 vector = new Vector3 ( 2, 20, -distance);
		Quaternion rotation = Quaternion.Euler (currentY, currentX, 0);
		camTransform.position = follow.position + rotation * vector;

		camTransform.LookAt (follow.position);



}
}
