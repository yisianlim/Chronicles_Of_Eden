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
    [SerializeField] protected float baseY; //The y value the camera will be locked on to.

    void Start()
    {

        Cursor.visible = false;

        transform.parent = focusObject.parent; //Ensure camera is in the same level as its chosen object in the hireachy.

    }

    void Update()
    {

        if (!lockOntoObject) return;

        /* Conversions to radians for Mathf trig functions. */
        float angleFromTargetInRadians = Mathf.Deg2Rad * angleFromTarget;
        float angleAroundTargetInRadians = Mathf.Deg2Rad * angleAroundTarget;

        /* Basic trig, finding the length of the opposite side (vertical distance of camera from player) based on given angle and distance.*/
        float cameraHeight = baseY + Mathf.Sin(angleFromTargetInRadians) * distanceFromTarget;

        /* Find the horizontal distance of camera from the target, then use that to determine its x and y based its angle around the player.*/
        float cameraRadius = Mathf.Cos(angleFromTargetInRadians) * distanceFromTarget;
        float cameraX = focusObject.transform.localPosition.x + Mathf.Cos(angleAroundTargetInRadians) * cameraRadius;
        float cameraZ = focusObject.transform.localPosition.z + Mathf.Sin(angleAroundTargetInRadians) * cameraRadius;

        transform.localPosition = new Vector3(cameraX, cameraHeight, cameraZ);
        transform.localEulerAngles = new Vector3(angleFromTarget, -angleAroundTarget - YRotationOffset, transform.localEulerAngles.z);

    }
}
