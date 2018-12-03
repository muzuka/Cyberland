using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour 
{
    public GameObject menu;
    public Text title;

    public static GameController instance;

	// Use this for initialization
	void Start () 
    {
        Time.timeScale = 1f;
        instance = this;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (menu.activeSelf)
            {
                CloseMenu();
            }
            else {
                OpenMenu("Paused");
            }
        }
	}

    public void OpenMenu (string message)
    {
        Time.timeScale = 0f;
        menu.SetActive(true);
        title.text = message;
    }

    public void CloseMenu()
    {
        Time.timeScale = 1f;
        menu.SetActive(false);
    }

    public void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit ()
    {
        Application.Quit();
    }
}
