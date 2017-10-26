using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    public float playerdistance;
    public float enemylookdistance;
    public float attackdistance;
    public float emenyspeed;
    public float damping;
    public Transform target;
    Rigidbody therigidbody;
    Renderer myrender;
	// Use this for initialization
	void Start () {
        myrender = GetComponent<Renderer>();
        therigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        playerdistance = Vector3.Distance(target.position, transform.position);
        if(playerdistance<enemylookdistance)
        {
            myrender.material.color = Color.yellow;
            look();

        }
        if (playerdistance < attackdistance)
        {
            myrender.material.color = Color.red;
            attack();
        }
        else
        { myrender.material.color = Color.blue; }

    }
    void look() {
        Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation,Time.deltaTime * damping);
    }
    void attack() {
        therigidbody.AddForce(transform.forward * emenyspeed);
            }
}
