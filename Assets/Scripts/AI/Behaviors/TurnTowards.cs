using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Turn Towards Behaviour", menuName = "NPC AI/Behaviors/Movement/Turn Towards", order = 5)]
public class TurnTowards : NPCBehaviour
{

    [SerializeField] float turnSpeed;

    public override bool ExtraStoppingCondition
    {
        get
        {
            return true;
        }
    }

    public override void Act(NPCAI npc, Scannable target)
    {
        Turn(target.transform.position, npc.transform, turnSpeed);
    }

    public static void Turn(Vector3 targetPosition, Transform transform, float turnSpeed)
    {

        Vector3 dir = targetPosition - transform.position;
        Vector3 rotation = Vector3.RotateTowards(transform.forward, dir, turnSpeed * Time.deltaTime, 0f);
        transform.rotation = Quaternion.LookRotation(rotation);

    }

    public override void Adjust(NPCAI npc, Scannable target)
    {
        
    }

    public override void Cease(NPCAI npc, Scannable target)
    {
        
    }

    public override void Plan(NPCAI npc, Scannable target)
    {
        
    }
}
