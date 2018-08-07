using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A small detonatable object that immediatly begins detonation when instantiated.
/// </summary>
public class Bomb : Detonatable {

	void Start () {
        Detonate();
	}
	
}
