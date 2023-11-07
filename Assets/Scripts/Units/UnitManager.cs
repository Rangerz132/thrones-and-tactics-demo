using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    [field: SerializeField] public List<Unit> Units { get; private set; } = new List<Unit>();
    [field: SerializeField] public List<Unit> SelectedUnits { get; private set; } = new List<Unit>();

    private void Update()
    {
        // Right click
        if (Input.GetMouseButtonDown(1))
        {
            GiveOrders();
        }
    }

    /// <summary>
    /// Add unit to the selected unit list
    /// </summary>
    /// <param name="unit"></param>
    public void AddUnit(Unit unit)
    {
        if (!SelectedUnits.Contains(unit))
        {
            SelectedUnits.Add(unit);
            unit.SelectedTarget.PlaySelectAnimation();
            unit.HealthVisual.PlaySelectAnimation();
        }
    }

    /// <summary>
    /// Remove unit to the selected unit list
    /// </summary>
    /// <param name="unit"></param>
    public void RemoveUnit(Unit unit)
    {
        if (SelectedUnits.Contains(unit))
        {
            unit.SelectedTarget.PlayUnselectAnimation();
            unit.HealthVisual.PlayUnselectAnimation();
            SelectedUnits.Remove(unit);
        }
    }

    /// <summary>
    /// Remove all units to the selected unit list
    /// </summary>
    public void ClearSelectedUnits()
    {
        for (var i = 0; i < SelectedUnits.Count; i++)
        {
            SelectedUnits[i].SelectedTarget.PlayUnselectAnimation();
            SelectedUnits[i].HealthVisual.PlayUnselectAnimation();
        }

        SelectedUnits.Clear();
    }

    /// <summary>
    /// Give units orders based on the returned hit object
    /// </summary>
    private void GiveOrders()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {
            for (var i = 0; i < SelectedUnits.Count; i++)
            {
                if (hit.transform.gameObject.TryGetComponent(out RessourceSupplier ressourceSupplier))
                {
                    SetUnitGatherOrder(SelectedUnits[i], ressourceSupplier);
                }
                else if (hit.transform.gameObject.TryGetComponent(out BuildingConstruction buildingConstruction))
                {
                    SetUnitConstructOrder(SelectedUnits[i], buildingConstruction);
                }
                else if (hit.transform.gameObject.TryGetComponent(out Enemy enemy))
                {
                    SetUnitAttackOrder(SelectedUnits[i], enemy);
                }
                else
                {
                    SetUnitMoveOrder(SelectedUnits[i], hit);
                }
            }
        }
    }

    /// <summary>
    /// Make units gather ressources to the ressource supplier
    /// </summary>
    /// <param name="unit"></param>
    /// <param name="ressourceSupplier"></param>
    private void SetUnitGatherOrder(Unit unit, RessourceSupplier ressourceSupplier)
    {
        if (unit.transform.TryGetComponent(out Villager villager))
        {
            villager.UnitCollectState.ChangeCurrentAnimation(ressourceSupplier.AnimationName);
            villager.UnitCollectState.SetRessourceSupplier(ressourceSupplier);
            villager.UnitMoveStorageState.SetRessourceSupplier(ressourceSupplier);
            villager.Unit.UnitStateMachine.ChangeState(villager.UnitMoveCollectState);
            villager.Unit.AgentController.GoToDestination(ressourceSupplier.transform.position);
        }
    }

    /// <summary>
    /// Make units construct the selected building
    /// </summary>
    /// <param name="unit"></param>
    /// <param name="buildingConstruction"></param>
    private void SetUnitConstructOrder(Unit unit, BuildingConstruction buildingConstruction)
    {
        if (unit.transform.TryGetComponent(out Villager villager))
        {
            villager.SetBuildingConstruction(buildingConstruction);
            villager.Unit.UnitStateMachine.ChangeState(villager.UnitMoveConstructionState);
            villager.Unit.AgentController.GoToDestination(buildingConstruction.transform.position);
        }
    }

    /// <summary>
    /// Make the units attack an enemy
    /// </summary>
    /// <param name="unit"></param>
    /// <param name="enemy"></param>
    private void SetUnitAttackOrder(Unit unit, Enemy enemy)
    {
        unit.UnitStateMachine.ChangeState(unit.UnitMoveAttackState);
        unit.AgentController.GoToDestination(enemy.transform.position);
        unit.UnitAttackState.target = enemy.gameObject;
        unit.UnitMoveAttackState.target = enemy.gameObject;
    }

    /// <summary>
    /// Make the units move to a specific point
    /// </summary>
    /// <param name="unit"></param>
    /// <param name="hit"></param>
    private void SetUnitMoveOrder(Unit unit, RaycastHit hit)
    {
        unit.UnitStateMachine.ChangeState(unit.UnitWalkState);
        unit.AgentController.GoToDestination(hit.point);
    }
}
