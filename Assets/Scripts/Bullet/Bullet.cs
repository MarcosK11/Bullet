using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 12f;

    [SerializeField]
    private float lifetime = 3f;

    private Rigidbody2D rigidbody2D;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Shoot(Vector2 direction)
    {
        rigidbody2D.linearVelocity = direction.normalized * speed;
    }
    private void DisableBullet()
    {
        Destroy(gameObject);
    }
    private void OnEnable()
    {
        Invoke(nameof(DisableBullet), lifetime);
    }


}