using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingConstructionState
{
    protected BuildingConstruction buildingConstruction;
    protected BuildingConstructionStateManager buildingConstructionStateManager;
    protected string animBoolName;

    public BuildingConstructionState(BuildingConstruction buildingConstruction, BuildingConstructionStateManager buildingConstructionStateManager)
    {
        this.buildingConstruction = buildingConstruction;
        this.buildingConstructionStateManager = buildingConstructionStateManager;
    }

    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

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
}
