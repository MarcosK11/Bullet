using UnityEngine;
using System.Collections;
public class Health : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 3;

    private int currentHealth;

    public int CurrentHealth => currentHealth;

    public int MaxHealth => maxHealth;

    protected virtual void Awake()
    {
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(int damage)
    {
        if (damage <= 0)
            return;

        currentHealth -= damage;

        Debug.Log($"{gameObject.name} HP: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}