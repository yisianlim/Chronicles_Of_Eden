using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A generic driver for an item thrower.
/// </summary>
public class TestItemThrower : MonoBehaviour {

    [SerializeField] Transform player;
    [SerializeField] ItemThrower thower;

    float count = 0;
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButton(0) && count <= 0)
        {
            thower.Use(player, null);
            count = 0.5f;
        }

        count -= Time.deltaTime;
	}
}
