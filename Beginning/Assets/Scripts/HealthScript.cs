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
   			transform.Translate(Input.GetAxis("Horizontal")*Time.deltaTime*10f, 0, 0);
 	}
 

 	void OnTriggerEnter(Collider other)
	{
  		if(other.tag=="enemy1" && healthBarSlider.value>0)
		{
   			healthBarSlider.value -=0.011f; 
			Debug.Log ("enemy collision");
  		}
		else if(healthBarSlider.value<=0.0f)
		{
   			isGameOver = true;    
   			gameOverText.enabled = true;
  		}
 	}
}
