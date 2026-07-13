using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerExperienceUI : MonoBehaviour
{
    private PlayerExperience playerExperience;

    [Header("UI")]
    [SerializeField] private Slider experienceSlider;

    [Header("Animation")]
    [SerializeField] private float smoothSpeed = 8f;

    [SerializeField]
    private TMP_Text levelText;

    private float targetValue;

    private void Awake()
    {
        playerExperience = FindAnyObjectByType<PlayerExperience>();

        experienceSlider.value = 0f;
    }

    private void Update()
    {
        if (playerExperience == null)
            return;

        targetValue =
            (float)playerExperience.CurrentExperience /
            playerExperience.ExperienceToNextLevel;

        experienceSlider.value = Mathf.Lerp(
            experienceSlider.value,
            targetValue,
            Time.deltaTime * smoothSpeed);

        levelText.text = $"{playerExperience.CurrentLevel}";
    }
}