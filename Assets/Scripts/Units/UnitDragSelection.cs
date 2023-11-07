using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDragSelection : MonoBehaviour
{
    [SerializeField] private UnitManager unitManager;
    [SerializeField] private RectTransform selectionBoxVisual;
    private Rect selectionBox;
    private Vector2 startPosition;
    private Vector2 endPosition;

    void Update()
    {
        // Click
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;
            UpdateSelectionBoxVisual();
            UpdateSelection();
        }

        // Hold
        if (Input.GetMouseButton(0))
        {
            endPosition = Input.mousePosition;
            UpdateSelectionBoxVisual();
            UpdateSelection();
        }

        // Up
        if (Input.GetMouseButtonUp(0))
        {
            SelectUnitFromDrag();
            startPosition = Vector2.zero;
            endPosition = Vector2.zero;
            UpdateSelectionBoxVisual();
            UpdateSelection();
        }
    }

    /// <summary>
    /// Set selection box size and position
    /// </summary>
    private void UpdateSelectionBoxVisual()
    {
        Vector2 selectionBoxVisualStart = startPosition;
        Vector2 selectionBoxVisualEnd = endPosition;

        Vector2 selectionBoxVisualCenter = (selectionBoxVisualStart + selectionBoxVisualEnd) / 2;
        selectionBoxVisual.position = selectionBoxVisualCenter;

        Vector2 selectionBoxVisualSize = new Vector2(Mathf.Abs(selectionBoxVisualStart.x - selectionBoxVisualEnd.x), Mathf.Abs(selectionBoxVisualStart.y - selectionBoxVisualEnd.y));
        selectionBoxVisual.sizeDelta = selectionBoxVisualSize;
    }

    /// <summary>
    /// Set selection box logic
    /// </summary>
    private void UpdateSelection()
    {
        if (Input.mousePosition.x < startPosition.x)
        {
            selectionBox.xMin = Input.mousePosition.x;
            selectionBox.xMax = startPosition.x;
        }
        else
        {
            selectionBox.xMin = startPosition.x;
            selectionBox.xMax = Input.mousePosition.x;
        }

        if (Input.mousePosition.y < startPosition.y)
        {
            selectionBox.yMin = Input.mousePosition.y;
            selectionBox.yMax = startPosition.y;
        }
        else
        {
            selectionBox.yMin = startPosition.y;
            selectionBox.yMax = Input.mousePosition.y;
        }
    }

    /// <summary>
    /// Add unit(s) from drag selection
    /// </summary>
    private void SelectUnitFromDrag()
    {
        foreach (Unit unit in unitManager.Units)
        {
            if (selectionBox.Contains(Camera.main.WorldToScreenPoint(unit.transform.position)))
            {
                unitManager.AddUnit(unit);
            }
        }
    }
}
