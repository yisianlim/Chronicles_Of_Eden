using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move Towards Behaviour", menuName = "NPC AI/Behaviors/Movement/Move Towards", order = 1)]
public class MoveTowards : NPCBehaviour
{

    [SerializeField] float movementSpeed;
    [SerializeField] float turnSpeed;
    private NPCAnimator enemyAnimator;

    public override bool ExtraStoppingCondition
    {
        get
        {
            return true;
        }
    }

    public override void Plan(NPCAI npc, Scannable target)
    {
        //No need to plan.
    }

    public override void Adjust(NPCAI npc, Scannable target)
    {
        //No need to adjust.
    }

    public override void Act(NPCAI npc, Scannable target)
    {
        //Move towrds the target on the x and z axes, but not the y axis.
        Vector3 targetPosition = new Vector3(target.transform.position.x, npc.transform.position.y, target.transform.position.z);
        MoveNPCTowardsPosition(npc, targetPosition, movementSpeed, turnSpeed);

    }

    public static void MoveNPCTowardsPosition(NPCAI npc, Vector3 targetPosition, float movementSpeed, float turnSpeed)
    {
        //Move the npc a step towards the target.
        npc.transform.position = Vector3.MoveTowards(npc.transform.position, targetPosition, movementSpeed * Time.deltaTime);

        //Turn the npc towards the target.
        TurnTowards.Turn(targetPosition, npc.transform, turnSpeed);

    }

    public override void Cease(NPCAI npc, Scannable target)
    {
        //NA
    }

}
