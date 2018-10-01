using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargedItem : MonoBehaviour {

    public float charge = 1;

    public void UpdateColor() {
        Color color = charge > 0 ? Color.green : Color.red;
        GetComponent<Renderer>().material.color = color;
    }

	void Start () {
        UpdateColor();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
