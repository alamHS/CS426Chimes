using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour {

	// Update is called once per frame
	public void Update (string changeScene) {
		SceneManager.LoadScene("StoryOne");
	}


	
}