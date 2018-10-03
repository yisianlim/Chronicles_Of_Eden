using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Moves a NavMeshAgent along the navmesh to the target.
/// </summary>
[CreateAssetMenu(fileName = "Navigate Towards Behaviour", menuName = "NPC AI/Behaviors/Movement/Navigate Towards", order = 3)]
public class NavigateTowards : NPCBehaviour
{

    public override void Act(NPCAI npc, Scannable target)
    {
        NavMeshAgent agent = npc.GetComponent<NavMeshAgent>();
        IsMoving = !agent.isStopped;
    }

    public override void Adjust(NPCAI npc, Scannable target)
    {
        NaviagteTowardsTarget(npc, target);
    }

    public override void Cease(NPCAI npc, Scannable target)
    {

        NavMeshAgent agent = npc.GetComponent<NavMeshAgent>();
        if (agent == null)
            throw new System.Exception(npc.name + " is trying to use the NavigateTowards behavour without having a NavMeshAgent");

        agent.ResetPath();

    }

    public override void Plan(NPCAI npc, Scannable target)
    {
        NaviagteTowardsTarget(npc, target);
    }

    /// <summary>
    /// Sets the NavMeshAgent destination to the position of the target, if it exists.
    /// </summary>
    /// <param name="npc"></param>
    /// <param name="target"></param>
    private void NaviagteTowardsTarget(NPCAI npc, Scannable target)
    {
        NavMeshAgent agent = npc.GetComponent<NavMeshAgent>();
        if (agent == null)
            throw new System.Exception(npc.name + " is trying to use the NavigateTowards behavour without having a NavMeshAgent");

        agent.SetDestination(target.transform.position);
    }
}
