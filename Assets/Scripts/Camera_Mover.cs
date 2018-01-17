using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Mover : MonoBehaviour {
   private bool hasInput;
    private Vector3 currentTouchPosition;
    private bool draggingItem;
    private Vector3 touchOffset;

    public float xmin, xmax, ymin, ymax;

    // Use this for initialization
    void Start () {
        hasInput = false;
        currentTouchPosition = Input.mousePosition;
        draggingItem = false;
    }

    // Update is called once per frame
    void Update() {
        currentTouchPosition = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
            move();
        else if (Input.GetMouseButtonUp(0))
            hasInput = false;

        if (hasInput)
            move();
        else
            draggingItem = false;
            
    }

    void move()
    {
        Vector3 RawinputPoint = Camera.main.ScreenToWorldPoint(currentTouchPosition);
        Vector3 inputPoint = new Vector3(RawinputPoint.x, RawinputPoint.y, transform.position.z);
        Vector3 mousePoint = new Vector3(currentTouchPosition.x, currentTouchPosition.y, transform.position.z);

        if (draggingItem)
        {
            transform.position = mousePoint + touchOffset;
            if (transform.position.x <= xmin)
                transform.position = new Vector3(xmin, transform.position.y, transform.position.z);
            if (transform.position.x >= xmax)
                transform.position = new Vector3(xmax, transform.position.y, transform.position.z);
            if (transform.position.y <= ymin)
                transform.position = new Vector3(transform.position.x, ymin, transform.position.z);
            if (transform.position.y >= ymax)
                transform.position = new Vector3(transform.position.x, ymax, transform.position.z);

        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(inputPoint, Vector2.zero, 0f);
            if (!hit)
            {
                hasInput = true;
                draggingItem = true;
                touchOffset = (Vector3)transform.position - mousePoint;
            }
            else
                hasInput = false;

        }
    }
}
