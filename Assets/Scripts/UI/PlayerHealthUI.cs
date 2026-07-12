using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    private PlayerHealth playerHealth;

    [Header("UI")]
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Image fillImage;

    [Header("Animation")]
    [SerializeField] private float smoothSpeed = 8f;

    [Header("Colors")]
    [SerializeField] private Color fullHealthColor = new Color32(255, 0, 0, 255);
    [SerializeField] private Color lowHealthColor = new Color32(84, 20, 20, 255);

    private float targetValue;

    private void Awake()
    {
        playerHealth = FindAnyObjectByType<PlayerHealth>();

        targetValue = 1f;
        healthSlider.value = 1f;
    }

    private void Update()
    {
        if (playerHealth == null)
            return;

        targetValue = (float)playerHealth.CurrentHealth / playerHealth.MaxHealth;

        healthSlider.value = Mathf.Lerp(
            healthSlider.value,
            targetValue,
            Time.deltaTime * smoothSpeed);

        fillImage.color = Color.Lerp(
            lowHealthColor,
            fullHealthColor,
            healthSlider.value);
    }
}