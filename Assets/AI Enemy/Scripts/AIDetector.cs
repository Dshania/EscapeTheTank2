using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AIDetector : MonoBehaviour
{
    [Range(1, 15)]
    [SerializeField]
    private float viewRadius = 11;
    [SerializeField]
    private float detectionCheckDelay = 0.1f;
    [SerializeField]
    private Transform target = null;
    [SerializeField]
    private LayerMask playerLayerMask;
    [SerializeField]
    private LayerMask visiablityLayer;
 
    [field : SerializeField]
    public bool TargetVisible { get; private set; }

    public Transform Target
    { 
          get => target;
          set
          {
             target = value;
             TargetVisible = false;
          }
    }

    public float feildOfVisionForShooting = 60;
    public List<Transform> turretBarrels;
    public GameObject bulletPrefab;
    /*  private Collider2D[] tankColliders;
      private float currentDelay = 0;
      public float reloadDelay = 1;*/

    public EnemyController tank;

    private void Start()
    {
        StartCoroutine(Detection());
    }

    private void Update()
    {
        if (Target != null)
            TargetVisible = CheckTargetVisible();

        if (TargetVisible == true)
        {
            tank.HandleShoot();
        }
 /*       if (TargetVisible == true)
        {
            currentDelay -= Time.deltaTime;
            if (currentDelay <= 0)
            {
                foreach (var barrel in turretBarrels)
                {
                    GameObject bullet = Instantiate(bulletPrefab);
                    bullet.transform.position = barrel.position;

                    bullet.transform.localRotation = barrel.rotation;
                    bullet.GetComponent<Bullet>().Initialize();

                    foreach (var collider in tankColliders)
                    {
                        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), collider);
                    }
                }
            }
            currentDelay = reloadDelay;
        }*/
    }

    private bool CheckTargetVisible()
    {
        var result = Physics2D.Raycast(transform.position, Target.position - transform.position, viewRadius, visiablityLayer);
        if (result.collider != null)
        {
            return (playerLayerMask & (1 << result.collider.gameObject.layer)) != 0;
        }
        return false;
    }

    private void DetectTarget()
    {
        if (Target == null)
            CheckIfPlayerInRange();
        else if (Target != null)
            DetectIfOutOfRange();   
    }

    private void DetectIfOutOfRange()
    {
        if (Target == null || Target.gameObject.activeSelf ==false || Vector2.Distance(transform.position, Target.position) > viewRadius)
        {
            Target = null;
        }
    }

    private void CheckIfPlayerInRange()
    {
        Collider2D collision = Physics2D.OverlapCircle(transform.position, viewRadius, playerLayerMask);
        if (collision != null)
        {
            Target = collision.transform;
        }
    }

    IEnumerator Detection()
    {
        yield return new WaitForSeconds(detectionCheckDelay);
        DetectTarget();
        StartCoroutine(Detection());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, viewRadius);
    }
}
