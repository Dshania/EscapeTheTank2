using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;

public class CountdownTimer : MonoBehaviour
{
    public float currentTime ;
    public float startingTime;

    public TextMeshProUGUI countdownTXT;
    public GameObject countdowScreen;
    public GameObject player;
    public GameObject otherStuff2;
    public GameObject otherStuff;

    public GameObject paused;
   // public GameObject player;

    void Start()
    {
        currentTime = startingTime;
        countdowScreen.SetActive(true);
        otherStuff.SetActive(false);
        player.SetActive(false);
        otherStuff2.SetActive(false);
        Time.timeScale = 1.0f;
    }

    
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownTXT.text = currentTime.ToString("0");

        if(currentTime <= 3.5)
        {
            countdownTXT.color = Color.red;
        }

        if(currentTime <= 0)
        {
            currentTime = 0;
            countdowScreen.SetActive(false);
            otherStuff.SetActive(true);
            player.SetActive(true);
            otherStuff2.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused.SetActive(true);
            Time.timeScale = 0f;
        }

    }
}
