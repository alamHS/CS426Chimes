using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class red : MonoBehaviour {
	bool canInteract = false;
	float displayTime = 3.0f;
	bool displayMsg = false;

	void Update () {
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

		void OnGUI()
		{
			if (displayMsg) {
				if (canInteract) {
					GUIStyle textStyle = new GUIStyle ();
					textStyle.normal.textColor = Color.white;
					GUI.Label (new Rect (500, 100, 300, 20), "The wind will extinguish this searing hue", textStyle);

				}
			}
		}

}
