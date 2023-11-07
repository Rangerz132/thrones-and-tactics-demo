using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitClickSelection : MonoBehaviour
{
    [SerializeField] private UnitManager unitManager;

    void Update()
    {
        // Click
        if (Input.GetMouseButtonDown(0))
        {
            unitManager.ClearSelectedUnits();
            AddUnitFromClick();
        }
    }

    /// <summary>
    /// Add unit from click
    /// </summary>
    private void AddUnitFromClick() 
    {       
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider.TryGetComponent(out Unit unit))
            {
                unitManager.AddUnit(unit);
            }
        }
    }
}
