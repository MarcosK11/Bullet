using UnityEngine;

public class Companion : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] protected float moveSpeed = 3f;
    [SerializeField] protected float patrolRadius = 2.5f;
    [SerializeField] protected float idleDistance = 0.15f;
    [SerializeField] private float waitTime = 1f;
    [SerializeField] protected float detectionRadius = 6f;

    private float timer;
    private bool waiting;

    protected Transform player;

    private Vector3 patrolPoint;

    public virtual void Initialize(Transform player)
    {
        this.player = player;

        ChooseNewPatrolPoint();
    }

    private void Update()
    {
        if (player == null)
            return;
        if (waiting)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                waiting = false;
                ChooseNewPatrolPoint();
            }

            return;
        }
        Patrol();
    }

    private void Patrol()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            patrolPoint,
            moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, patrolPoint) <= idleDistance && !waiting)
        {
            waiting = true;
            timer = waitTime;
        }
    }

    private void ChooseNewPatrolPoint()
    {
        Vector2 randomOffset = Random.insideUnitCircle.normalized *
                               Random.Range(1f, patrolRadius);
        patrolPoint = player.position + new Vector3(
            randomOffset.x,
            randomOffset.y,
            0f);
    }
}