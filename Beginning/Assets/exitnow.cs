using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitnow : MonoBehaviour {

	
	// Update is called once per frame
	public void Update (int one) {
		Application.Quit ();
		Debug.Log ("Quit works");
	}
}
