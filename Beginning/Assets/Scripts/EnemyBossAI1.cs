using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour {
    public int health = 100;
	// Use this for initialization
	void Start () {
        this.gameObject.SetActive(true);
        
    }
	
	// Update is called once per frame
	void Update () {
        if (health >= 50)
        { this.gameObject.SetActive(false); }
    }
}
