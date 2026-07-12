using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField]
    private ExperiencePickup experiencePrefab;

    public void Die()
    {
        Instantiate(
            experiencePrefab,
            transform.position,
            Quaternion.identity);

        Destroy(gameObject);
    }
}