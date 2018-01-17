using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

    public static bool dead = false;

    //Balloon(or other object) hits the spikes
    private void OnTriggerEnter2D(Collider2D balloon)
    {
        if (balloon.gameObject.tag == "Balloon")
        {
            Destroy(balloon.gameObject);
            Time.timeScale = 0;
            Projectile_Script.dead = true;
        }
    }

}
