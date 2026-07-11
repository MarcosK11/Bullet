using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;

    private Rigidbody2D rigidbody2D;
    private Transform target;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Initialize(Transform target)
    {
        this.target = target;
    }

    private void FixedUpdate()
    {
        if (target == null)
            return;

        Vector2 direction = (target.position - transform.position).normalized;

        rigidbody2D.linearVelocity = direction * speed;
    }
}