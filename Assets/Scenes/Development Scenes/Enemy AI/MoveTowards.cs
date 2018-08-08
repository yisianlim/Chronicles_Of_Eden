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

        //Move the npc a step towards the target.
        npc.transform.position = Vector3.MoveTowards(npc.transform.position, target.transform.position, movementSpeed);


        //Turn the npc towards the target.
        Vector3 dir = target.transform.position - npc.transform.position;
        Vector3 rotation = Vector3.RotateTowards(npc.transform.forward, dir, turnSpeed, 0f);
        npc.transform.rotation = Quaternion.LookRotation(rotation);

    }

}
