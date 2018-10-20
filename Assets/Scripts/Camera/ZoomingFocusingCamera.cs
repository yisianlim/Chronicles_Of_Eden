using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomingFocusingCamera : FocusingCamera {

    const float MAX_SCROLL_SENSITIVITY = 1000;

    [SerializeField] [Range(0, MAX_SCROLL_SENSITIVITY)] float scrollSensitivity;
    [SerializeField] float minDistance;
    [SerializeField] float maxDistance;
    [SerializeField] float minAngleFromTarget;
    [SerializeField] float maxAngleFromTarget;

    private float currentScrollPoint = 0.5f;

    private void Update()
    {

        float zoomSpeed = Input.GetAxis("Mouse ScrollWheel");

        currentScrollPoint = Mathf.Clamp(currentScrollPoint - (scrollSensitivity / MAX_SCROLL_SENSITIVITY) * zoomSpeed, 0, 1);

        distanceFromTarget = Mathf.Lerp(minDistance, maxDistance, currentScrollPoint);
        angleFromTarget = Mathf.Lerp(minAngleFromTarget, maxAngleFromTarget, currentScrollPoint);

        UpdateCameraPosition();

    }

    

}
