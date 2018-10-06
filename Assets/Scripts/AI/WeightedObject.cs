using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An object that has a weight that can be taken into account in puzzles.
/// </summary>
public class WeightedObject : MonoBehaviour {

    [SerializeField] float weight;
    public float Weight { get { return weight; } }

}
