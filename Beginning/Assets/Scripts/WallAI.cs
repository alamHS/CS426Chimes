using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAI : MonoBehaviour {
	public Transform testwall;
	Renderer colorRumi;
	Renderer wallMesh;
	public GameObject rumi;
	// Use this for initialization
	void Start () {
		colorRumi = rumi.GetComponent<Renderer>();
		wallMesh = GetComponent<Renderer>();

		
	}
	
	// Update is called once per frame
	void Update () {

		if(colorRumi.material.color == Color.red)
		{
			wallMesh.enabled = false;
		}
                
			
}
}
