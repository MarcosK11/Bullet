using UnityEngine;

[CreateAssetMenu(menuName = "Cards/Card")]
public class CardData : ScriptableObject
{
    public CompanionId companionId;

    [Header("Visual")]
    public Sprite artwork;

    [Header("Gameplay")]
    [SerializeField] private GameObject prefab;
    [SerializeField] private int damage;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float attackRange;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float detectionRadius;

    [Header("Info")]
    [SerializeField] public string cardName;
    [SerializeField] private CardRarity rarity;
    [SerializeField] private CardType type;
    [SerializeField] private string description;

    public GameObject Prefab => prefab;
    public int Damage => damage;
    public float AttackCooldown => attackCooldown;
    public float AttackRange => attackRange;
    public float MoveSpeed => moveSpeed;
    public float DetectionRadius => detectionRadius;

    public CardType Type => type;
    public CardRarity Rarity => rarity;
    public string Description => description;
}