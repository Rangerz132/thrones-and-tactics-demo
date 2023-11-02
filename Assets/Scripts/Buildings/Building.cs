using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour, IEntity
{
    [SerializeField] private GameObject buildingVisual;
    [SerializeField] private Sprite buildingIcon;
    [field: SerializeField] public Building_SO buildingData;
    [field: SerializeField] public HealthVisual HealthVisual { get; private set; }

    void Start()
    {
        HealthVisual.InitializeHealth(buildingData.health);
    }

    public void OnClick()
    {
        HealthVisual.PlaySelectAnimation();
    }

    public void OnRelease()
    {
        HealthVisual.PlayUnselectAnimation();
    }
}
