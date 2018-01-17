using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Fan_Mover : MonoBehaviour
{

    private bool hasInput;
    private Vector3 currentTouchPosition;
    private Vector3 startingPos;
    private Quaternion startingRot;
    private bool draggingItem;
    private Vector2 touchOffset;
    private bool inside = false;
    private int type;
    public GameObject rFan;
    public GameObject wFan;
    public GameObject sFan;
    public GameObject fanHolder;

    public Text curr;

    // Use this for initialization
    void Start()
    {
        hasInput = false;
        currentTouchPosition = Input.mousePosition;
        draggingItem = false;
        startingPos = transform.position;
        startingRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Balloon_Script.currency > 0)
        {
            currentTouchPosition = Input.mousePosition;
            if (Input.GetMouseButtonDown(0))
                drag_or_pickup();
            else if (Input.GetMouseButtonUp(0))
                hasInput = false;


            if (hasInput)
                drag_or_pickup();
            else
            {
                if (draggingItem)
                    drop_item();
            }
        }

    }

    void drag_or_pickup()
    {
        
        Vector3 RawinputPoint = Camera.main.ScreenToWorldPoint(currentTouchPosition);
        Vector2 inputPoint = new Vector2(RawinputPoint.x, RawinputPoint.y);
        if (draggingItem)
        {
                if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
                {
                    transform.localScale = new Vector3(transform.localScale.x*-1, transform.localScale.y, transform.localScale.z);
                }
                transform.position = inputPoint + touchOffset;
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(inputPoint, Vector2.zero);

            if (hit.collider != null && gameObject.GetComponent<Collider2D>() == hit.collider)
            {
                if (hit.collider.CompareTag("Regular Fan"))
                {
                    type = 2;
                }
                else if (hit.collider.CompareTag("Weaker Fan"))
                {
                    type = 1;
                }
                else if (hit.collider.CompareTag("Strong Fan"))
                {
                    type = 3;
                }

                hasInput = true;
                draggingItem = true;
                touchOffset = (Vector2)transform.position - inputPoint;
            }
            else
                hasInput = false;
            
        }
    }

    void drop_item()
    {
        draggingItem = false;
        if (inside)
        {
            Vector3 RawinputPoint = Camera.main.ScreenToWorldPoint(currentTouchPosition);
            Vector2 inputPoint = new Vector2(RawinputPoint.x, RawinputPoint.y);

            GameObject newFan = null;
            switch (type) {
                case 1: 
                    {
                        if (Balloon_Script.currency - 10 >= 0)
                        {
                            newFan = Instantiate(wFan, inputPoint, transform.rotation) as GameObject;
                            Balloon_Script.currency -= 10;
                            curr.text = Balloon_Script.currency + " coins";
                        }
                        break;
                    }
                case 2:
                    {
                        if (Balloon_Script.currency - 30 >= 0)
                        {
                            newFan = Instantiate(rFan, inputPoint, transform.rotation) as GameObject;
                            Balloon_Script.currency -= 30;
                            curr.text = Balloon_Script.currency + " coins";
                        }
                        break;
                    }
                case 3:
                    {
                        if (Balloon_Script.currency - 50 >= 0)
                        {
                            newFan = Instantiate(sFan, inputPoint, transform.rotation) as GameObject;
                            Balloon_Script.currency -= 50;
                            curr.text = Balloon_Script.currency + " coins";
                        }
                        break;
                    }
        }
            if (newFan != null)
            {
                newFan.transform.SetParent(fanHolder.GetComponent<Transform>());
                newFan.transform.localScale = transform.localScale;
            }
        }
        transform.position = startingPos;
        transform.rotation = startingRot;
        if (transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
            inside = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
            inside = false;
    }

}
