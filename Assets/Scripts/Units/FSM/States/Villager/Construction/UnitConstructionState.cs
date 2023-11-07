using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitConstructionState : UnitGatherState
{
    private float rotationSpeed = 10f; 

    public UnitConstructionState(Villager villager, Unit unit, UnitStateMachine unitStateMachine, string animBoolName) : base(villager, unit, unitStateMachine, animBoolName)
    {

    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        // Add this villager to the list of the building constructors
        villager.BuildingConstruction.villagers.Add(villager);
        villager.BuildingConstruction.BuildingConstructionStateManager.ChangeState(villager.BuildingConstruction.BuildingConstructionAssembleState);
        villager.EnableTool(VillagerTool.Hammer);
    }

    public override void Exit()
    {
        base.Exit();
        

        // Remove this villager to the list of the building constructors
        villager.BuildingConstruction.villagers.Remove(villager);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        // Face target
        unit.FaceTarget(villager.BuildingConstruction.transform, rotationSpeed);

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
