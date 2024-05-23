using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWon : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    public static int currentPoints = 0;
    public GameObject gameWon;

    void Start()
    {
        Time.timeScale = 1f;
        currentPoints = 0;
    }

    public void Update()
    {
        pointsText.text = "Points: " + currentPoints;
        if (currentPoints == 9)
        {
            gameWon.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
