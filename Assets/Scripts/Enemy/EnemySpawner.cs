using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private EnemyMovement enemyPrefab;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private float spawnRadius = 10f;

    private void Start()
    {
        SpawnEnemy();
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}