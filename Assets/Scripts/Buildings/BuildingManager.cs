using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    [field: SerializeField] public List<Building> Buildings { get; private set; }

    private void OnEnable()
    {
        EventManager.StartListening("OnBuildingButtonClick", OnAddBuildingToWorld);
    }

    private void OnDisable()
    {
        EventManager.StopListening("OnBuildingButtonClick", OnAddBuildingToWorld);
    }

    /// <summary>
    /// Add building to the world
    /// </summary>
    /// <param name="message"></param>
    private void OnAddBuildingToWorld(Dictionary<string, object> message)
    {
        Building_SO building_SO = (Building_SO)message["building_SO"];

        for (var i = 0; i < Buildings.Count; i++)
        {
            if (Buildings[i].buildingData.Equals(building_SO))
            {
                Buildings[i].gameObject.SetActive(true);
                EventManager.TriggerEvent("OnBuildingToPlace", new Dictionary<string, object> { { "building", Buildings[i].gameObject } });
            }
        }
    }

    /// <summary>
    /// Get the closes storage building position
    /// </summary>
    /// <param name="targetTransform"></param>
    /// <returns></returns>
    public Vector3 GetClosestStoragePosition(Transform targetTransform)
    {
        Vector3 closestStoragePosition = Vector3.zero;
        float smallestDistance = 0;
        bool firstSmallestDistanceSet = false;

        for (var i = 0; i < Buildings.Count; i++)
        {
            if (Buildings[i].TryGetComponent(out BuildingStorage buildingStorage))
            {
                if (!firstSmallestDistanceSet)
                {
                    smallestDistance = buildingStorage.GetDistance(targetTransform);
                    closestStoragePosition = buildingStorage.transform.position;
                    firstSmallestDistanceSet = true;
                }
                else
                {
                    if (buildingStorage.GetDistance(targetTransform) < smallestDistance)
                    {
                        smallestDistance = buildingStorage.GetDistance(targetTransform);
                        closestStoragePosition = buildingStorage.transform.position;
                    }
                }
            }
        }

        return closestStoragePosition;
    }
}
