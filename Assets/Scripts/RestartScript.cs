using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI FinaltimeText;

    private void Update()
    {
        FinaltimeText.text = timeText.text;
      //  Time.timeScale = 0f;
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
