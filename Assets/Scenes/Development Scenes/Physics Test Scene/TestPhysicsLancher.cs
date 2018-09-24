using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPhysicsLancher : MonoBehaviour {

    [SerializeField] Transform target;
    [SerializeField] float arcHeightDifference;
    [SerializeField] Rigidbody launchObject;

	// Use this for initialization
	void Update () {

        if (!Input.anyKeyDown) return;

        Rigidbody obj = Instantiate(launchObject, transform.position, transform.rotation);
        
        Vector3 vel = Calculations.DetermineRequiredLaunchToReachPoint(transform.position, target.position, arcHeightDifference).launchVelocity;
        Debug.Log(vel);
        obj.velocity = vel;
	}
}
