using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class move : MonoBehaviour {

	static Animator anim;
	public float artifactdistance;

	public float speed = 25.0f;
	public float rotationSpeed = 90;
	public float force = 700f;

	public GameObject cannon;
	public GameObject bullet1;
	public GameObject bullet3;
	public GameObject bullet2;
	public GameObject bullet4;
	public AudioSource A;
	public AudioSource W;
	public AudioSource S;
	public AudioSource D;

	public Transform artifact;

	Rigidbody rb;
	Transform t;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		t = GetComponent<Transform> ();
		//var Aclip = Resources.Load<AudioClip>("Recording (2)");
		//A.clip = Aclip;
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.DownArrow))
			rb.velocity -= this.transform.forward * speed * Time.deltaTime;
		else if (Input.GetKey (KeyCode.UpArrow))
			rb.velocity += this.transform.forward * speed * Time.deltaTime;
		if (Input.GetKey (KeyCode.RightArrow))
			t.rotation *= Quaternion.Euler (0, rotationSpeed * Time.deltaTime, 0);
		else if (Input.GetKey (KeyCode.LeftArrow))
			t.rotation *= Quaternion.Euler (0, -rotationSpeed * Time.deltaTime, 0);
		if (Input.GetKeyDown (KeyCode.Space))
			rb.AddForce (t.up * force);
		


		if(Input.GetKeyDown(KeyCode.W))
		{
			W.Play ();
			GameObject newBullet = GameObject.Instantiate(bullet1, cannon.transform.position, cannon.transform.rotation) as GameObject;
			newBullet.GetComponent<Rigidbody>().velocity += Vector3.up * 10;
			newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward * 1000);
			Destroy (newBullet, 1.5f);
		}
		if(Input.GetKeyDown(KeyCode.S))
		{
			S.Play();
			GameObject newBullet = GameObject.Instantiate(bullet2, cannon.transform.position, cannon.transform.rotation) as GameObject;
			newBullet.GetComponent<Rigidbody>().velocity += Vector3.up * 10;
			newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward * 1000);
			Destroy (newBullet, 1.5f);
		}
		if(Input.GetKeyDown(KeyCode.A))
		{
			A.Play();
			GameObject newBullet = GameObject.Instantiate(bullet3, cannon.transform.position, cannon.transform.rotation) as GameObject;
			newBullet.GetComponent<Rigidbody>().velocity += Vector3.up * 10;
			newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward * 1000);
			Destroy (newBullet, 1.5f);
		}
		if(Input.GetKeyDown(KeyCode.D))
		{
			D.Play();
			GameObject newBullet = GameObject.Instantiate(bullet4, cannon.transform.position, cannon.transform.rotation) as GameObject;
			newBullet.GetComponent<Rigidbody>().velocity += Vector3.up * 10;
			newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward * 1000);
			Destroy (newBullet, 1.5f);
		}

		artifactdistance = Vector3.Distance(artifact.position, transform.position);
		if (artifactdistance < 50)
			A.Play ();

		float translation = Input.GetAxis ("Vertical") * speed;
		float rotation = Input.GetAxis ("Horizontal") * rotationSpeed;
		translation *= Time.deltaTime;
		rotation *= Time.deltaTime;
		transform.Translate (0, 0, translation);
		transform.Rotate(0,rotation,0);

		if (translation != 0)
			anim.SetBool ("isRunning", true);
		else
			anim.SetBool ("isRunning", false);
	}
}
