using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour {

	void Update()
	{ 

		if (Input.GetKey (KeyCode.Y))
			SceneManager.LoadScene ("main");

		if (Input.GetKey (KeyCode.N))
			Application.Quit ();
		    Debug.Log ("Game is exiting");
	}



	
}