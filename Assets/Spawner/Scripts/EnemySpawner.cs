using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    public float spawnRate;

    public GameObject hp;
   // public float radius;

    public Vector3 centre;
    public Vector3 size;
   
    public bool canSpawn = true;
    void Start()
    {
      // StartCoroutine(Spawner());
      canSpawn = true;
       
    }

    private void Update()
    {
        Spawn();
    }

    private IEnumerator Spawnertimer()
    {
        canSpawn = false;
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
            yield return wait;
        canSpawn = true;

    }

    void Spawn()
    {
        if (canSpawn)
        {
            Vector3 randomPos = centre + new Vector3(Random.Range(-size.x, size.x), Random.Range(-size.y, size.y), 0);
            Instantiate(hp, randomPos, Quaternion.identity);
            StartCoroutine(Spawnertimer());
        }

    }

/*    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, radius);
    }*/

}
