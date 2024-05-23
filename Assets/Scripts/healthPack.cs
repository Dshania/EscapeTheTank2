using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class healthPack : MonoBehaviour
{
    public HealthLives hp;
 //   public GameObject player;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player" && hp.currentHealth < 10)
        {
            col.gameObject.GetComponent<HealthLives>().TakeDamage(-1);
            Destroy(gameObject);
            print(" HP collided with obj");
        }
    }

    private void Update()
    {
/*        if (player.GetComponent<HealthLives>().currentHealth == 10)
        {
            GetComponent<Collider2D>().enabled = false;
        }
        if (player.GetComponent<HealthLives>().currentHealth == 10)
        {
            GetComponent<Collider2D>().enabled = true;
        }
*/
       if (hp.currentHealth == 10)
       {
            GetComponent<Collider2D>().enabled = false;
       }    
       else if (hp.currentHealth < 10)
       {
            GetComponent<Collider2D>().enabled = true;
       }

    }
}

