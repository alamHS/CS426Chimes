﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {
	public Transform player;
	// Update is called once per frame
	void Update () {
		transform.LookAt (player);
		transform.Translate (Vector3.right * Time.deltaTime * 5);
		
	}
}
