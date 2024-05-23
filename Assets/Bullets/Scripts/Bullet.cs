using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10;
    public int damage;
    public float maxDistance = 10;
   // private int direction = 1;

    private Vector2 startPosition;
    private float conDistance = 0;
    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void Initialize()
    {
        startPosition = transform.position;
        rb2d.velocity = transform.up * speed;
    }

    private void Update()
    {
        conDistance = Vector2.Distance(transform.position, startPosition);
        if (conDistance > maxDistance)
        {
            DisableObject();
        }

    }

    private void DisableObject()
    {
       rb2d.velocity = Vector2.zero;
       gameObject.SetActive(false);
       Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        var layerMask = collision.gameObject.layer;
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyHealth>().TakeDamage(damage);
        }

        if (collision.tag == "Player" && collision.GetComponent<HealthRegen>())
        {
            collision.GetComponent<HealthRegen>().TakeDamage(damage);
        }
        if (collision.tag == "Player" && collision.GetComponent<HealthLives>())
        {
            collision.GetComponent<HealthLives>().TakeDamage(damage);
        }


        Debug.Log("collided" + collision.name);

        if(collision.tag == "Wall")
        {
            rb2d.velocity = transform.up * speed * -1;
        }
        else
        {
            DisableObject();
        }

    }
}
