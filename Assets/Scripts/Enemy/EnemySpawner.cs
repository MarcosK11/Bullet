using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private EnemyMovement enemyPrefab;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private float spawnRadius = 10f;

    [SerializeField]
    private float spawnInterval = 2f;

    [SerializeField]
    private int maxEnemies = 20;

    private int currentEnemies;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }
    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            int enemyCount = FindObjectsByType<EnemyMovement>().Length;

            if (enemyCount < maxEnemies)
            {
                SpawnEnemy();
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }
    private void SpawnEnemy()
    {
        Vector2 spawnDirection = Random.insideUnitCircle.normalized;

        Vector2 spawnPosition =
            (Vector2)transform.position + spawnDirection * spawnRadius;

        EnemyMovement enemy = Instantiate(
            enemyPrefab,
            spawnPosition,
            Quaternion.identity
        );

        enemy.Initialize(player);
    }

    public void NotifyEnemyDestroyed()
    {
        currentEnemies--;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}