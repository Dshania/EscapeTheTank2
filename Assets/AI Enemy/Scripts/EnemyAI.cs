using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private AIBehaviour shooting, patrolling;

    [SerializeField]
    private EnemyController tank;
    [SerializeField]
    private AIDetector detector;


    private void Awake()
    {
        detector = GetComponentInChildren<AIDetector>();
        tank = GetComponentInChildren<EnemyController>();
    }

    private void Update()
    {
        if (detector.TargetVisible)
        {
            shooting.PerformAction(tank, detector);
        }
        else
        {
            patrolling.PerformAction(tank, detector);
        }

/*        if (GetComponent<Health>().currentHealth == 0)
        {
            Destroy(gameObject);
        }*/
        if (GetComponent<EnemyHealth>().currentHealth == 0)
        {
            Destroy(gameObject);
        }
    }
}
