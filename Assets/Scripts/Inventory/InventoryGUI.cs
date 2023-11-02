using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGUI : MonoBehaviour
{
    [SerializeField] private List<InventorySlot> inventorySlots;

    public void UpdateInventorySlot(InventoryItem inventoryItem) 
    {
        for (var i = 0; i < inventorySlots.Count; i++) 
        {
            if (inventorySlots[i].ItemType.Equals(inventoryItem.itemData.itemType.type)) 
            {
                inventorySlots[i].UpdateItemAmount(inventoryItem);
            }
        }
    }
}
