using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Fan_Mover : MonoBehaviour
{

    private bool hasInput;
    private Vector3 currentTouchPosition;
    private Vector3 startingPos;
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
    }

    // Update is called once per frame
    void Update()
    {
        currentTouchPosition = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
            hasInput = true;
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

    void drag_or_pickup()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (transform.eulerAngles.z + 180 > 180)
                transform.Rotate(new Vector3(0, 0, -180));
            else
                transform.Rotate(new Vector3(0, 0, 180));
        }

        Vector3 RawinputPoint = Camera.main.ScreenToWorldPoint(currentTouchPosition);
        Vector2 inputPoint = new Vector2(RawinputPoint.x, RawinputPoint.y);
        if (draggingItem)
        {
            transform.position = inputPoint + touchOffset;
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(inputPoint, Vector2.zero);
            if (hit.collider != null && GetComponent<Collider2D>() == hit.collider)
            {
                print(hit.collider.tag);
                if(hit.collider.CompareTag("Regular Fan"))
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

                draggingItem = true;
                touchOffset = (Vector2)transform.position - inputPoint;
            }
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
            if (type == 1)
            {
                newFan = Instantiate(wFan, inputPoint, transform.rotation) as GameObject;
                Balloon_Script.currency -= 10;
                curr.text = Balloon_Script.currency + " coins";
            }
            else if (type == 2)
            {
                newFan = Instantiate(rFan, inputPoint, transform.rotation) as GameObject;
                Balloon_Script.currency -= 25;
                curr.text = Balloon_Script.currency + " coins";
            }
            else if (type == 3)
            {
                newFan = Instantiate(sFan, inputPoint, transform.rotation) as GameObject;
                Balloon_Script.currency -= 50;
                curr.text = Balloon_Script.currency + " coins";
            }

            newFan.transform.SetParent(fanHolder.GetComponent<Transform>());
        }
        transform.position = startingPos;
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
