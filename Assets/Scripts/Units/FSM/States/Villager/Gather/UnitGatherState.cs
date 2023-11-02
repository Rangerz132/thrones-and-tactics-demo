using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitGatherState : UnitState
{
    public string currentAnimation;
    protected Villager villager;
    protected RessourceSupplier ressourceSupplier;
    protected Vector3 closestBuildingStoragePosition;

    public UnitGatherState(Villager villager, Unit unit, UnitStateMachine unitStateMachine, string animBoolName) : base(unit, unitStateMachine, animBoolName)
    {
        this.villager = villager;
    }

    public void ChangeCurrentAnimation(string animationName)
    {
        this.animBoolName = animationName;
    }

    public void SetRessourceSupplier(RessourceSupplier ressourceSupplier)
    {
        this.ressourceSupplier = ressourceSupplier;
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
