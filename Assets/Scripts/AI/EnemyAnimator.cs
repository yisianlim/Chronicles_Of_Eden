using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimator : MonoBehaviour {

    public Animator anim;
    private bool dying;

    public void Idle()
    {
        if (dying) return;
        anim.SetInteger("Condition", 0);
    }

    public void Running()
    {
        if (dying) return;
        anim.SetInteger("Condition", 1);
    }

    public void Attack() {
        if (dying) return;
        anim.SetInteger("Condition", 2);
    }

    public void Dies()
    {
        dying = true;
        anim.SetInteger("Condition", 3);
    }
}
