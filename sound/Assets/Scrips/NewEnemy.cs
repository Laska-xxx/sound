using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform enemySpawn;
    private float spawnTime = 5f;
    private bool create = true;

    private void Update()
    {
        if (create)
        {
            GameObject enemy = Instantiate(enemyPrefab, enemySpawn);
            StartCoroutine(KDBetweenSpawns());

        }
    }

    private IEnumerator KDBetweenSpawns()
    {
        create = false;
        yield return new WaitForSeconds(spawnTime);
        create = true;
    }
}
