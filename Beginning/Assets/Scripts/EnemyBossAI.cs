using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossAI : MonoBehaviour {
    public float playerdistance;
    public float enemylookdistance;
    public float attackdistance;
    public float emenyspeed;
    public float damping;
    public Transform target;
    Rigidbody therigidbody;
    Renderer myrender;
    public GameObject bulletPrefab;
    
    public Transform bulletSpawn;
 
    private bool fireo = true;
    private int health = 100;
    public int current_health;
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
    void Fire()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(bulletPrefab,bulletSpawn.position,bulletSpawn.rotation);
        target=GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Transform>();
        

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = target.forward * 05;

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 0.5f);
       
    }
    
    void attack() {
        if (fireo)
        {
/// yield return new WaitForSeconds(5);
            Fire();
            
        }

            }
}
