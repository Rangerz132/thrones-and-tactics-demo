using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnitState
{
    protected Unit unit;
    protected UnitStateMachine unitStateMachine;
    protected string animBoolName;
    public delegate void MyDelegate();
    public MyDelegate stateDelegate;

    public UnitState(Unit unit, UnitStateMachine unitStateMachine, string animBoolName)
    {
        this.unit = unit;
        this.unitStateMachine = unitStateMachine;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        unit.Animator.SetBool(animBoolName, true);
    }

    public virtual void Exit()
    {
        unit.Animator.SetBool(animBoolName, false);
    }

    public virtual void LogicUpdate()
    {
        DoChecks();
    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public virtual void DoChecks()
    {

    }

    public virtual void TriggerDelegate(string delegateName)
    {
       
    }
}
