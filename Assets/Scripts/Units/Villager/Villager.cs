using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum VillagerTool
{
    Hammer,
    Axe,
    Pickaxe,
    Dagger,
}

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

    [SerializeField] private List<GameObject> toolsList = new List<GameObject>();
    private GameObject currentHoldingTool;
    private Dictionary<VillagerTool, GameObject> toolsDictionnary  = new Dictionary<VillagerTool, GameObject>();

    void Start()
    {
        UnitMoveCollectState = new UnitMoveCollectState(this, Unit, Unit.UnitStateMachine, "isWalking");
        UnitCollectState = new UnitCollectState(this, Unit, Unit.UnitStateMachine, "isIdle");
        UnitMoveStorageState = new UnitMoveStorageState(this, Unit, Unit.UnitStateMachine, "isWalking");
        UnitMoveConstructionState = new UnitMoveConstructionState(this, Unit, Unit.UnitStateMachine, "isWalking");
        UnitConstructionState = new UnitConstructionState(this, Unit, Unit.UnitStateMachine, "isAttacking");

        InitializeTools();
    }

    /// <summary>
    /// Populate tools list
    /// </summary>
    private void InitializeTools()
    {
        toolsDictionnary.Add(VillagerTool.Hammer, toolsList[0]);
        toolsDictionnary.Add(VillagerTool.Axe, toolsList[1]);
        toolsDictionnary.Add(VillagerTool.Pickaxe, toolsList[2]);
        toolsDictionnary.Add(VillagerTool.Dagger, toolsList[3]);
    }

    /// <summary>
    /// Enable needed tool according to villager order
    /// </summary>
    /// <param name="tool"></param>
    public void EnableTool(VillagerTool tool)
    {
        DisableTool();

        if (toolsDictionnary.ContainsKey(tool))
        {
            toolsDictionnary[tool].gameObject.SetActive(true);
            currentHoldingTool = toolsDictionnary[tool];
        }
        else {
            DisableTool();
        }  
    }

    /// <summary>
    /// Disable current villager tool
    /// </summary>
    public void DisableTool()
    {
        if (currentHoldingTool != null) {
            currentHoldingTool.SetActive(false);
        }
    }

    public void SetBuildingConstruction(BuildingConstruction buildingConstruction)
    {
        BuildingConstruction = buildingConstruction;
    }
}
