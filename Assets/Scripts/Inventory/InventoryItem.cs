using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem
{
    public ItemData_SO itemData;
    public int StackAmount { get; private set; }

    public InventoryItem(ItemData_SO itemData)
    {
        this.itemData = itemData;
    }

    /// <summary>
    /// Add certain amount of this specific item
    /// </summary>
    /// <param name="amount"></param>
    public void AddStack(int amount)
    {
        StackAmount += amount;
    }

    /// <summary>
    /// Remove certain amount of this specific item
    /// </summary>
    /// <param name="amount"></param>
    public void RemoveStack(int amount)
    {
        StackAmount -= amount;
    }

    /// <summary>
    /// Clear amount of this specific item
    /// </summary>
    public void ClearStack()
    {
        StackAmount = 0;
    }
}