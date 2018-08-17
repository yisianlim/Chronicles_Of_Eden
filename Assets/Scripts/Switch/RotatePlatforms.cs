using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatforms : ToggleBehaviour {

    public bool toggleRotate = false;

    public override void Toggle()
    {
        toggleRotate = true;
    }

    void Update () {
        if (toggleRotate && transform.eulerAngles.z > 270 || transform.eulerAngles.z <= 0)
        {
            transform.Rotate(0, 0, -1);
        }
	}
}
