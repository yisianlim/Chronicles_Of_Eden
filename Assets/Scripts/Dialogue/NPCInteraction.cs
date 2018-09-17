using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour {

    // The dialogue that this NPC will have.
    public string[] dialogue;

    // The name of this NPC.
    public string name;

    public GameObject player;
    private bool hasInteracted;
	
	void Update () {
        if (Interacted()) {
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
        DialogueSystem.Instance.AddNewDialogue(this);
    }
}
