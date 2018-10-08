using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An NPCAI that can be set to different states, for which the NPC has different reactions to different stimuli.
/// </summary>
public class MultiStateNPCAI : NPCAI {

    private AIState currentState; 

    [SerializeField] string initialState;
    [SerializeField] AIState[] states;

    private void Start()
    {
        currentState = GetStateWithName(initialState);
    }

    protected override Reaction[] CurrentReactions
    {
        get{ return currentState.associatedReactions;}
    }

    /// <summary>
    /// Change the state of the AI.
    /// </summary>
    public string State { set { currentState = GetStateWithName(value); } }

    /// <summary>
    /// Find the state with the given name.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    private AIState GetStateWithName(string name)
    {

        foreach(AIState state in states)
        {
            if (state.name.Equals(name)) return state;
        }

        throw new Exception("Given state '" + name + "' does not exist.");

    }

    /// <summary>
    /// A named collection of reations, in order of priority.
    /// </summary>
    [Serializable]
	protected class AIState
    {
        public string name;
        public Reaction[] associatedReactions;
    }

}
