using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class over : MonoBehaviour {

	void OnCollisionEnter (Collision collision)
	{ 

		if (collision.gameObject.CompareTag ("hit")) 

			collision.gameObject.SetActive (false);
		SceneManager.LoadScene ("game over");



	}
}



