using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    [SerializeField] private List<Unit> units = new List<Unit>();
    [SerializeField] private SelectionBox selectionBox;
    private Vector3 startDragPosition;
    private Vector3 endDragPosition;

    private void Update()
    {
        // Left click
        if (Input.GetMouseButtonDown(0))
        {
            AddUnitFromSingleClick();

            startDragPosition = RaycastUtility.MouseToTerrainPosition();
            endDragPosition = startDragPosition;

            selectionBox.ActivateSelectionBox();
        }

        // Mouse hold
        if (Input.GetMouseButton(0))
        {
            selectionBox.UpdateSelectionBox(Input.mousePosition);
        }

        // Mouse Up
        if (Input.GetMouseButtonUp(0))
        {
            AddUnitFromDrag();
            selectionBox.DeactivateSelectionBox();
        }

        // Right click
        if (Input.GetMouseButtonDown(1))
        {
            MoveUnits();
        }
    }

    /// <summary>
    /// Base method to add unit(s)
    /// </summary>
    /// <param name="hit"></param>
    private void AddUnits(RaycastHit hit)
    {
        if (hit.collider.TryGetComponent<Unit>(out Unit unit))
        {
            if (!units.Contains(unit))
            {
                units.Add(unit);

                for (var i = 0; i < units.Count; i++)
                {
                    units[i].SelectedTarget.PlaySelectAnimation();
                    units[i].HealthVisual.PlaySelectAnimation();
                }
            }
        }
    }

    /// <summary>
    /// Add one unit to the unit list
    /// </summary>
    private void AddUnitFromSingleClick()
    {
        ClearUnits();

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            AddUnits(hit);
        }
    }

    /// <summary>
    /// Add unit(s) to unit list from selection box
    /// </summary>
    private void AddUnitFromDrag()
    {
        endDragPosition = RaycastUtility.MouseToTerrainPosition();

        var dragCenter = (startDragPosition + endDragPosition) / 2;
        var dragSize = (endDragPosition - startDragPosition);
        dragSize.Set(Mathf.Abs(dragSize.x / 2), 1, Mathf.Abs(dragSize.z / 2));

        RaycastHit[] hits = Physics.BoxCastAll(dragCenter, dragSize, Vector3.up, Quaternion.identity);

        foreach (RaycastHit hit in hits)
        {
            AddUnits(hit);
        }
    }

    /// <summary>
    /// Move all units to the mouse click hit position
    /// </summary>
    private void MoveUnits()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {
            for (var i = 0; i < units.Count; i++)
            {
                if (hit.transform.gameObject.TryGetComponent(out RessourceSupplier ressourceSupplier))
                {
                    if (units[i].transform.TryGetComponent(out Villager villager))
                    {
                        villager.UnitCollectState.ChangeCurrentAnimation(ressourceSupplier.AnimationName);
                        villager.UnitCollectState.SetRessourceSupplier(ressourceSupplier);
                        villager.UnitMoveStorageState.SetRessourceSupplier(ressourceSupplier);
                        villager.Unit.UnitStateMachine.ChangeState(villager.UnitMoveCollectState);
                        villager.Unit.AgentController.GoToDestination(ressourceSupplier.transform.position);
                    }
                }
                else if (hit.transform.gameObject.TryGetComponent(out BuildingConstruction buildingConstruction))
                {
                    if (units[i].transform.TryGetComponent(out Villager villager))
                    {
                        villager.SetBuildingConstruction(buildingConstruction);
                        villager.Unit.UnitStateMachine.ChangeState(villager.UnitMoveConstructionState);
                        villager.Unit.AgentController.GoToDestination(buildingConstruction.transform.position);
                    }
                }
                else if (hit.transform.gameObject.TryGetComponent(out Enemy enemy))
                {
                    units[i].UnitStateMachine.ChangeState(units[i].UnitMoveAttackState);
                    units[i].AgentController.GoToDestination(enemy.transform.position);
                    units[i].UnitAttackState.target = enemy.gameObject;
                    units[i].UnitMoveAttackState.target = enemy.gameObject;
                }
                else
                {
                    units[i].UnitStateMachine.ChangeState(units[i].UnitWalkState);
                    units[i].AgentController.GoToDestination(hit.point);
                }
            }
        }
    }

    /// <summary>
    /// Remove every unit in the unit list
    /// </summary>
    private void ClearUnits()
    {
        for (var i = 0; i < units.Count; i++)
        {
            units[i].SelectedTarget.PlayUnselectAnimation();
            units[i].HealthVisual.PlayUnselectAnimation();
        }

        units.Clear();
    }
}
