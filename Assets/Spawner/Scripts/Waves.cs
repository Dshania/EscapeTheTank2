using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "ScriptableObject/Waves", order = 1)]
public class Waves : ScriptableObject
{
    [field: SerializeField]

    public GameObject[] EnemiesInWave { get; private set; }
    [field: SerializeField]

    public float TimeBeforeWave { get; private set; }

    [field: SerializeField]
    public float NumberToSpawn { get; private set; }
}
