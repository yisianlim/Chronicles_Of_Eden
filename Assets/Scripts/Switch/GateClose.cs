using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateClose : ToggleBehaviour {

    private Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Open", true);
    }

    public override void Toggle()
    {
        anim.SetBool("Open", false);
    }



}
