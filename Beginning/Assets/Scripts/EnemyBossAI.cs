using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnemyBossAI : MonoBehaviour {
    public float playerdistance;
    public float enemylookdistance;
    public float stop;
    public float attackdistance;
    public float emenyspeed;
    public float damping;
    public Transform target;
    Rigidbody therigidbody;
    Renderer myrender;
    private Animator animator;

    

    private bool fireo = true;
    private int health = 100;
    public int current_health;
    // Use this for initialization
    void Start() {
        myrender = GetComponent<Renderer>();
        therigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update() {
        playerdistance = Vector3.Distance(target.position, transform.position);
        if (playerdistance < enemylookdistance && playerdistance > attackdistance)
        {

            myrender.material.color = Color.yellow;
            therigidbody.velocity = this.transform.forward * 0;
            Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);

        }
        if (playerdistance < attackdistance)
        {
            myrender.material.color = Color.red;
            therigidbody.AddForce(transform.forward * emenyspeed);
            animator.SetTrigger("run");
            Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);

        }
        if (playerdistance <= stop)
        {
            myrender.material.color = Color.blue;
            therigidbody.velocity = this.transform.forward * 0;
            animator.SetTrigger("attack");

            Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
        }
        else
        {
            //therigidbody.velocity = this.transform.forward * 0;
            animator.SetTrigger("idle");
        }
        //therigidbody.velocity = this.transform.forward * 0;
        

    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("bull"))
        {
            health = health - 5;
            animator.SetTrigger("shoot");
            if (health <= 0)
            {
                GetComponent<Rigidbody>().isKinematic = true;

               
                animator.SetTrigger("dead");
            }
        }

            

    }
}
