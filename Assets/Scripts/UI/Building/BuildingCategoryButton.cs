using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingCategoryButton : MonoBehaviour
{
    [SerializeField] private BuildingType_SO buildingType;
    [SerializeField] private Image buttonIcon;
    [SerializeField] private BuildingButtonManager buildingButtonContainer;
    [SerializeField] private List<Building_SO> buildings;

    void Start()
    {
        buttonIcon.sprite = buildingType.icon;
    }

    /// <summary>
    /// Button onClick
    /// </summary>
    public void TriggerBuildingButtonContainer()
    {
        buildingButtonContainer.AddBuildingToList(buildings);
        EnableBuildingButtonContainer();
    }

    /// <summary>
    /// Enable the gameObject containing all building buttons
    /// </summary>
    public void EnableBuildingButtonContainer()
    {
        buildingButtonContainer.EnableBuildingButtonContainer();
    }

    /// <summary>
    /// Disable the gameObject containing all building buttons
    /// </summary>
    public void DisableBuildingButtonContainer()
    {
        buildingButtonContainer.DisableBuildingButtonContainer();
    }
}
