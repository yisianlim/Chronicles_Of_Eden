using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Gate : ToggleBehaviour {

    private Animator anim;

    [SerializeField] bool open;
    [SerializeField] RuntimeAnimatorController openGateController;
    [SerializeField] RuntimeAnimatorController closeGateContoller;

    [SerializeField] AudioClip gateClip;

    void Start() {
        anim = GetComponent<Animator>();
        anim.SetBool("Open", open);
        //anim.runtimeAnimatorController = openGateController;
    }

    public override void Toggle() {
        Debug.Log("Toggle");

        GetComponent<AudioSource>().PlayOneShot(gateClip);

        open = !open;
        anim.speed = 1;
        if (open) {
            //if (anim.GetCurrentAnimatorStateInfo(0).IsName("Close") ) {
            anim.runtimeAnimatorController = openGateController;
            //}
            //else { anim.speed = -1; }
            //anim.runtimeAnimatorController = openGateController;
        } else {
            //if (anim.GetCurrentAnimatorStateInfo(0).IsName("Open")) {
            anim.runtimeAnimatorController = closeGateContoller;
            //    }
            //    else { anim.speed = -1; }
            //}
            //anim.SetBool("Open", open);
        }

    }
}
