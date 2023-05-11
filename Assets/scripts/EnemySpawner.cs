using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRadius = 1f;
    public float spawnDelay = 1f;
    public int maxEnemies = 10;
    public Rect spawnArea;

    private int numEnemies = 0;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);

            if (numEnemies < maxEnemies)
            {
                Vector2 spawnPosition = new Vector2(Random.Range(spawnArea.xMin, spawnArea.xMax), Random.Range(spawnArea.yMin, spawnArea.yMax));
                GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                numEnemies++;
                enemy.SetActive(true);
                AudioManager.Instance.PlaySFX("zombie_spawn");
            }
        }
    }

    public void OnEnemyDestroyed()
    {
        numEnemies--;
    }
}