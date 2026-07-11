using UnityEngine;

public class EnemyContactDamage : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;

    [SerializeField]
    private float damageInterval = 1f;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Player"))
            return;

        if (timer < damageInterval)
            return;

        Health health = collision.GetComponent<Health>();

        if (health == null)
            return;

        health.TakeDamage(damage);

        Debug.Log($"Colidiu com: {collision.name}, dano: {damage}");

        timer = 0f;
    }
}