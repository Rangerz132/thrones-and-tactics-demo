using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI stackAmountText;
    [field: SerializeField] public ItemType ItemType { get; private set; }

    public void UpdateItemAmount(InventoryItem inventoryItem)
    {
        stackAmountText.text = inventoryItem.StackAmount.ToString();
    }
}
