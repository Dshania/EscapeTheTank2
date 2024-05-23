using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeLeft = 0;
    public bool timeCounting = true;
    public TextMeshProUGUI timeText;

    public GameObject player;
    public GameObject finished;
    void Start()
    {
        timeCounting = true;
      //  Instantiate(player);
     // DontDestroyOnLoad(player);
    }

    void Update()
    {
        if (timeCounting == true)
        {
            if(timeLeft >= 0)
            {
                timeLeft += Time.deltaTime;
                DisplayTime(timeLeft);
            }
        }
        else if (timeCounting == false)
        {
            StopTime();
            timeLeft += 0;
            DisplayTime(timeLeft);
        }

        if(!player.activeSelf || finished.activeSelf)
        {
            timeCounting = false;
        }

    }

    void DisplayTime (float timeToShow) 
    {
        timeToShow += 1;
        float minutes = Mathf.FloorToInt(timeToShow / 60);
        float seconds = Mathf.FloorToInt(timeToShow % 60);
        timeText.text = string.Format("{00:00} : {01:00}", minutes, seconds);

        /*if (finished.activeSelf)
        {
            Time.timeScale = 0; 
        }
*/
    }

    void StopTime()
    {
        if (!player.activeSelf)
        {
            timeCounting = false;          
        }
    }
}
