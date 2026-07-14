using UnityEngine;

[CreateAssetMenu(menuName = "Cards/Card")]
public class CardData : ScriptableObject
{
    public CompanionId companionId;

    [Header("Info")]
    public string cardName;

    [TextArea]
    public string description;

    public Sprite artwork;

    public CardType type;

    public CardRarity rarity;

    public GameObject prefab;
}