using System.Collections;
using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField]
    private float invulnerabilityTime = 0.5f;

    private bool isInvulnerable;

    public override void TakeDamage(int damage)
    {
        if (isInvulnerable)
            return;

        base.TakeDamage(damage);

        StartCoroutine(InvulnerabilityRoutine());
    }

    private IEnumerator InvulnerabilityRoutine()
    {
        isInvulnerable = true;

        yield return new WaitForSeconds(invulnerabilityTime);

        isInvulnerable = false;
    }

    protected override void Die()
    {
        FindAnyObjectByType<GameManager>().GameOver();
    }
}