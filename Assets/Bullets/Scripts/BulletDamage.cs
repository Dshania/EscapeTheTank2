using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Enemy")
        {
           collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(1);
        }

        if (collision.collider.gameObject.tag == "Player")
        {
         //   collision.gameObject.GetComponent<Health>().TakeDamage(1);
            collision.gameObject.GetComponent<HealthRegen>().TakeDamage(1); 
            collision.gameObject.GetComponent<HealthLives>().TakeDamage(1);
        }

    }
}
