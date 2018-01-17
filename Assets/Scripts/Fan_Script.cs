using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan_Script : MonoBehaviour {
    public bool inside = false;
    private GameObject balloon;

	// Use this for initialization
	void Start () {
        balloon = GameObject.FindGameObjectWithTag("Balloon");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (inside)
        {
            if (gameObject.tag.Equals("Weaker Fan"))
            {
                if (transform.parent.localScale.x >= 0 && balloon.GetComponent<Rigidbody2D>().velocity.x < 8f)
                    balloon.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 150);

                else if (transform.parent.localScale.x < 0 && balloon.GetComponent<Rigidbody2D>().velocity.x < 8f)
                    balloon.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 150);
            }

            else if (gameObject.tag.Equals("Regular Fan"))
            {
                if (transform.parent.localScale.x >= 0 && balloon.GetComponent<Rigidbody2D>().velocity.x < 8f)
                    balloon.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 300);

                else if (transform.parent.localScale.x < 0 && balloon.GetComponent<Rigidbody2D>().velocity.x < 8f)
                    balloon.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 300);
            }
            
            else if (gameObject.tag.Equals("Strong Fan"))
            {
                //print();
                if (transform.parent.localScale.x >= 0 && balloon.GetComponent<Rigidbody2D>().velocity.x < 12f)
                    balloon.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 450);

                else if (transform.parent.localScale.x < 0 && balloon.GetComponent<Rigidbody2D>().velocity.x < 12f)
                    balloon.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 450);

            }
            
        }
       
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Balloon"))
            inside = true;
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Balloon"))
            inside = false;
    }
}
