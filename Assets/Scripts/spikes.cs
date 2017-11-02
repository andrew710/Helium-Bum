using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikes : MonoBehaviour {

    bool inRange = false;
    private GameObject bal;

    //Balloon(or other object) hits the spikes
    private void OnTriggerEnter2D(Collider2D balloon)
    {
        inRange = true;
    }

    // Use this for initialization
    void Start () {
		bal = GameObject.FindGameObjectWithTag("Balloon");
    }
	
	// Update is called once per frame
	void Update () {
		if (inRange == true)
        {
            Destroy(bal);
        }
	}
}
