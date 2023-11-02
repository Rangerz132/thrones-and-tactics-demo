using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuildingButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private GameObject building;
    [SerializeField] private Image buttonIcon;
    [SerializeField] private Building_SO building_SO;

    private void Start()
    {
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        EventManager.TriggerEvent("OnBuildingButtonClick", new Dictionary<string, object> { { "building_SO", building_SO } });
    }

    /// <summary>
    /// Assign building data to the button
    /// </summary>
    /// <param name="building_SO"></param>
    public void AssignBuildingData(Building_SO building_SO)
    {
        this.building_SO = building_SO;
        buttonIcon.gameObject.SetActive(true);
        buttonIcon.sprite = building_SO.icon;
    } 

    /// <summary>
    /// Reset building data
    /// </summary>
    public void HideBuildingData()
    {
        buttonIcon.gameObject.SetActive(false);
    }

    /// <summary>
    /// Add building to the world
    /// </summary>
    public void AddBuilding()
    {
        building.SetActive(true);
    }
}
