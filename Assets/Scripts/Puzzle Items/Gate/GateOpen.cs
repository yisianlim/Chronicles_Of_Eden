using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpen : ToggleBehaviour {

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Open", false);
    }

    public override void Toggle()
    {
        anim.SetBool("Open", true);
    }

}
