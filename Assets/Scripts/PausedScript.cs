using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedScript : MonoBehaviour
{
    public GameObject paused;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused.SetActive(false);
            Time.timeScale = 1.0f;
        }

    }
    public void RestartBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
