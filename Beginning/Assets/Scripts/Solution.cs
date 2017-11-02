using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solution : MonoBehaviour {

	public GameObject Rumi; 
	Renderer colorRumi;
	void Start()
	{
		colorRumi = Rumi.GetComponent<Renderer> ();
	}

	
	// Update is called once per frame
	void OnCollisionEnter(Collision collision) {
		colorRumi.material.color = Color.red;
	}
}
