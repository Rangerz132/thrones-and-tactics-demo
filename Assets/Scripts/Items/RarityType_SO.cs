using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RarityType
{
    Commun,
    Uncommun,
    Rare,
    Epic,
    Legendary
}

[CreateAssetMenu(fileName = "Rarity", menuName = "ScriptableObjects/Items/Rarity", order = 1)]
public class RarityType_SO : ScriptableObject
{
    public RarityType rarity;
    public Color color;
}