using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Script : MonoBehaviour {
    /*
    *add force to the bullet so it moves in a straight line
    *detect when it hits balloon and destroy the balloon *
    * destroy bullet once it leaves camera
    */
    
    private GameObject cannon;
    private bool fired = false;
    private GameObject deathScreen;
    public static bool dead;

	// Use this for initialization
	void Start () {
        dead = false;
        cannon = GameObject.FindGameObjectWithTag("Cannon");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!fired)
        {
            if (cannon.transform.rotation.z == 0)    //facing right
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.right * 800);
                fired = true;
            }
            else if (cannon.transform.rotation.z == 180 || cannon.transform.rotation.z == -180)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.left * 800);
                fired = true;
            }
        }
	}

    //Fix problem: fan collider destroys bullets
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Balloon"))
        {
            Destroy(collision.gameObject);
            Time.timeScale = 0;
            dead = true;
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
