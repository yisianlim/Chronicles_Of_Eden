using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Solved!");
    }

}
