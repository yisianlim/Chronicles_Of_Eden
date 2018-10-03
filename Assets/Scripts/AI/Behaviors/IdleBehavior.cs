using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A behavior in which the enemy does nothing
/// </summary>
[CreateAssetMenu(fileName = "Idle Behaviour", menuName = "NPC AI/Behaviors/Idle", order = 3)]
public class IdleBehavior : NPCBehaviour
{
    public override void Act(NPCAI npc, Scannable target) {}

    public override void Adjust(NPCAI npc, Scannable target){}

    public override void Cease(NPCAI npc, Scannable target) {}

    public override void Plan(NPCAI npc, Scannable target){}
}
