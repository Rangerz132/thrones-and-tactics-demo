using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuildingType
{
    Army,
    Defense,
    Upgrade,
    Ressource,
    None
}

[CreateAssetMenu(fileName = "BuildingType", menuName = "ScriptableObjects/Buildings/Type", order = 2)]
public class BuildingType_SO : ScriptableObject
{
    public BuildingType buildingType;
    public Sprite icon;
}
