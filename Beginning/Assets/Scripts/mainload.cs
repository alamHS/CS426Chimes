﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainload : MonoBehaviour {

	// Update is called once per frame
	public void Update (string changeScene) {
		SceneManager.LoadScene("main");
	}
}
