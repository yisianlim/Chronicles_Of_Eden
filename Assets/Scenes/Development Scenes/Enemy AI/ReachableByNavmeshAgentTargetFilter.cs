using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Filters out targets that can be reached by using the NavMesh.
/// </summary>
[CreateAssetMenu(fileName = "Reachable By Navmesh Agent Filter", menuName = "NPC AI/Target/Filter/Reachable By NavMesh Agent", order = 1)]
public class ReachableByNavmeshAgentTargetFilter : TargetFilter
{

    const float POINT_TOLERANCE = 1f;

    public override bool IsValidTarget(Scannable target, NPCAI npc)
    {

        //Find where the target and NPC are on the NavMesh.
        NavMeshHit npcPosition;
        NavMeshHit targetPosition;
        NavMesh.SamplePosition(npc.transform.position, out npcPosition, POINT_TOLERANCE, NavMesh.AllAreas);
        NavMesh.SamplePosition(target.transform.position, out targetPosition, POINT_TOLERANCE, NavMesh.AllAreas);

        if (targetPosition.position.Equals(new Vector3(Mathf.Infinity, Mathf.Infinity, Mathf.Infinity))) return false;

        //Try to find a path between the two points and return whether is is successful.
        NavMeshPath path = new NavMeshPath();
        NavMesh.CalculatePath(npcPosition.position, targetPosition.position, NavMesh.AllAreas, path);
        return path.status == NavMeshPathStatus.PathComplete;
    }
}
