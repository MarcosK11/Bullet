using System.Collections.Generic;
using UnityEngine;

public class PlayerCompanionManager : MonoBehaviour
{
    private readonly List<CardData> companions = new();

    public void AddCompanion(CardData card)
    {
        companions.Add(card);
    }
}