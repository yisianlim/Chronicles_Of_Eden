using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Can be applied to an object with a collider component acting as trigger to have the player 'pick up' and item when they are pressing the
/// correct key while within the trigger.
/// </summary>
public class Pickup : MonoBehaviour {

    public const string INTERACTION_AXIS = "Interact";

    [SerializeField] GameObject user; //The game object that can interact with this pickup.
    [SerializeField] GameObject inGameRepresentation; //The game object representing the object to be picked up.
    [SerializeField] EquipableItem pickup; //The item that will be added to the inventory.
    [SerializeField] Inventory inventory; //The inventory the item will be added to.

    private void OnTriggerStay(Collider other)
    {

        //Do not do anyting if the intended key is being pressed.
        if (Input.GetAxis(INTERACTION_AXIS) == 0) return;

        //Do not do anything if the object in the trigger is no meant to use the pickup.
        if (!other.gameObject.Equals(user)) return;

        inventory.AddItem(pickup);

        //Hide representation from world, and disable trigger.
        inGameRepresentation.SetActive(false);
        enabled = false;

    }
}
