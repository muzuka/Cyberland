using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public GameObject mainMenu;
    public GameObject loadoutMenu;

    private void Start()
    {
        SelectedGuns.clearGuns();
    }

    public void ToLoadout ()
    {
        mainMenu.SetActive(false);
        loadoutMenu.SetActive(true);
    }

    public void Back ()
    {
        mainMenu.SetActive(true);
        loadoutMenu.SetActive(false);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void Quit ()
    {
        Application.Quit();
    }
}
