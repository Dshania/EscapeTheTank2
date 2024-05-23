using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRegen : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public RegenerativeHealth healthBar;
    public GameObject restart;

    public float healthRegenAmount;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        restart.SetActive(false);
    }

    private void Update()
    {
        if (currentHealth > maxHealth)
        {
            healthRegenAmount = 0f;
            currentHealth = 100f;
        }
        else if (currentHealth < maxHealth)
        {
            healthRegenAmount = 10f;
            currentHealth += healthRegenAmount * Time.deltaTime;
        }
        else if(currentHealth == 0f)
        {
            currentHealth = 0f;
            healthRegenAmount = 0f;
        }
    }
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            restart.SetActive(true);
            transform.parent.gameObject.SetActive(false);
            healthBar.SetHealth(0);
        }
    }
}
