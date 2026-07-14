using UnityEngine;

public class LevelUpManager : MonoBehaviour
{
    [SerializeField]
    private GameObject levelUpPanel;

    private GameManager gameManager;

    [SerializeField]
    private CardData[] availableCards;

    [SerializeField]
    private CardUI[] cardUIs;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    public void ShowLevelUp()
    {
        Time.timeScale = 0f;

        gameManager.SetLevelingUp(true);

        levelUpPanel.SetActive(true);

        for (int i = 0; i < cardUIs.Length; i++)
        {
            cardUIs[i].Setup(availableCards[i]);
        }
    }

    public void CloseLevelUp()
    {
        levelUpPanel.SetActive(false);

        gameManager.SetLevelingUp(false);

        Time.timeScale = 1f;
    }

}