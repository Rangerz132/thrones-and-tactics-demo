using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Building", menuName = "ScriptableObjects/Buildings/Building", order = 1)]
public class Building_SO : ScriptableObject
{
    public BuildingType_SO buildingType;
    public BuildingConstruction_SO buildingConstruction;
    public string buildingName;
    public string description;
    public Sprite icon;
    public int health;
    public Vector2 size;
}
