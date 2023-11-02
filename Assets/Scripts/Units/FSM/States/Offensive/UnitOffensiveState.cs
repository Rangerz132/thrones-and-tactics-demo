using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitOffensiveState : UnitState
{
    public GameObject target;
    protected int attackDamage;

    public UnitOffensiveState(Unit unit, UnitStateMachine unitStateMachine, string animBoolName) : base(unit, unitStateMachine, animBoolName)
    {
        attackDamage = unit.Unit_SO.unitAttack.damage;
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
}
