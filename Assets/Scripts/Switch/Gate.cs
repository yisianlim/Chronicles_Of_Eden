using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Gate : ToggleBehaviour {

    private Animator anim;

    [SerializeField] bool open;
    [SerializeField] RuntimeAnimatorController openGateController;
    [SerializeField] RuntimeAnimatorController closeGateContoller;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Open", open);
    }

    public override void Toggle()
    {

        open = !open;
        if (open) anim.runtimeAnimatorController = openGateController;
        else anim.runtimeAnimatorController = closeGateContoller;
        anim.SetBool("Open", open);


    }

}
