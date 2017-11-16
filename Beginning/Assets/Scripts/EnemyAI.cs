using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyAI : MonoBehaviour {
	public GameObject enemy;
	Renderer colorSwitch;
	Renderer enemyMesh;
	public GameObject switch1;
	public Transform rumi;

	private Animator animator;

	// Use this for initialization
	void Start () {
		colorSwitch = switch1.GetComponent<Renderer>();
		enemyMesh = GetComponent<Renderer>();
		animator = GetComponent<Animator>();
		
	}

	// Update is called once per frame
	void Update () {

		if(colorSwitch.material.color == Color.red)
		{
			enemyMesh.material.color = Color.red;
			transform.LookAt (rumi);
			transform.position += transform.forward * 10 * Time.deltaTime;
			animator.SetTrigger ("isAttack");
		}
               
	}
	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag=="bull")
			Destroy (gameObject);
	}
}
