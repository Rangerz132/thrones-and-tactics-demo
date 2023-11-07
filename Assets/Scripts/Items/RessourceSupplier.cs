using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourceSupplier : MonoBehaviour, IEntity
{
    [SerializeField] private ItemData_SO itemData_SO;
    [SerializeField] private HealthVisual healthVisual;
    private int amount;
    [field: SerializeField] public string AnimationName { get; private set; }
    [SerializeField] public VillagerTool villagerTool;

    void Start()
    {
        amount = itemData_SO.amount;
        healthVisual.SetHealth(amount);
    }

    public void Harvest(VillagerInventory villagerInventory)
    {
        amount--;
        healthVisual.TakeDamage(1);
        villagerInventory.Add(itemData_SO.itemType.type, 1);
    }

    public void OnClick()
    {
        healthVisual.PlaySelectAnimation();
    }

    public void OnRelease()
    {
        healthVisual.PlayUnselectAnimation();
    }
}
