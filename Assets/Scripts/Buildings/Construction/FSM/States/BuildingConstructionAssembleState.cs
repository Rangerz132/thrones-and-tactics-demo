using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingConstructionAssembleState : BuildingConstructionState
{
    private float totalTime;
    private float currentTime;
    private int totalsteps;
    private int currentStep;
    private int stepSize;

    public BuildingConstructionAssembleState(BuildingConstruction buildingConstruction, BuildingConstructionStateManager buildingConstructionStateManager) : base(buildingConstruction, buildingConstructionStateManager)
    {
        totalTime = buildingConstruction.Building.buildingData.buildingConstruction.time;
        totalsteps = buildingConstruction.Building.buildingData.buildingConstruction.step;
        stepSize = (int)(totalTime / totalsteps);
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
        IncreaseConstructionTime();
    }

    /// <summary>
    /// Showcase part of the building based on the current construction time
    /// </summary>
    private void IncreaseConstructionTime()
    {
        // The building is finish
        if (currentTime >= totalTime)
        {
            CompleteBuilding();
        }

        // Pause the construction because there i no more constructors
        if (buildingConstruction.villagers.Count == 0)
        {
            PauseConstruction();
        }

        // Increase speed according to the amount of villagers
        currentTime += Time.deltaTime * buildingConstruction.villagers.Count;

        int newStep = Mathf.FloorToInt(currentTime / stepSize);

        if (newStep != currentStep)
        {
            currentStep = newStep;

            // Enable new part of the building
            for (var i = 0; i < buildingConstruction.BuildingVisuals.Count; i++)
            {
                buildingConstruction.BuildingVisuals[i].SetActive(i == currentStep);
            }
        }

        IncreaseHealth();
    }

    /// <summary>
    /// Puase the construction
    /// </summary>
    private void PauseConstruction()
    {
        buildingConstructionStateManager.ChangeState(buildingConstruction.BuildingConstructionPauseState);
    }

    /// <summary>
    /// Clear any data revolving around the villagers and change the current building state
    /// </summary>
    private void CompleteBuilding()
    {
        for (var i = 0; i < buildingConstruction.villagers.Count; i++)
        {
            buildingConstruction.villagers[i].Unit.UnitStateMachine.ChangeState(buildingConstruction.villagers[i].Unit.UnitIdleState);
        }

        buildingConstruction.villagers.Clear();
        buildingConstructionStateManager.ChangeState(buildingConstruction.BuildingConstructionFinishState);
    }

    /// <summary>
    /// Increase health while building
    /// </summary>
    private void IncreaseHealth()
    {
        var healAmount =  (buildingConstruction.Building.HealthVisual.maxHealth / totalTime ) * Time.deltaTime;
        buildingConstruction.Building.HealthVisual.Heal(healAmount);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
