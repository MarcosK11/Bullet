using System.Collections.Generic;
using UnityEngine;

public class PlayerCompanionManager : MonoBehaviour
{
    private readonly List<Companion> companions = new();
    public IReadOnlyList<Companion> Companions => companions;

    [SerializeField]
    private int maxCompanions = 6;

    public bool AddCompanion(CardData cardData)
    {
        if (companions.Count >= maxCompanions)
        {
            Debug.Log("Limite de companheiros atingido.");
            return false;
        }

        if (cardData.prefab == null)
        {
            Debug.LogWarning($"{cardData.cardName} não possui prefab.");
            return false;
        }

        GameObject companionObject = Instantiate(
            cardData.prefab,
            transform.position,
            Quaternion.identity);

        Companion companion = companionObject.GetComponent<Companion>();

        if (companion == null)
        {
            Debug.LogError($"{cardData.prefab.name} não possui o script Companion.");
            Destroy(companionObject);
            return false;
        }

        companion.Initialize(transform);

        companions.Add(companion);

        return true;
    }
}