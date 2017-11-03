using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_Fan : MonoBehaviour {

    public GameObject fan;

public void createFan(Vector2 position,  Quaternion rotation)
    {
        Instantiate(fan, position, rotation);
    }
}
