using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastUtility : MonoBehaviour
{
    public static Vector3 MouseToTerrainPosition()
    {
        Vector3 position = Vector3.zero;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit info, 100, LayerMask.GetMask("Terrain"))) 
        {
            position = info.point;
        }
            
        return position;
    }
}
