using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allows a camera to be locked onto a player and rotated left and right using the mouse.
/// </summary>
public class MouseControlledCamera : MonoBehaviour {

    [SerializeField] private Transform focusObject;
	[SerializeField] private bool lockOntoObject;

	public float distanceFromPlayer;
	public float angleFromPlayer;
	public float baseY; //The y value the camera will be locked on to.

	private Camera camera;

	void Start(){

		camera = GetComponent<Camera>();

		transform.parent = focusObject.parent; //Ensure camera is in the same level as its chosen object in the hireachy.

	}

	void Update(){
		
	}

	private void lockOn(){

	}

}
