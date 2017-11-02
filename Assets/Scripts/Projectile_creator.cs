using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_creator : MonoBehaviour {


    public GameObject bullet;
    float time;

	// Use this for initialization
	void Start () {

        InvokeRepeating("LaunchBullet", 2, 2);
	}
	
	// Update is called once per frame
	void LaunchBullet () {
          
        Instantiate(bullet, transform.position, transform.rotation);
        
	}
}
