using UnityEngine;

public class PlayerExperience : MonoBehaviour
{
    [SerializeField]
    private int experienceToNextLevel = 5;

    private int currentExperience;
    private int currentLevel = 1;

    public int CurrentExperience => currentExperience;
    public int ExperienceToNextLevel => experienceToNextLevel;
    public int CurrentLevel => currentLevel;

    public void AddExperience(int amount)
    {
        currentExperience += amount;

        if (currentExperience >= experienceToNextLevel)
        {
            LevelUp();
        }

        Debug.Log($"XP: {currentExperience}/{experienceToNextLevel}");
    }

    private void LevelUp()
    {
        currentExperience -= experienceToNextLevel;

        currentLevel++;

        experienceToNextLevel += 3;

        LevelUpManager manager = FindAnyObjectByType<LevelUpManager>();

        if (manager != null)
        {
            manager.ShowLevelUp();
        }
    }
}