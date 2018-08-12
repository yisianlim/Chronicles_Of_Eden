using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPCBehaviour : ScriptableObject {

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

}
