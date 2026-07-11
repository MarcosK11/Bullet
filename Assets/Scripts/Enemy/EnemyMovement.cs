using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;

    [SerializeField]
    private float stopDistance = 0.6f;

    private Rigidbody2D rigidbody2D;

    private Transform target;

    public void Initialize(Transform target)
    {
        this.target = target;
    }
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Initialize(target);
    }

    private void FixedUpdate()
    {
        if (target == null)
            return;

        Vector2 direction = target.position - transform.position;

        float distance = direction.magnitude;

        if (distance <= stopDistance)
        {
            rigidbody2D.linearVelocity = Vector2.zero;
            return;
        }

        rigidbody2D.linearVelocity = direction.normalized * speed;
    }
}