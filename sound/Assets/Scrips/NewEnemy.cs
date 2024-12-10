using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform enemySpawn;
    private float spawnTime = 3f;

    public void SpawnEnemys()
    {
        Invoke(nameof(SpawnEnemy), spawnTime);
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab,enemySpawn);
    }
}
