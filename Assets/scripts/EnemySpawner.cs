using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int maxEnemies = 5;
    public float spawnRadius = 5f;
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 5f;

    private List<GameObject> enemies = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));

            if (enemies.Count < maxEnemies)
            {
                Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;
                GameObject enemy = Instantiate(enemyPrefab, transform.position + new Vector3(randomPosition.x, randomPosition.y, 0f), Quaternion.identity);
                enemies.Add(enemy);
                enemy.SetActive(true);
            }
        }
    }
}

