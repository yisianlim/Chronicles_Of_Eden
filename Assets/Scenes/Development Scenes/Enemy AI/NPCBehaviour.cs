using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPCBehaviour : ScriptableObject {

    /// <summary>
    /// Describes a frame of the behaviour.
    /// </summary>
    /// <param name="instigator"></param>
    public abstract void Act(NPCAI npc, Scannable target);

}
