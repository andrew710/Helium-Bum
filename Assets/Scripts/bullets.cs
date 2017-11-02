using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullets : MonoBehaviour {
    /*
    *add force to the bullet so it moves in a straight line
    *detect when it hits balloon and destroy the balloon *
    * destroy bullet once it leaves camera
    */
    
    private GameObject cannon;

	// Use this for initialization
	void Start () {
        cannon = GameObject.FindGameObjectWithTag("Cannon");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(cannon.transform.rotation.z == 0)    //facing right
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * 10);
        }
        else if (cannon.transform.rotation.z == 180 || cannon.transform.rotation.z == -180)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * 10);
        }
	}

    //Fix problem: fan collider destroys bullets
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Balloon"))
        {
            Destroy(collision.gameObject);
        }
        else
            Destroy(gameObject);
    }
}
