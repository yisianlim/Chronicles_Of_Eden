using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    public Animator anim;
    public ToggleBehaviour behaviour;

    private void Awake()
    {
        anim.SetBool("On", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        anim.SetBool("On", true);
        behaviour.Toggle();
        Debug.Log("Solved!");
    }

}
