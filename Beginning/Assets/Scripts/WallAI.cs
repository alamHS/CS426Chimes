using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAI : MonoBehaviour {

	Rigidbody rumi;
	Renderer color;
	// Use this for initialization
	void Start () {
		rumi = GetComponent<Rigidbody>();
		color = GetComponent<Renderer>();

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
