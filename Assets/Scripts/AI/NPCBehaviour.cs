using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPCBehaviour : ScriptableObject {

    public bool IsMoving { get; protected set; }

    public abstract bool ExtraStoppingCondition { get; } //The behavior will be continued upon the absense of triggers, until the stopping condition has been met.

    private void OnEnable()
    {
        IsMoving = false;
    }

    /// <summary>
    /// Called when the target has first changed.
    /// </summary>
    /// <param name="npc"></param>
    /// <param name="target"></param>
    public abstract void Plan(NPCAI npc, Scannable target);

    /// <summary>
    /// Called each time information about the target being responded to has changed.
    /// </summary>
    /// <param name="npc"></param>
    /// <param name="target"></param>
    public abstract void Adjust(NPCAI npc, Scannable target);

    /// <summary>
    /// Describes a frame of the behaviour.
    /// </summary>
    /// <param name="instigator"></param>
    public abstract void Act(NPCAI npc, Scannable target);

    /// <summary>
    /// Called when a target of another type is found - perform operations to cleanly stop current behaviour.
    /// </summary>
    /// <param name="npc"></param>
    /// <param name="target"></param>
    public abstract void Cease(NPCAI npc, Scannable target);

}
