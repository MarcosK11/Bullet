using UnityEngine;

public class Companion : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] protected float patrolRadius = 2.5f;
    [SerializeField] protected float idleDistance = 0.15f;
    [SerializeField] private float waitTime = 1f;
    [SerializeField] private float searchInterval = 0.25f;

    private float attackTimer;
    private float searchTimer;
    private float timer;
    private bool waiting;

    protected Transform player;
    protected CardData cardData;

    private Vector3 patrolPoint;
    private CompanionState state;
    private Transform target;

    public virtual void Initialize(Transform player, CardData cardData)
    {
        this.player = player;
        this.cardData = cardData;

        state = CompanionState.Patrol;
        ChooseNewPatrolPoint();
    }

    public enum CompanionState
    {
        Patrol,
        Chase
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
        switch (state)
        {
            case CompanionState.Patrol:
                searchTimer -= Time.deltaTime;

                if (searchTimer <= 0f)
                {
                    searchTimer = searchInterval;
                    FindTarget();
                }
                Patrol();
                break;

            case CompanionState.Chase:
                Chase();
                break;
        }
    }

    private void Patrol()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            patrolPoint,
            cardData.MoveSpeed * Time.deltaTime);

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
    private void FindTarget()
    {
        Enemy[] enemies = FindObjectsByType<Enemy>();

        float closestDistance = cardData.DetectionRadius;
        target = null;

        foreach (Enemy enemy in enemies)
        {
            float distance = Vector2.Distance(
                transform.position,
                enemy.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                target = enemy.transform;
            }
        }

        if (target != null)
        {
            state = CompanionState.Chase;
        }
    }
    private void Chase()
    {
        if (target == null)
        {
            state = CompanionState.Patrol;
            return;
        }

        float distance = Vector2.Distance(
            transform.position,
            target.position);

        if (distance > cardData.AttackRange)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                target.position,
                cardData.MoveSpeed * Time.deltaTime);
        }
        else
        {
            TryAttack();
        }
    }
private void TryAttack()
{
    attackTimer -= Time.deltaTime;

    if (attackTimer > 0f)
        return;

    Health health = target.GetComponent<Health>();

    if (health != null)
    {
        health.TakeDamage(cardData.Damage);
    }

    attackTimer = cardData.AttackCooldown;
}
}