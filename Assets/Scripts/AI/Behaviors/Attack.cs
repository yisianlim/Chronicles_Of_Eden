using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack Behaviour", menuName = "NPC AI/Behaviors/Attack", order = 1)]
public class Attack : NPCBehaviour
{

    public override bool ExtraStoppingCondition
    {
        get
        {
            return true;
        }
    }

    public override void Plan(NPCAI npc, Scannable target)
    {
        SetAttackTarget(npc, target.gameObject);
    }

    public override void Adjust(NPCAI npc, Scannable target)
    {
        //NA
    }

    public override void Act(NPCAI npc, Scannable target)
    {
        //NA
    }

    public override void Cease(NPCAI npc, Scannable target)
    {
        SetAttackTarget(npc, null);
    }

    private void SetAttackTarget(NPCAI npc, GameObject target)
    {

        AttackAnimationEventHandler handler = npc.GetComponent<AttackAnimationEventHandler>();
        if (handler == null)
            throw new System.Exception("The npc " + npc.name + " does not have an AttackAnimationEventHandler attatched.");

        handler.target = target;

    }
}
