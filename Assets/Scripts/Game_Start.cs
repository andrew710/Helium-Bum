﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Start : MonoBehaviour {
    private Balloon_Script balloon;
    private Rigidbody2D rbody;
    private bool canAdd = true;
    public GameObject ui;
    public Text helium_text;
    public static int money;

    // Use this for initialization
    void Start () {
        ui = GameObject.FindGameObjectWithTag("UI");
        rbody = GameObject.FindGameObjectWithTag("Balloon").GetComponent<Rigidbody2D>();

        Time.timeScale = 0.0005f;
        Time.fixedDeltaTime = 0.00015f;
        Fan_Mover.canMove = true;
        
        ui.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
        if (canAdd)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Balloon_Script.helium += 0.5;
                helium_text.text = "helium: " + System.Math.Truncate(Balloon_Script.helium * 100) / 100;
            }

            if (Input.GetKey(KeyCode.Return))
            {
                ui.SetActive(false);
                Time.timeScale = 1;
                Time.fixedDeltaTime = 0.02f;
                rbody.gravityScale = (float)-0.5 * (float)(Balloon_Script.helium * 0.025);
                Fan_Mover.canMove = false;
                canAdd = false;
            }
        }
    }
}
