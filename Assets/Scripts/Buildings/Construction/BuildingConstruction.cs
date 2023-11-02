using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingConstruction : MonoBehaviour
{
    [field: SerializeField] public Building Building { get; private set; }
    [field: SerializeField] public List<GameObject> BuildingVisuals { get; private set; }
    public List<Villager> villagers;

    // FSM
    public BuildingConstructionStateManager BuildingConstructionStateManager { get; private set; }
    public BuildingConstructionInitializationState BuildingConstructionInitializationState { get; private set; }
    public BuildingConstructionAssembleState BuildingConstructionAssembleState { get; private set; }
    public BuildingConstructionPauseState BuildingConstructionPauseState { get; private set; }
    public BuildingConstructionFinishState BuildingConstructionFinishState { get; private set; }
    public BuildingConstructionDefaultState BuildingConstructionDefaultState { get; private set; }

    void Start()
    {
        // Set states
        BuildingConstructionStateManager = new BuildingConstructionStateManager();
        BuildingConstructionDefaultState = new BuildingConstructionDefaultState(this, BuildingConstructionStateManager);
        BuildingConstructionInitializationState = new BuildingConstructionInitializationState(this, BuildingConstructionStateManager);
        BuildingConstructionAssembleState = new BuildingConstructionAssembleState(this, BuildingConstructionStateManager);
        BuildingConstructionPauseState = new BuildingConstructionPauseState(this, BuildingConstructionStateManager);
        BuildingConstructionFinishState = new BuildingConstructionFinishState(this, BuildingConstructionStateManager);
        BuildingConstructionStateManager.Initialize(BuildingConstructionDefaultState);
    }

    void Update()
    {
        BuildingConstructionStateManager.currentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        BuildingConstructionStateManager.currentState.PhysicsUpdate();
    }
}
