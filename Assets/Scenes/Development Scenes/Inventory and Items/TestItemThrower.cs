using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A generic driver for an item thrower.
/// </summary>
public class TestItemThrower : MonoBehaviour {

    [SerializeField] Transform player;
    [SerializeField] ItemThrower thower;
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButton(0))thower.Use(player);
	}
}
