using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public enum PanType
{
    Mouse,
    Keyboard
}

public class CameraPan : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtual;
    [SerializeField] private PanType panType;
    [SerializeField] private float panSpeed;
    [SerializeField] private float minScreenBoundary;
    [SerializeField] private float maxScreenBoundary;
    private delegate Vector3 MovementDirection();
    private MovementDirection movementDirection;

    private void Start()
    {
        switch (panType)
        {
            case PanType.Keyboard:
                movementDirection = GetKeyboardDirection;
                break;
            case PanType.Mouse:
                movementDirection = GetMouseDirection;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Pan();
    }

    /// <summary>
    /// Get the mouse position converted in a Vector2
    /// </summary>
    /// <returns></returns>
    public Vector2 GetMouseScreenPosition()
    {
        Vector2 mouseScreenPosition = Vector2.zero;

        mouseScreenPosition.x = Input.mousePosition.x;
        mouseScreenPosition.y = Input.mousePosition.y;

        return mouseScreenPosition;
    }

    /// <summary>
    /// Get the direction based on the keyboard
    /// </summary>
    /// <returns></returns>
    public Vector3 GetKeyboardDirection()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            direction.x = -1;
            direction.z = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direction.x = 1;
            direction.z = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direction.x = 1;
            direction.z = -1;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            direction.x = -1;
            direction.z = 1;
        }

        return direction;
    }

    /// <summary>
    /// Get the direction based on the mouse position
    /// </summary>
    /// <returns></returns>
    public Vector3 GetMouseDirection()
    {
        Vector3 direction = Vector3.zero;

        if (GetMouseScreenPosition().x < Screen.width * minScreenBoundary)
        {
            direction.x = -1;
            direction.z = -1;
        }
        else if (GetMouseScreenPosition().x > Screen.width * maxScreenBoundary)
        {
            direction.x = 1;
            direction.z = 1;
        }
        else if (GetMouseScreenPosition().y < Screen.height * minScreenBoundary)
        {
            direction.x = 1;
            direction.z = -1;
        }
        else if (GetMouseScreenPosition().y > Screen.height * maxScreenBoundary)
        {
            direction.x = -1;
            direction.z = 1;
        }

        return direction;
    }

    /// <summary>
    /// Move the camera
    /// </summary>
    public void Pan()
    {
        Vector3 direction = movementDirection();
        transform.position = Vector3.Lerp(transform.position, transform.position + direction, panSpeed * Time.deltaTime);
    }
}
