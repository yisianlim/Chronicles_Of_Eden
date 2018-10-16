using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Can be applied to a target selector to filter out targets that aren't relevant.
/// </summary>
public abstract class TargetFilter : ScriptableObject{

    public abstract bool IsValidTarget(Scannable target, NPCAI npc);

}
