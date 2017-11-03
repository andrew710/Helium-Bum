using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan_Moving : MonoBehaviour
{

    private bool hasInput;
    private Vector3 currentTouchPosition;
    private bool draggingItem;
    private Vector2 touchOffset;
    public static bool moveable;
    public Create_Fan fan;

    // Use this for initialization
    void Start()
    {
        currentTouchPosition = Input.mousePosition;
        draggingItem = false;
        moveable = true;
    }

    // Update is called once per frame
    void Update()
    {
        currentTouchPosition = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
            drag_or_pickup();

        if (draggingItem)
            drop_item();
    }

    void drag_or_pickup()
    {
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
                draggingItem = true;
                touchOffset = (Vector2)transform.position - inputPoint;
            }
        }
    }

    void drop_item()
    {
        Vector3 RawinputPoint = Camera.main.ScreenToWorldPoint(currentTouchPosition);
        Vector2 inputPoint = new Vector2(RawinputPoint.x, RawinputPoint.y);
        draggingItem = false;
        fan.GetComponent<Create_Fan>().createFan(inputPoint, transform.rotation);
    }
}
