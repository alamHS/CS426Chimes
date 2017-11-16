using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blue : MonoBehaviour {
	public GameObject switch1;
	public GameObject sign;
	Renderer color1;
	Renderer color2;

	bool canInteract = false;
	float displayTime = 3.0f;
	bool displayMsg = false;


	void Start(){
		color1 = switch1.GetComponent<Renderer>();
		color2 = sign.GetComponent<Renderer> ();
		color2.enabled = false;
	}

	void Update () {

		if (color1.material.color == Color.green) {
			color2.enabled = true;
			displayTime -= Time.deltaTime;
			if (displayTime <= 0.0)
				displayMsg = false;

			RaycastHit hit;
			Ray shootRay = new Ray (this.transform.position, Vector3.back);

			if (Physics.Raycast (shootRay, out hit, 50)) {
				if (hit.collider.tag == "Player") {
					canInteract = true;
					displayMsg = true;
					displayTime = 3.0f;
				}
			}
		}
	}

	void OnGUI()
	{
		
		if (displayMsg) {
			if (canInteract) {
				GUIStyle textStyle = new GUIStyle ();
				textStyle.normal.textColor = Color.white;
				GUI.Label (new Rect (400, 100, 300, 500), "From the oceans will you hear rhythms, that is where they will call you", textStyle);

			}
		}
	}

}
