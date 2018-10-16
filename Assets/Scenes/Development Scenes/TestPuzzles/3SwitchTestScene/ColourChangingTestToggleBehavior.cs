using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ColourChangingTestToggleBehavior : ToggleBehaviour {

    private bool on;

    [SerializeField] Material offMat;
    [SerializeField] Material onMat;

    private void Start()
    {
        GetComponent<Renderer>().material = offMat;
    }

    public override void Toggle()
    {
        if (on)
        {
            GetComponent<Renderer>().material = offMat;
            on = false;
        }
        else
        {
            GetComponent<Renderer>().material = onMat;
            on = true;
        }
    }
}
