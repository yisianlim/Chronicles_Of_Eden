using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A toggle behavior that also changes the states of the given npcs when activated.
/// </summary>
public class StateChangeToggleBehavior : ToggleBehaviour
{

    [SerializeField] ToggleBehaviour baseBehavior;
    [Header("State Change")]
    [SerializeField] MultiStateNPCAI[] AIs;
    [SerializeField] string newState;

    public override void Toggle()
    {
        baseBehavior.Toggle();
        foreach (MultiStateNPCAI ai in AIs)
            ai.State = newState;
    }
}
