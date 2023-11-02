using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerBag : MonoBehaviour
{
    [SerializeField] private List<VillagerBagRessource> ressources;

    public void EnableRessource(ItemType itemType)
    {
        for (var i = 0; i < ressources.Count; i++)
        {
            ressources[i].gameObject.SetActive(ressources[i].itemType_SO.type.Equals(itemType));
        }
    }

    public void DisableAllRessources()
    {
        for (var i = 0; i < ressources.Count; i++)
        {
            ressources[i].gameObject.SetActive(false);
        }
    }
}
