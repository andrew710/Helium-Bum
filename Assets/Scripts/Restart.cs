using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart: MonoBehaviour {
    public void Restarter()
    {
        Balloon_Script.currency = 100;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
