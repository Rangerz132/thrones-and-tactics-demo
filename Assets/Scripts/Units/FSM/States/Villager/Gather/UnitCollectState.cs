using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCollectState : UnitGatherState
{
    private float step = 1f;
    private float initialStep = 1f;
    private float rotationSpeed = 10f;

    public UnitCollectState(Villager villager, Unit unit, UnitStateMachine unitStateMachine, string animBoolName) : base(villager, unit, unitStateMachine, animBoolName)
    {

    }

    private void Collect()
    {
        step -= Time.deltaTime;

        if (step <= 0)
        {
            // Get ressource
            ressourceSupplier.Harvest(villager.VillagerInventory);
            step = initialStep;

            // Check if the village inventory is full and go to the closest storage is that's the case
            if (villager.VillagerInventory.IsInventoryFull()) 
            {
                BuildingManager buildingManager = GameObject.FindObjectOfType(typeof(BuildingManager)) as BuildingManager;        
                closestBuildingStoragePosition = buildingManager.GetClosestStoragePosition(villager.transform);
                unit.AgentController.GoToDestination(closestBuildingStoragePosition);
                unit.UnitStateMachine.ChangeState(villager.UnitMoveStorageState);
            } 
        }
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        Collect();

        // Face target
        unit.FaceTarget(ressourceSupplier.transform, rotationSpeed);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
