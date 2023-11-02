using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "ScriptableObjects/Items/Item", order = 1)]
public class ItemData_SO : ScriptableObject
{
    public string id;
    public string itemName;
    [TextArea(4, 8)] public string description;
    public int amount;
    public Sprite icon;
    public ItemType_SO itemType;
}