using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Animator))]
public class PressurePlate : ExternallyTriggerable {

    private Animator animator;
    private float weightOnPlate;
    bool beingPressed = false;

    [SerializeField] float weightThreshold; //The weight required to trigger the plate.
    [SerializeField] ToggleBehaviour behaviour; //The behaviour the pressure plate affects.

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public override void TriggerEntered(Collider other)
    {

        weightOnPlate += GetWeightOf(other.gameObject);
        if (beingPressed || weightOnPlate < weightThreshold) return;

        animator.SetBool("On", true);
        beingPressed = true;
        behaviour.Toggle();
        
    }


    public override void TriggerExited(Collider other)
    {
        weightOnPlate -= GetWeightOf(other.gameObject);
        if (!beingPressed || weightOnPlate >= weightThreshold) return; //Ensure the is nothing on the pressure plate.

        animator.SetBool("On", false);
        beingPressed = false;
        behaviour.Toggle();

    }

    /// <summary>
    /// Returns the weight of an object, if it has a weighted component attached.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    private float GetWeightOf(GameObject obj)
    {

        WeightedObject objectWeight = obj.GetComponent<WeightedObject>();
        if (objectWeight == null) return 0;
        else return objectWeight.Weight;

    }

}
