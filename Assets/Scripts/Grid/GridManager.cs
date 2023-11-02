using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private Grid grid;
    [SerializeField] private GameObject gridVisual;
    private BuildingPlacement buildingPlacement;

    private void OnEnable()
    {
        EventManager.StartListening("OnBuildingToPlace", OnBuildingToPlace);
        EventManager.StartListening("OnBuildingIntegrated", OnBuildingIntegrated);
    }

    private void OnDisable()
    {
        EventManager.StopListening("OnBuildingToPlace", OnBuildingToPlace);
        EventManager.StopListening("OnBuildingIntegrated", OnBuildingIntegrated);
    }

    void Update()
    {
        if (buildingPlacement != null) 
        {
            Vector3 mousePosition = GetSelectedMapPosition();
            Vector3Int gridPosition = grid.WorldToCell(mousePosition);
            Vector3 gridCellPosition = grid.CellToWorld(gridPosition);
            Vector3 targetPosition = new Vector3(gridCellPosition.x + grid.cellSize.x / 2, gridCellPosition.y, gridCellPosition.z + grid.cellSize.z / 2);
            buildingPlacement.PositionBuilding(targetPosition);

            if (Input.GetKeyDown(KeyCode.Tab)) 
            {
                StartCoroutine(buildingPlacement.Rotate90Deg());
            }
        }     

    }

    public Vector3 GetSelectedMapPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3 hitPosition = Vector3.zero;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Terrain")))
        {
            hitPosition = hit.point;
        }
        return hitPosition;
    }


    private void OnBuildingToPlace(Dictionary<string, object> message)
    {
        GameObject building = (GameObject)message["building"];
        buildingPlacement = building.GetComponent<BuildingPlacement>();
        ShowGrid();
    }

    private void OnBuildingIntegrated(Dictionary<string, object> message)
    {
        buildingPlacement = null;
        HideGrid();
    }

    private void ShowGrid()
    {
        gridVisual.SetActive(true);
    }

    private void HideGrid()
    {
        gridVisual.SetActive(false);
    }
}
