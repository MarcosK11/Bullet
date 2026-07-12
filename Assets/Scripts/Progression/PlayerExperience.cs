using UnityEngine;

public class PlayerExperience : MonoBehaviour
{
    private int currentExperience;

    public void AddExperience(int amount)
    {
        currentExperience += amount;

        Debug.Log($"XP: {currentExperience}");
    }
}