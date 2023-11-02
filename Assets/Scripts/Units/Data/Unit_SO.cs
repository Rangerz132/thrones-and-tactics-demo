using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Unit", menuName = "ScriptableObjects/Units/Unit", order = 1)]
public class Unit_SO : ScriptableObject
{
    public UnitType_SO unitType;
    public UnitAttack_SO unitAttack;
    public string unitName;
    public string description;
    public int health;
}
