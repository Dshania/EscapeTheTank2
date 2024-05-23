using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthLives : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    public Image[] lives;

    public Sprite emptyHealth;
    public Sprite fullHealth; 
    public GameObject restart;
  //  public GameObject healthpack;
    void Start()
    {
        currentHealth = maxHealth;
        restart.SetActive(false);

    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
     //   Debug.Log(currentHealth);

        foreach (Image item in lives)
        {
            item.sprite = emptyHealth;
        }
        for (int i = 0; i < currentHealth; i++)
        {
            lives[i].sprite = fullHealth;
        }


        if (currentHealth <= 0)
        {
            restart.SetActive(true);
            transform.parent.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = 10;
        }
    }
}
