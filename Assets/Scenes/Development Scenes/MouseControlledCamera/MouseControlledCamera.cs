using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allows a camera to be locked onto a player and rotated left and right using the mouse.
/// </summary>
public class MouseControlledCamera : MonoBehaviour {

    [SerializeField] private Transform focusObject;
	[SerializeField] private bool lockOntoObject;

	[SerializeField] float distanceFromTarget;
	[SerializeField] [Range(0, 90)] float angleFromTarget; //The angle at which the camera is looking at the player.
    [SerializeField] [Range(0, 360)] float angleAroundTarget; //Where the player is around the circle. The mouse will control this.
	public float baseY; //The y value the camera will be locked on to.

	void Start(){

		transform.parent = focusObject.parent; //Ensure camera is in the same level as its chosen object in the hireachy.

	}

	void Update(){

        float angleFromTargetInRadians = Mathf.Deg2Rad * angleFromTarget;
        float angleAroundTargetInRadians = Mathf.Deg2Rad * angleAroundTarget;

        /* Basic trig, finding the length of the opposite side (vertical distance of camera from player) based on given angle and distance.*/
        float cameraHeight = baseY + Mathf.Sin(angleFromTargetInRadians) * distanceFromTarget;

        /* Find the horizontal distance of camera from the target, then use that to determine its x and y based its angle around the player.*/
        float cameraRadius = Mathf.Cos(angleFromTargetInRadians) * distanceFromTarget;
        float cameraX = focusObject.transform.localPosition.x + Mathf.Cos(angleAroundTarget) * cameraRadius;
        float cameraZ = focusObject.transform.localPosition.z + Mathf.Sin(angleAroundTarget) * cameraRadius;

        transform.localPosition = new Vector3(cameraX, cameraHeight, cameraZ);
        transform.localEulerAngles = new Vector3(-angleFromTarget, -angleAroundTarget, transform.localRotation.y);

	}

	private void lockOn(){

	}

}
