using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : MonoBehaviour
{
    // FSM
    public UnitMoveCollectState UnitMoveCollectState { get; private set; }
    public UnitCollectState UnitCollectState { get; private set; }
    public UnitMoveStorageState UnitMoveStorageState { get; private set; }
    public UnitMoveConstructionState UnitMoveConstructionState { get; private set; }
    public UnitConstructionState UnitConstructionState { get; private set; }

    // Components
    [field: SerializeField] public Unit Unit { get; private set; }
    [field: SerializeField] public Villager_SO Villager_SO { get; private set; }
    [field: SerializeField] public VillagerInventory VillagerInventory { get; private set; }
    [field: SerializeField] public BuildingConstruction BuildingConstruction { get; private set; }

    void Start()
    {
        UnitMoveCollectState = new UnitMoveCollectState(this, Unit, Unit.UnitStateMachine, "isWalking");
        UnitCollectState = new UnitCollectState(this, Unit, Unit.UnitStateMachine, "isIdle");
        UnitMoveStorageState = new UnitMoveStorageState(this, Unit, Unit.UnitStateMachine, "isWalking");
        UnitMoveConstructionState = new UnitMoveConstructionState(this, Unit, Unit.UnitStateMachine, "isWalking");
        UnitConstructionState = new UnitConstructionState(this, Unit, Unit.UnitStateMachine, "isAttacking");
    }

    public void SetBuildingConstruction(BuildingConstruction buildingConstruction) 
    {
        BuildingConstruction = buildingConstruction;
    }
}
