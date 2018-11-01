using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A camera that can be set to focus on an object, and whos angle and distance can be set in relation to that object.
/// </summary>
public class FocusingCamera : MonoBehaviour {

    const float YRotationOffset = 90;

    [SerializeField] protected Transform focusObject;
    [SerializeField] protected bool lockOntoObject;

    [SerializeField] protected float distanceFromTarget;
    [SerializeField] [Range(0, 90)] protected float angleFromTarget; //The angle at which the camera is looking at the player.
    [SerializeField] [Range(0, 360)] protected float angleAroundTarget; //Where the player is around the circle. The mouse will control this.
    [SerializeField] protected float orthographicSize; // The viewing volume you'd like the orthographic Camera to pick up.
    [SerializeField] [Range(0, 360)] protected float desiredRotation;
    [SerializeField] public float rSpeed = 1.0f;
    [SerializeField] const float rotationAmount = 1.5f;

    void Start()
    {
        Camera.main.orthographicSize = orthographicSize;

        transform.parent = focusObject.parent; //Ensure camera is in the same level as its chosen object in the hireachy.

    }

    void Update()
    {
        UpdateCameraPosition();
    }

    protected void UpdateCameraPosition()
    {
        if (!lockOntoObject) return;

        if (desiredRotation > angleAroundTarget) {
            angleAroundTarget += rotationAmount;
        } else if (desiredRotation < angleAroundTarget) {
            angleAroundTarget -= rotationAmount;
        }

        /* Conversions to radians for Mathf trig functions. */
        float angleFromTargetInRadians = Mathf.Deg2Rad * angleFromTarget;
        float angleAroundTargetInRadians = Mathf.Deg2Rad * angleAroundTarget;

        /* Basic trig, finding the length of the opposite side (vertical distance of camera from player) based on given angle and distance.*/
        float cameraHeight = focusObject.transform.position.y + Mathf.Sin(angleFromTargetInRadians) * distanceFromTarget;

        /* Find the horizontal distance of camera from the target, then use that to determine its x and y based its angle around the player.*/
        float cameraRadius = Mathf.Cos(angleFromTargetInRadians) * distanceFromTarget;
        float cameraX = focusObject.transform.localPosition.x + Mathf.Cos(angleAroundTargetInRadians) * cameraRadius;
        float cameraZ = focusObject.transform.localPosition.z + Mathf.Sin(angleAroundTargetInRadians) * cameraRadius;

        transform.localPosition = new Vector3(cameraX, cameraHeight, cameraZ);
        transform.localEulerAngles = new Vector3(angleFromTarget, -angleAroundTarget - YRotationOffset, transform.localEulerAngles.z);

    }

    public void RotateCamera(int rotation) {
        desiredRotation += rotation;
    }
}
