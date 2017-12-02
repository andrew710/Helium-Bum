using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trashcan : MonoBehaviour {
    public Text curr;

    public void Start()
    {
        curr.text = Balloon_Script.currency + " coins";
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Regular Fan"))
        {
            Destroy(collision.gameObject);
            Balloon_Script.currency += 25;
            curr.text = Balloon_Script.currency + " coins";
        }
        else if(collision.gameObject.CompareTag("Weak Fan"))
        {
            Destroy(collision.gameObject);
            Balloon_Script.currency += 25;
            curr.text = Balloon_Script.currency + " coins";
        }
        else if(collision.gameObject.CompareTag("Strong Fan"))
        {
            Destroy(collision.gameObject);
            Balloon_Script.currency += 50;
            curr.text = Balloon_Script.currency + " coins";
        }
    }
}
