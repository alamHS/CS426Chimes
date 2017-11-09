using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour {

	public Slider healthBarSlider;  
 	public Text gameOverText;  
 	private bool isGameOver = false; 
 
	void Start()
	{
  		gameOverText.enabled = false; 
 	}
 

 	void Update () 
	{
 	 	
  		if(!isGameOver)
   			transform.Translate(Input.GetAxis("Horizontal")*Time.deltaTime*10f, 0, 0); //get input
 	}
 

 	void OnTriggerStay(Collider other)
	{
		Debug.Log ("enemy collision");
  		
  		if(other.gameObject.name=="enemy1" && healthBarSlider.value>0)
		{
   			healthBarSlider.value -=10.0f;  
  		}
  		else
		{
   			isGameOver = true;    
   			gameOverText.enabled = true;
  		}
 	}
}
