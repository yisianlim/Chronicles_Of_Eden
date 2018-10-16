using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomingFocusingCamera : FocusingCamera {

    const float MAX_SCROLL_SENSITIVITY = 1000;

    [SerializeField] [Range(0, MAX_SCROLL_SENSITIVITY)] float scrollSensitivity;
    [SerializeField] float minDistance;
    [SerializeField] float maxDistance;
    [SerializeField] float minAngleFromPlayer;
    [SerializeField] float maxAngleFromPlayer;

    private float currentScrollPoint = 0.5f;

    private void Update()
    {

        float zoomSpeed = Input.GetAxis("Mouse ScrollWheel");

        currentScrollPoint = Mathf.Clamp((scrollSensitivity / MAX_SCROLL_SENSITIVITY) * zoomSpeed, 0, 1);
        distanceFromTarget = Mathf.Lerp(minDistance, maxDistance, currentScrollPoint);

    }

    

}
