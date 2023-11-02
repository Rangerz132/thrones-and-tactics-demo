using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private List<InventoryItem> inventory = new List<InventoryItem>();
    [SerializeField] private List<ItemData_SO> itemDatas;
    [SerializeField] private InventoryGUI inventoryGUI;

    private void Start()
    {
        CreateInventoryList();
    }

    public void OnEnable()
    {
        EventManager.StartListening("OnCollectItems", OnAddItems);
    }

    public void OnDisable()
    {
        EventManager.StopListening("OnCollectItems", OnAddItems);
    }

    void OnAddItems(Dictionary<string, object> message)
    {
        List<InventoryItem> inventory = (List<InventoryItem>)message["inventory"];
        AddItems(inventory);
    }

    /// <summary>
    /// Initialize the inventory list
    /// </summary>
    private void CreateInventoryList()
    {
        for (var i = 0; i < itemDatas.Count; i++)
        {
            inventory.Add(new InventoryItem(itemDatas[i]));
        }
    }

    /// <summary>
    /// Add new item(s) to the inventory
    /// </summary>
    /// <param name="itemData"></param>
    /// <param name="amount"></param>
    public void AddItems(List<InventoryItem> inventory)
    {
        for (var i = 0; i < this.inventory.Count; i++)
        {
            if (this.inventory[i].itemData.itemType.type.Equals(inventory[i].itemData.itemType.type))
            {
                this.inventory[i].AddStack(inventory[i].StackAmount);
                inventoryGUI.UpdateInventorySlot(this.inventory[i]);
            }
        }
    }

    /// <summary>
    /// Add new item(s) to the inventory
    /// </summary>
    /// <param name="itemData"></param>
    /// <param name="amount"></param>
    public void AddItem(ItemType itemType, int amount)
    {
        for (var i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].itemData.itemType.type.Equals(itemType))
            {
                inventory[i].AddStack(amount);
                inventoryGUI.UpdateInventorySlot(inventory[i]);
            }
        }
    }

    /// <summary>
    /// Remove item(s) to the inventory
    /// </summary>
    /// <param name="itemData"></param>
    /// <param name="amount"></param>
    public void RemoveItem(ItemType itemType, int amount)
    {
        for (var i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].itemData.itemType.type.Equals(itemType))
            {
                inventory[i].RemoveStack(amount);
                inventoryGUI.UpdateInventorySlot(inventory[i]);

                if (inventory[i].StackAmount <= 0)
                {
                    inventory[i].ClearStack();
                    inventoryGUI.UpdateInventorySlot(inventory[i]);
                }
            }
        }
    }
}