using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Image artworkImage;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private TMP_Text rarityText;

    private CardData cardData;

    public CardData CardData => cardData;

    public void Setup(CardData data)
    {
        cardData = data;

        artworkImage.sprite = data.artwork;

        nameText.text = data.cardName;

        descriptionText.text = data.description;

        rarityText.text = data.rarity.ToString();
    }

    public void Select()
    {
        LevelUpManager manager = FindAnyObjectByType<LevelUpManager>();

        if (manager != null)
        {
            manager.ChooseCard(this);
        }
    }
}