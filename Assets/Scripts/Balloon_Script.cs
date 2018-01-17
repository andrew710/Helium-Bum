using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Balloon_Script : MonoBehaviour {
    public static double helium;
    public Text helium_text;
    public static int currency = 100;

    public Rigidbody2D rbody;

	// Use this for initialization
	void Start () {
        helium = 0;
        helium_text.text = "Helium: " + helium;
        rbody.GetComponent<Rigidbody2D>();
        rbody.gravityScale *= (float)(helium * 0.25);
	}
	
	// Update is called once per frame
	void Update () {
        if (helium < 32)
        {
            if (helium <= 0)
            {
                helium = 0;
                helium_text.text = "Helium: " + helium;
                if (rbody.gravityScale <= 1)
                    rbody.gravityScale += (float)(0.5 * Time.deltaTime);
            }
            else
            {
                if (rbody.gravityScale <= 1)
                    rbody.gravityScale += (float)(0.5 * Time.deltaTime);
                helium -= (12 * Time.deltaTime);
                helium_text.text = "Helium: " + System.Math.Truncate(helium * 100) / 100;
            }
        }
        else
        {
            helium -= (12 * Time.deltaTime);
            helium_text.text = "Helium: " + System.Math.Truncate(helium * 100) / 100;
        }
    }

}
