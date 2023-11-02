using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitWalkState : UnitState
{
    public UnitWalkState(Unit unit, UnitStateMachine unitStateMachine, string animBoolName) : base(unit, unitStateMachine, animBoolName)
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
            unit.UnitStateMachine.ChangeState(unit.UnitIdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
