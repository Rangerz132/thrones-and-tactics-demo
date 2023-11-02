using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStateMachine
{
    public UnitState currentState { get; private set; }
    public UnitState previousState { get; private set; }

    public void Initialize(UnitState startingState)
    {
        currentState = startingState;
        previousState = startingState;
        currentState.Enter();
    }

    public void ChangeState(UnitState newState)
    {
        previousState = currentState;
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}
