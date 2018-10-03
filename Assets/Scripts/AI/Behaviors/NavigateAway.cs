using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Navigate Away Behaviour", menuName = "NPC AI/Behaviors/Movement/Navigate Away", order = 4)]
public class NavigateAway : NPCBehaviour
{

    [SerializeField] float avoidDistance;

    public override void Plan(NPCAI npc, Scannable target)
    {

        float distance = Vector3.Distance(npc.transform.position, target.transform.position);

        //if scary thing is within avoid set new path directly away from scary thing
        if (distance < avoidDistance)
        {
            Vector3 dirToScare = npc.transform.position - target.transform.position;

            npc.GetComponent<NavMeshAgent>().SetDestination(npc.transform.position + dirToScare);

        }

    }

    public override void Act(NPCAI npc, Scannable target)
    {
        NavMeshAgent agent = npc.GetComponent<NavMeshAgent>();
        IsMoving = !agent.isStopped;
    }

    public override void Adjust(NPCAI npc, Scannable target)
    {
        Plan(npc, target);
    }

    public override void Cease(NPCAI npc, Scannable target)
    {
        

    }

}