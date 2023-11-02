using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionBox : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    private Vector2 mouseStartPosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseStartPosition = Input.mousePosition;
        }
    }

    /// <summary>
    /// Set selection box size and position
    /// </summary>
    /// <param name="currentMousePosition"></param>
    public void UpdateSelectionBox(Vector2 currentMousePosition)
    {
        float selectionBoxWidth = currentMousePosition.x - mouseStartPosition.x;
        float selectionBoxHeight = currentMousePosition.y - mouseStartPosition.y;
        rectTransform.sizeDelta = new Vector2(Mathf.Abs(selectionBoxWidth), Mathf.Abs(selectionBoxHeight));
        rectTransform.anchoredPosition = mouseStartPosition + new Vector2(selectionBoxWidth / 2, selectionBoxHeight / 2);
    }

    /// <summary>
    /// Enable selection box
    /// </summary>
    public void ActivateSelectionBox()
    {
        if (!rectTransform.gameObject.activeInHierarchy)
        {
            rectTransform.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// Disable selection box
    /// </summary>
    public void DeactivateSelectionBox()
    {
        if (rectTransform.gameObject.activeInHierarchy)
        {
            rectTransform.gameObject.SetActive(false);
        }
    }
}
