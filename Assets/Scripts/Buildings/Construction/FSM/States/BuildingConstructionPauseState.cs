using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingConstructionPauseState : BuildingConstructionState
{
    public BuildingConstructionPauseState(BuildingConstruction buildingConstruction, BuildingConstructionStateManager buildingConstructionStateManager) : base(buildingConstruction, buildingConstructionStateManager)
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
}
