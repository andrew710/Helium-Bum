using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_Poppers : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Balloon"))
        {
            Destroy(collision.gameObject);
        }
    }
}
