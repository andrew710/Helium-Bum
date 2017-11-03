using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Inflation_Platform : MonoBehaviour {

    private Balloon_Script balloon;
    private Rigidbody2D rbody;
    public static bool addHelium;
    public Text helium_text;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Balloon"))
        {
            rbody = collision.gameObject.GetComponent<Rigidbody2D>();
            addHelium = true;
            Time.timeScale = 0; //pause game
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (addHelium)
        {
            if (addHelium)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    Balloon_Script.helium += 0.5;
                    helium_text.text = "helium: " + System.Math.Truncate(Balloon_Script.helium * 100) / 100;
                }
            }
            if (Input.GetKey(KeyCode.Return))
            {
                Time.timeScale = 1;
                rbody.gravityScale =(float)-0.5 * (float)(Balloon_Script.helium * 0.025);
            }
            }

	}
    


}
