using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan_Script : MonoBehaviour {
    public bool inside = false;
    private Vector2 position;
    private GameObject balloon;

	// Use this for initialization
	void Start () {
        balloon = GameObject.FindGameObjectWithTag("Balloon");
        position = new Vector2(-(transform.position.x), transform.position.y);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (inside)
        {
            if (gameObject.tag.Equals("Weaker Fan"))
            {
                if (transform.eulerAngles == new Vector3(0, 0, 0) && balloon.GetComponent<Rigidbody2D>().velocity.x < 8f)
                    balloon.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 60);

                else if (transform.eulerAngles == new Vector3(0, 0, 180f) || transform.eulerAngles == new Vector3(0, 0, -180f))
                    balloon.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 60);
            }

            else if (gameObject.tag.Equals("Regular Fan"))
            {
                if (transform.eulerAngles == new Vector3(0, 0, 0) && balloon.GetComponent<Rigidbody2D>().velocity.x < 8f)
                    balloon.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 100);

                else if (transform.eulerAngles == new Vector3(0, 0, 180f) || transform.eulerAngles == new Vector3(0, 0, -180f))
                    balloon.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 100);
            }
            
            else if (gameObject.tag.Equals("Strong Fan"))
            {
                if (transform.eulerAngles == new Vector3(0, 0, 0) && balloon.GetComponent<Rigidbody2D>().velocity.x < 12f)
                    balloon.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 150);

                else if (transform.eulerAngles == new Vector3(0, 0, 180f) || transform.eulerAngles == new Vector3(0, 0, -180f))
                    balloon.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 150);

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
