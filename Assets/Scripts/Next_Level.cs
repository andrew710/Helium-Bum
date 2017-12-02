using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next_Level : MonoBehaviour {

    private static int level = 0;
    public GameObject win;

    void Start()
    {
        win.SetActive(false);
        switch (level)
        {
            case 0:
                Balloon_Script.currency = 100;
                break;

            case 1:
                Balloon_Script.currency = 100;
                break;

            case 2:
                Balloon_Script.currency = 100;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Balloon"))
        {
            level++;
            Time.timeScale = 0;
            win.SetActive(true);

        }
    }

    public void nextLevel()
    {
        win.SetActive(false);
        SceneManager.LoadScene("level " + level);
    }
}
