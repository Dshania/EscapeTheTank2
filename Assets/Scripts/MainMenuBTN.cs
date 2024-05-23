using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBTN : MonoBehaviour
{
    public GameObject settings;
    public GameObject menu;

    private void Start()
    {
        Time.timeScale = 1.0f;
    }

    public void game1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void gameA()
    {
        SceneManager.LoadScene("LevelA");
    }

    public void Settings()
    {
        settings.SetActive(true);
        menu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
