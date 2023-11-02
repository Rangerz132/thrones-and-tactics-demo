using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BuildingPlacement : MonoBehaviour
{
    [SerializeField] private Transform building;
    [SerializeField] private BuildingConstruction buildingConstruction;
    [SerializeField] private NavMeshObstacle navMeshObstacle;
    [SerializeField] private List<Renderer> buildingRenderers;
    [SerializeField] private Vector3 targetPosition;
    [SerializeField] private bool isPlaced;
    [SerializeField] private int collisionCount;
    private float rotationDuration = 0.1f;
    private Quaternion targetRotation;

    private void Start()
    {
        targetRotation = transform.rotation;
    }

    /// <summary>
    /// Position the building according to the mouse position
    /// </summary>
    public void PositionBuilding(Vector3 targetGridPosition)
    {
        if (isPlaced)
        {
            return;
        }

        targetPosition = targetGridPosition;
        transform.position = targetPosition;

        // Set final building position
        if (Input.GetMouseButtonDown(0))
        {
            if (IsPlacable())
            {
                IntegrateBuilding();
            }
            else
            {
                building.gameObject.SetActive(false);
            }
        }
    }

    /// <summary>
    /// Integrate the building to the world
    /// </summary>
    private void IntegrateBuilding()
    {
        transform.position = targetPosition;
        navMeshObstacle.enabled = true;
        navMeshObstacle.carving = true;
        isPlaced = true;

        for (var i = 0; i < buildingRenderers.Count; i++)
        {
            buildingRenderers[i].material.SetFloat("_IsPlaced", 1);
        }

        buildingConstruction.BuildingConstructionStateManager.ChangeState(buildingConstruction.BuildingConstructionInitializationState);

        EventManager.TriggerEvent("OnBuildingIntegrated", new Dictionary<string, object> { });
    }

    public IEnumerator Rotate90Deg()
    {
        float elapsedTime = 0f;
        targetRotation *= Quaternion.Euler(0, 90, 0);

        while (elapsedTime < rotationDuration)
        {
            elapsedTime += Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, (elapsedTime / rotationDuration));

            yield return new WaitForEndOfFrame();
        }
    }

    /// <summary>
    /// Check if the the building intersect with another entity
    /// </summary>
    /// <returns></returns>
    public bool IsPlacable()
    {
        return collisionCount == 0;
    }

    /// <summary>
    /// Change building material according to the position validity
    /// </summary>
    private void UpdateMaterialValidity()
    {
        for (var i = 0; i < buildingRenderers.Count; i++)
        {
            buildingRenderers[i].material.SetFloat("_IsValid", IsPlacable() ? 1 : 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent(out IEntity entity))
        {
            if (!isPlaced)
            {
                collisionCount++;
                UpdateMaterialValidity();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.TryGetComponent(out IEntity entity))
        {
            if (!isPlaced)
            {
                collisionCount--;
                UpdateMaterialValidity();
            }
        }
    }
}
