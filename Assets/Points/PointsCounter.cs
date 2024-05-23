using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PointsCounter : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    public static int currentPoints = 0;
    public GameObject completeScreen;

    void Start()
    {
        currentPoints = 0;
    }

    public void Update()
    {

        pointsText.text = "Points: " + currentPoints;
        if (currentPoints == 9)
        {
            StartCoroutine(levelcomplete());
        }
    }

    IEnumerator levelcomplete()
    {
        completeScreen.SetActive(true);
        WaitForSeconds wait = new WaitForSeconds(3);
        yield return wait;
        SceneManager.LoadScene("Level2");
        
    }
}
