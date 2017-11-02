using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class my_fan : MonoBehaviour {

    bool inRange = false;
    private GameObject bloon;

    /*
     * This function calls itself automatically
     */ 
    private void OnTriggerEnter2D(Collider2D balloon)
    {
        inRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inRange = false;
    }

    // Use this for initialization
    void Start () {
        bloon = GameObject.FindGameObjectWithTag("Balloon"); //finds object, assigns gameobject with tag balloon to variable name bloon
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (inRange == true)
        {
            bloon.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 100);
        }
           
    }
}
