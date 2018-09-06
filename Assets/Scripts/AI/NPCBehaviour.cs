using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPCBehaviour : ScriptableObject {

    /*
     * If false, the behavior will not be ceased when no targets are detected.
     */
    [SerializeField] bool ceaseWhenNoTargets;
    public bool CeaseWhenNoTargets { get { return ceaseWhenNoTargets; } }

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
