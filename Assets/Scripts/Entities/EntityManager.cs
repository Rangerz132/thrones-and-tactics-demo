using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    [SerializeField] private List<IEntity> entities = new List<IEntity>();

    private void Update()
    {
        // Left click
        if (Input.GetMouseButtonDown(0))
        {
            AddEntityFromSingleClick();
        }
    }

    /// <summary>
    /// Base method to add unit(s)
    /// </summary>
    /// <param name="hit"></param>
    private void AddEntities(RaycastHit hit)
    {
        if (hit.collider.TryGetComponent<IEntity>(out IEntity entity))
        {
            if (!entities.Contains(entity))
            {
                entities.Add(entity);

                for (var i = 0; i < entities.Count; i++)
                {
                    entities[i].OnClick();
                }
            }
        }
    }

    /// <summary>
    /// Add one unit to the unit list
    /// </summary>
    private void AddEntityFromSingleClick()
    {
        ClearEntities();

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            AddEntities(hit);
        }
    }

    /// <summary>
    /// Remove every entity in the entity list
    /// </summary>
    private void ClearEntities()
    {
        for (var i = 0; i < entities.Count; i++)
        {
            entities[i].OnRelease();
        }

        entities.Clear();
    }
}
