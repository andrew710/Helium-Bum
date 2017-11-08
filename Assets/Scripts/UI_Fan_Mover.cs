using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Fan_Mover : MonoBehaviour
{

    private bool hasInput;
    private Vector3 currentTouchPosition;
    private Vector3 startingPos;
    private bool draggingItem;
    private Vector2 touchOffset;
    public GameObject fan;
    public GameObject fanHolder;

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
        GameObject newFan = Instantiate(fan, inputPoint, transform.rotation) as GameObject;
        newFan.transform.SetParent(fanHolder.GetComponent<Transform>());
        transform.position = startingPos;
    }

}
