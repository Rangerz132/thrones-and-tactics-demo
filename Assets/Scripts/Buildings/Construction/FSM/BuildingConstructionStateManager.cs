using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingConstructionStateManager
{
    public BuildingConstructionState currentState { get; private set; }
    public BuildingConstructionState previousState { get; private set; }

    public void Initialize(BuildingConstructionState startingState)
    {
        currentState = startingState;
        previousState = startingState;
        currentState.Enter();
    }

    public void ChangeState(BuildingConstructionState newState)
    {
        previousState = currentState;
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}
