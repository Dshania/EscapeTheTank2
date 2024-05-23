using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public PlayerHealthbar healthBar;
    public GameObject restart;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        restart.SetActive(false);
      //  DontDestroyOnLoad(gameObject);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            restart.SetActive(true);
            transform.parent.gameObject.SetActive(false);
         // Destroy(transform.parent.gameObject);
        }
    }

}
