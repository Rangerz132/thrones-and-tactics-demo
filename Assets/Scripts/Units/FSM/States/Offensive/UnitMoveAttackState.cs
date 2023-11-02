using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMoveAttackState : UnitOffensiveState
{
    public UnitMoveAttackState(Unit unit, UnitStateMachine unitStateMachine, string animBoolName) : base(unit, unitStateMachine, animBoolName)
    {

    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        // Set stopping distance :
        // The value should be higher for range units such as archers and scouts)
        unit.AgentController.SetStopDistance(unit.Unit_SO.unitAttack.range);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        unit.AgentController.GoToDestination(target.transform.position);

        // Change state when the destination is reached
        if (unit.AgentController.DestinationReached())
        {
            unit.UnitStateMachine.ChangeState(unit.UnitAttackState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
