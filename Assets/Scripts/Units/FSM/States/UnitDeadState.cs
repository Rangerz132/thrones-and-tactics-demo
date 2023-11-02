using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDeadState : UnitState
{
    public UnitDeadState(Unit unit, UnitStateMachine unitStateMachine, string animBoolName) : base(unit, unitStateMachine, animBoolName)
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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private void Die()
    {
        unit.gameObject.SetActive(false);
    }

    public override void TriggerDelegate(string delegateName)
    {
        switch (delegateName)
        {
            case "Die":
                stateDelegate = Die;
                stateDelegate();
                break;
        }
    }
}
