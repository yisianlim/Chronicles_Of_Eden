using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Animator))]
public class PressurePlate : MonoBehaviour {

    private Animator animator;
    private int numberOnPlate;

    [SerializeField] ToggleBehaviour behaviour; //The behaviour the pressure plate affects.

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log(other.name + " entered!");

        if (numberOnPlate > 0) return; //Do not react if it is already being pressed by something else.

        Debug.Log("Pressing");

        animator.SetBool("On", true);
        numberOnPlate++;
        behaviour.Toggle();
        
    }


    private void OnTriggerExit(Collider other)
    {

        if (numberOnPlate > 1) return; //Ensure the is nothing on the pressure plate.

        animator.SetBool("On", false);
        numberOnPlate--;
        behaviour.Toggle();

    }

}
