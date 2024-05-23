using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class points : MonoBehaviour
{
    public int value;
    public AudioSource source;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            source.Play();
            PointsCounter.currentPoints += value;
            PC2.currentPoints += value;
            PCa.currentPoints += value;
            PCb.currentPoints += value;
            GameWon.currentPoints += value;
            Destroy(gameObject);
            print("collided with obj");
        }
    }
}
