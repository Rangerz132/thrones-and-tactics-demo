using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingButtonManager : MonoBehaviour
{
    [SerializeField] private List<Building_SO> buildings;
    [SerializeField] private List<BuildingButton> buildingButtons;
    [field:SerializeField] public GameObject BuildingButtonsContainer;
    public BuildingType currentBuildingType;

    /// <summary>
    /// Insert new list of building in the current list
    /// </summary>
    /// <param name="buildings"></param>
    public void AddBuildingToList(List<Building_SO> buildingList)
    {
        ClearBuildings();
        ClearBuildingButtonDatas();
        buildings.AddRange(buildingList);
        AssignBuildingDataToButton();
        currentBuildingType = buildingList[0].buildingType.buildingType;
    }

    private void AssignBuildingDataToButton() 
    {
        for (var i = 0; i < buildings.Count; i++) {
            buildingButtons[i].AssignBuildingData(buildings[i]);
        }
    }

    /// <summary>
    /// Clear list of building
    /// </summary>
    private void ClearBuildings()
    {
        buildings.Clear();
    }

    /// <summary>
    /// Hide building button icons
    /// </summary>
    private void ClearBuildingButtonDatas() {
        for (var i = 0; i < buildingButtons.Count; i++)
        {
            buildingButtons[i].HideBuildingData();
        }
    }

    /// <summary>
    /// Enable the gameObject containing all building buttons
    /// </summary>
    public void EnableBuildingButtonContainer()
    {
        BuildingButtonsContainer.gameObject.SetActive(true);
    }

    /// <summary>
    /// Disable the gameObject containing all building buttons
    /// </summary>
    public void DisableBuildingButtonContainer()
    {
        BuildingButtonsContainer.gameObject.SetActive(false);
    }
}
