using UnityEngine;

public class ExperiencePickup : MonoBehaviour
{
    [SerializeField]
    private int experienceValue = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerExperience playerExperience = collision.GetComponent<PlayerExperience>();

        if (playerExperience == null)
            return;

        playerExperience.AddExperience(experienceValue);

        Destroy(gameObject);
    }
}