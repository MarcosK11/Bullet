using UnityEngine;

public class LevelUpManager : MonoBehaviour
{
    [SerializeField]
    private GameObject levelUpPanel;

    public void ShowLevelUp()
    {
        Time.timeScale = 0f;

        levelUpPanel.SetActive(true);
    }

    public void CloseLevelUp()
    {
        levelUpPanel.SetActive(false);

        Time.timeScale = 1f;
    }
}