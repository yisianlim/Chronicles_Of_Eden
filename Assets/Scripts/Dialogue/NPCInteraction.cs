using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour {

    public GameObject player;
    private bool hasInteracted;
    public Animator anim;

    void Awake() {
        anim.SetInteger("Condition", 0);
    }
	void Update () {
        if (Interacted())
        {
            BeginInteraction();
        }
	}

    /// <summary>
    /// Check if the player is close enough for an interaction. 
    /// Returns true if we want to trigger a dialogue. False otherwise. 
    /// </summary>
    bool Interacted() {
        if (Vector3.Distance(transform.position, player.transform.position) < 1 && !hasInteracted)
        {   
            return true;
        }
        return false;
    }

    /// <summary>
    /// Begin the interaction between the player and NPC. 
    /// </summary>
    void BeginInteraction() {
        hasInteracted = true;
        GetComponent<DialogueTrigger>().TriggerDialogue();
        anim.SetInteger("Condition", 1);
    }
}
