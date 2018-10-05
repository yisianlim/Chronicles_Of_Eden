using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Animator))]
public class PressurePlate : ExternallyTriggerable {

    private Animator animator;
    private int numberOnPlate;

    [SerializeField] ToggleBehaviour behaviour; //The behaviour the pressure plate affects.

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public override void TriggerEntered(Collider other)
    {

        Debug.Log(other.name + " entered!");

        if (numberOnPlate > 0) return; //Do not react if it is already being pressed by something else.

        Debug.Log("Pressing");

        animator.SetBool("On", true);
        numberOnPlate++;
        behaviour.Toggle();
        
    }


    public override void TriggerExited(Collider other)
    {

        if (numberOnPlate > 1) return; //Ensure the is nothing on the pressure plate.

        animator.SetBool("On", false);
        numberOnPlate--;
        behaviour.Toggle();

    }

}
