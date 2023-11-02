using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType
{
    Consummables,
    Ores,
    Woods,
    Gold
}

[CreateAssetMenu(fileName = "ItemTypes", menuName = "ScriptableObjects/Items/Type", order = 1)]
public class ItemType_SO : ScriptableObject
{
    public ItemType type;
    public Sprite icon;
}

