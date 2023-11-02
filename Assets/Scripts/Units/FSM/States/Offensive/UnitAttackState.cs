using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAttackState : UnitOffensiveState
{
    private float rotationSpeed = 10f;

    public UnitAttackState(Unit unit, UnitStateMachine unitStateMachine, string animBoolName) : base(unit, unitStateMachine, animBoolName)
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
        unit.FaceTarget(target.transform, rotationSpeed);
    }

    /// <summary>
    /// Chase the target if he is out of reach
    /// </summary>
    private void ChaseTarget() 
    {
        float distance = Vector3.Distance(target.transform.position, unit.transform.position);

        if (distance > unit.AgentController.Agent.stoppingDistance)
        {
            unit.AgentController.GoToDestination(target.transform.position);
            unit.UnitStateMachine.ChangeState(unit.UnitMoveAttackState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerDelegate(string delegateName)
    {
        switch (delegateName)
        {
            case "Chase":
                stateDelegate = ChaseTarget;
                stateDelegate();
                break;
        }
    }
}
