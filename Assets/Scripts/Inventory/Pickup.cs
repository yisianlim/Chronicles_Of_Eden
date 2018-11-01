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

    private Animator representationAnimator;

    private void Awake()
    { 
        representationAnimator = inGameRepresentation.GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        //Do not do anyting if the intended key is being pressed.
        if (Input.GetAxis(INTERACTION_AXIS) == 0) return;

        //Do not do anything if the object in the trigger is no meant to use the pickup.
        if (!other.gameObject.Equals(user)) return;

        //Disable the collider so it only fires once.
        GetComponent<Collider>().enabled = false;

        // Begin opening treasure box and then adding the item to player's inventory.
        StartCoroutine(OpenTreasureBoxRoutine());

        // Disable trigger.
        enabled = false;
    }

    /// <summary>
    /// Wait for 1.5 seconds between adding the item to the player's
    /// inventory. Ensures that the animation is completed first, before 
    /// the item is displayed in the UI.
    /// </summary>
    IEnumerator OpenTreasureBoxRoutine(){
        representationAnimator.SetBool("Open", true);
        yield return new WaitForSeconds(1.5f);
        FindObjectOfType<AudioManager>().Play("Pickup");
        inventory.AddItem(pickup);
    }

}
