using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class CameraZoom : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtual;

    [Header("Zoom Smoothness")]
    [SerializeField] private float damping;
    [SerializeField] private float smoothSpeed;

    [Header("Zoom Clamp")]
    [SerializeField] private float minZoom;
    [SerializeField] private float maxZoom;
    [SerializeField] private float zoom;
    [Range(0,1)]
    [SerializeField] private float t;

    private void Start()
    {
        cinemachineVirtual.m_Lens.OrthographicSize = zoom;
    }

    private void Update()
    {
        HandleZoom();
    }

    /// <summary>
    /// Change camera fov based on mouse scroll delta
    /// </summary>
    private void HandleZoom()
    {
        t = Mathf.Clamp01(t - System.Math.Sign(Input.mouseScrollDelta.y) * Time.deltaTime * damping);
        zoom = Mathf.Lerp(minZoom, maxZoom, t);
        cinemachineVirtual.m_Lens.OrthographicSize = Mathf.Lerp(cinemachineVirtual.m_Lens.OrthographicSize, zoom, Time.deltaTime * smoothSpeed);
    }
}
