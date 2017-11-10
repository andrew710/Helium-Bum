using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashcan : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Regular Fan"))
        {
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.CompareTag("Weak Fan"))
        {
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.CompareTag("Strong Fan"))
        {
            Destroy(collision.gameObject);
        }
    }
}
