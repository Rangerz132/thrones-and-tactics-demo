using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitType
{
    Villager,
    OneHanded,
    TwoHanded,
    Archer,
    Mage, 
}

[CreateAssetMenu(fileName = "UnitType", menuName = "ScriptableObjects/Units/Type", order = 2)]
public class UnitType_SO : ScriptableObject
{
    public UnitType unitType;
    public Sprite icon;
}

