using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingStorage : MonoBehaviour
{
    public float GetDistance(Transform targetTransform) 
    {
        return Vector3.Distance(transform.position, targetTransform.position);
    }
}
