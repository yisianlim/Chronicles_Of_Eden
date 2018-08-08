using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move Towards Behaviour", menuName = "NPC Behaviors/Movement/Move Towards", order = 1)]
public class MoveTowards : NPCBehaviour
{

    [SerializeField] float movementSpeed;
    [SerializeField] float turnSpeed;

    public override void Act(NPCAI npc, Scannable target)
    {

        //Move towrds the target on the x and z axes, but not the y axis.
        Vector3 targetPosition = new Vector3(target.transform.position.x, npc.transform.position.y, target.transform.position.z);

        //Move the npc a step towards the target.
        npc.transform.position = Vector3.MoveTowards(npc.transform.position, targetPosition, movementSpeed);


        //Turn the npc towards the target.
        Vector3 dir = targetPosition - npc.transform.position;
        Vector3 rotation = Vector3.RotateTowards(npc.transform.forward, dir, turnSpeed, 0f);
        npc.transform.rotation = Quaternion.LookRotation(rotation);

    }

}
