using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Detects the use of the mouse and provide delegates so that other components can react.
/// </summary>
public class MouseInputManager : MonoBehaviour {

    public delegate void MouseMovement(float deltaX, float deltaY, float deltaZ);
    public MouseMovement mouseMoved;

    private Vector3 previousMousePosition;

    private void Start()
    {
        previousMousePosition = Input.mousePosition;
    }

    void Update () {

        Vector3 currentMousePosition = Input.mousePosition;
        if (!currentMousePosition.Equals(previousMousePosition))
        {
            if(mouseMoved != null)
            {

                float deltaX = currentMousePosition.x - previousMousePosition.x;
                float deltaY = currentMousePosition.y - previousMousePosition.y;
                float deltaZ = currentMousePosition.z - previousMousePosition.z;

                mouseMoved(deltaX, deltaY, deltaZ);

            }
        }

        previousMousePosition = currentMousePosition;

	}
}
