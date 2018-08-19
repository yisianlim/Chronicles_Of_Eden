using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    private Animator anim;
    public ToggleBehaviour behaviour;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("On", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        anim.SetBool("On", true);
        behaviour.Toggle();
        Debug.Log("Solved!");
    }

}
