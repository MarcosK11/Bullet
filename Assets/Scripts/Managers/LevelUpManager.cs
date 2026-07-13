using UnityEngine;

public class LevelUpManager : MonoBehaviour
{
    [SerializeField]
    private GameObject levelUpPanel;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    public void ShowLevelUp()
    {
        Time.timeScale = 0f;

        gameManager.SetLevelingUp(true);

        levelUpPanel.SetActive(true);
    }

    public void CloseLevelUp()
    {
        levelUpPanel.SetActive(false);

        gameManager.SetLevelingUp(false);

        Time.timeScale = 1f;
    }

}