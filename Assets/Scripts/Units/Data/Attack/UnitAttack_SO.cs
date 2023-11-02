using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitAttack", menuName = "ScriptableObjects/Units/Attack", order = 3)]
public class UnitAttack_SO : ScriptableObject
{
    public int damage;
    public float range;
}

