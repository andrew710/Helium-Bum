﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan_Mover : MonoBehaviour
{

    private bool hasInput;
    private Vector3 currentTouchPosition;
    private bool draggingItem;
    private Vector2 touchOffset;
    private Vector3 currPosition;
    private bool inside;
    public static bool canMove = true;

    // Use this for initialization
    void Start()
    {
        hasInput = false;
        currentTouchPosition = Input.mousePosition;
        draggingItem = false;
        currPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
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
            transform.position = inputPoint + touchOffset;
            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
        }
        else
        {
            int layermask = 1 << 8;
            layermask = ~layermask;
            RaycastHit2D hit = Physics2D.Raycast(inputPoint, Vector2.zero, 0f, layermask);
            if (hit.collider != null && GetComponent<Collider2D>() == hit.collider)
            {
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
        if (!inside)
        {
            transform.position = currPosition;
        }
        else
        {
            currPosition = transform.position;
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
