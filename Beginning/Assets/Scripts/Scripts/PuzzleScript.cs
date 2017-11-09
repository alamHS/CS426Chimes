﻿using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleScript : MonoBehaviour {

	public GameObject wall;
	public GameObject switch1;
	public GameObject switch2;
	public GameObject switch3;
	public GameObject switch4;
	public GameObject switch5;
	Renderer colorSwitch1;
	Renderer colorSwitch2;
	Renderer colorSwitch3;
	Renderer colorSwitch4;
	Renderer colorSwitch5;
	Rigidbody ofWall;
	//Rigidbody rb;
	int[] solutionArray = new int[3];
	//int[] playerArray;
	int[] test2 = new int[3];

	// Use this for initialization
	void Start () {		
		colorSwitch1 = switch1.GetComponent<Renderer> ();
		colorSwitch2 = switch2.GetComponent<Renderer> ();
		colorSwitch3 = switch3.GetComponent<Renderer> ();
		colorSwitch4 = switch4.GetComponent<Renderer> ();
		colorSwitch5 = switch5.GetComponent<Renderer> ();
		ofWall = wall.GetComponent<Rigidbody> ();
		ofWall.isKinematic = true;

		//solutionArray = generateSolution ();
		solutionArray[0] = 1;
		solutionArray[1] = 2;
		solutionArray[2] = 3;
		for(int i=0;i<solutionArray.Length;i++)
			Debug.Log (solutionArray[i]);
	}
	
	// Update is called once per frame
	void Update () {
		/*if (Input.GetKey (KeyCode.LeftShift)) 
		{
			Shoot ();
		}*/

	}

	void OnCollisionEnter(Collision collision) {
		if (tag == "1") {
			if (solutionArray.Contains (1))
				colorSwitch1.material.color = Color.green;
			else {
				colorSwitch1.material.color = Color.red;
				solutionArray = generateSolution ();
				colorSwitch2.material.color = Color.white;
				colorSwitch3.material.color = Color.white;
				colorSwitch4.material.color = Color.white;
				colorSwitch5.material.color = Color.white;
			}
		}
		if (tag == "2") {
			if (solutionArray.Contains (2))
				colorSwitch2.material.color = Color.green;
			else {
				colorSwitch2.material.color = Color.red;
				solutionArray = generateSolution ();
				colorSwitch1.material.color = Color.white;
				colorSwitch3.material.color = Color.white;
				colorSwitch4.material.color = Color.white;
				colorSwitch5.material.color = Color.white;
				}
			}
		if (tag == "3") {
			if (solutionArray.Contains (3))
				colorSwitch3.material.color = Color.green;
			else{
				colorSwitch3.material.color = Color.red;
				solutionArray = generateSolution ();
				colorSwitch1.material.color = Color.white;
				colorSwitch2.material.color = Color.white;
				colorSwitch4.material.color = Color.white;
				colorSwitch5.material.color = Color.white;
			}
		}
		if (tag == "4") {
			if (solutionArray.Contains (1))
				colorSwitch4.material.color = Color.red;
			else{
				colorSwitch4.material.color = Color.blue;
				solutionArray = generateSolution ();
				colorSwitch1.material.color = Color.white;
				colorSwitch2.material.color = Color.white;
				colorSwitch3.material.color = Color.white;
				colorSwitch5.material.color = Color.white;
			}
		}
		if (tag == "5") {
			if (solutionArray.Contains (1))
				colorSwitch5.material.color = Color.green;
			else{
				colorSwitch5.material.color = Color.red;
				solutionArray = generateSolution ();
				colorSwitch1.material.color = Color.white;
				colorSwitch2.material.color = Color.white;
				colorSwitch3.material.color = Color.white;
				colorSwitch4.material.color = Color.white;
			}
		}

		if (verifySolution() == true) {
			Debug.Log ("open gate");
			ofWall.isKinematic = false;
		} 
		else {
			Debug.Log ("close gate");
		}
	}

	int[] generateSolution()
	{
		int Min = 1;
		int Max = 5;
		int i = 0;
		System.Random randNum = new System.Random();
		while (i < 3)
		{
			bool isPresent = false;
			int temp = randNum.Next(Min,Max);
			if (!test2.Contains (temp)) {
				test2 [i] = temp;
				i++;
			}
		}
		return test2;
	}


	bool verifySolution()
	{
		int count=0;
		for (int i = 0; i < solutionArray.Length; i++) {
			if (solutionArray [i] == 1 && colorSwitch1.material.color==Color.green)
				count++;
			if (solutionArray [i] == 2 && colorSwitch2.material.color==Color.green)
				count++;
			if (solutionArray [i] == 3 && colorSwitch3.material.color==Color.green)
				count++;
			if (solutionArray [i] == 4 && colorSwitch4.material.color==Color.green)
				count++;
			if (solutionArray [i] == 5 && colorSwitch5.material.color==Color.green)
				count++;
		}
		if (count == 3)
			return true;
		else
			return false;
	}
}
