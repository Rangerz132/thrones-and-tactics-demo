using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerInventory : MonoBehaviour
{
    private List<InventoryItem> inventory = new List<InventoryItem>();
    [SerializeField] private List<ItemData_SO> itemDatas;
    [SerializeField] private int itemAmountLimit;
    [SerializeField] private VillagerBag villagerBag;

    private void Start()
    {
        CreateInventoryList();
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
    public void Add(ItemType itemType, int amount)
    {
        villagerBag.EnableRessource(itemType);

        for (var i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].itemData.itemType.type.Equals(itemType))
            {
                inventory[i].AddStack(amount);
            }
        }
    }

    /// <summary>
    /// Remove item(s) to the inventory
    /// </summary>
    /// <param name="itemData"></param>
    /// <param name="amount"></param>
    public void Remove(ItemType itemType, int amount)
    {
        for (var i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].itemData.itemType.type.Equals(itemType))
            {
                inventory[i].RemoveStack(amount);

                if (inventory[i].StackAmount <= 0)
                {
                    inventory[i].ClearStack();
                }
            }
        }
    }

    /// <summary>
    /// Empty the villager inventory to fill the closest storage
    /// </summary>
    public void EmptyInventoryToStorage()
    {
        villagerBag.DisableAllRessources();
        EventManager.TriggerEvent("OnCollectItems", new Dictionary<string, object> { { "inventory", inventory } });
        ClearInventory();
    }

    /// <summary>
    /// Clear inventory
    /// </summary>
    public void ClearInventory()
    {
        for (var i = 0; i < inventory.Count; i++)
        {
            inventory[i].ClearStack();
        }
    }

    /// <summary>
    /// Check if the inventory is full
    /// </summary>
    /// <returns></returns>
    public bool IsInventoryFull()
    {
        bool isInventoryFull = false;

        for (var i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].StackAmount >= itemAmountLimit)
            {
                isInventoryFull = true;
            }
        }

        return isInventoryFull;
    }
}
