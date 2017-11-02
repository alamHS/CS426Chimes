using System.Linq;
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
	//Rigidbody rb;
	int[] solutionArray;
	//int[] playerArray;
	int[] test2 = new int[3];

	// Use this for initialization
	void Start () {		
		colorSwitch1 = switch1.GetComponent<Renderer> ();
		colorSwitch2 = switch2.GetComponent<Renderer> ();
		colorSwitch3 = switch3.GetComponent<Renderer> ();
		colorSwitch4 = switch4.GetComponent<Renderer> ();
		colorSwitch5 = switch5.GetComponent<Renderer> ();

		solutionArray = generateSolution ();
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
				colorSwitch4.material.color = Color.green;
			else{
				colorSwitch4.material.color = Color.red;
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
			Destroy(GameObject.Find(wall.name));
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

	/*void Shoot()
	{
		RaycastHit hit;
		if (Physics.Raycast (rb.transform.position, rb.transform.forward, out hit, 10f)) 
		{
			if (hit.transform.tag == "1") {
				if (!test2.Contains (1))
					solutionArray = generateSolution ();
				else {
					if (!verifySolution()) {
						
					}
				}
			} else if (hit.transform.tag == "2") {
				if (!test2.Contains (2))
					solutionArray = generateSolution ();
				else {
				}
			} else if (hit.transform.tag == "3") {
				if (!test2.Contains (3))
					solutionArray = generateSolution ();
				else {
				}
			} else if (hit.transform.tag == "4") {
				if (!test2.Contains (4))
					solutionArray = generateSolution ();
				else {
				}
			} else if (hit.transform.tag == "5") {
				if (!test2.Contains (5))
					solutionArray = generateSolution ();
				else {
				}
			}
		}
	}*/

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
