using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMoveStorageState : UnitGatherState
{
    public UnitMoveStorageState(Villager villager, Unit unit, UnitStateMachine unitStateMachine, string animBoolName) : base(villager, unit, unitStateMachine, animBoolName)
    {

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

        // Change state when the destination is reached
        if (unit.AgentController.DestinationReached())
        {
            villager.VillagerInventory.EmptyInventoryToStorage();
            unit.AgentController.GoToDestination(ressourceSupplier.transform.position);
            unit.UnitStateMachine.ChangeState(villager.UnitMoveCollectState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
