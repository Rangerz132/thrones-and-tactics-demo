using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnimation : MonoBehaviour
{
    [SerializeField] private Unit unit;

    public void OnTriggerStateDelegate(string delegateName)
    {
        unit.UnitStateMachine.currentState.TriggerDelegate(delegateName);
    }
}
