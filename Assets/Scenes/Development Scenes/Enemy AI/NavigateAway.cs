using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Navigate Away Behaviour", menuName = "NPC AI/Behaviors/Movement/Navigate Away", order = 4)]
public class NavigateAway : NPCBehaviour
{
    [SerializeField] float maxDistance; //The max distance the NPC can run to get away from the target.
    [SerializeField] float maxVerticalDistance; //The max vertical distance from origin the NPC will try go (up slopes).
    [SerializeField] float verticalDistanceCheckInc;
    [SerializeField] int adjustmentDirections; //The number of directions the NPC will try to go in unobstructed - evenly distributed around circle.

    public override void Plan(NPCAI npc, Scannable target)
    {

        NavMeshAgent agent = npc.GetComponent<NavMeshAgent>();
        if (agent == null)
            throw new System.Exception(npc.name + " is trying to use NavigateAway behavior without a NavMeshAgent component attatched.");

        HashSet<Vector3> reachablePoints = new HashSet<Vector3>();
        float angleSteps = 360f / adjustmentDirections;
        for (int i = 0; i < adjustmentDirections; i++)
        {

            //Find each point around the circle.
            Vector3 currentDirection = Quaternion.Euler(0, angleSteps * i, 0) * Vector3.forward;
            Vector3 targetPosition = npc.transform.position + currentDirection * maxDistance;

            //Find the path to that point.
            NavMeshPath pathToTargetPosition = new NavMeshPath();
            agent.CalculatePath(targetPosition, pathToTargetPosition);

            //  If there is no path to that point, it may be because there is a slope in the level, in that case incrementally increase the 
            // y value of the target point to see if there is a valid point higher.
            float verticalOffset = verticalDistanceCheckInc;
            while(pathToTargetPosition.status == NavMeshPathStatus.PathInvalid && verticalOffset <= maxVerticalDistance)
            {
                agent.CalculatePath(targetPosition - new Vector3(0, targetPosition.y - verticalOffset, 0), pathToTargetPosition);
                verticalOffset += verticalDistanceCheckInc;
            }

            //If the path is still invalid, just find furthest reachable point in that direction.
            if(pathToTargetPosition.status == NavMeshPathStatus.PathInvalid)
            {
                NavMeshHit h;
                agent.Raycast(targetPosition, out h);
                reachablePoints.Add(h.position);
                continue;
            }

            //Find the point max distance along the path - this has to be done by assigning the agent the path.
            agent.SetPath(pathToTargetPosition);
            NavMeshHit hit;
            agent.SamplePathPosition(NavMesh.AllAreas, maxDistance, out hit);
            reachablePoints.Add(hit.position);
            agent.ResetPath();
         
        }

        Vector3 furthestPointFromTarget = target.transform.position;
        foreach (Vector3 point in reachablePoints)
        {

            float betweenCurrent = Vector3.Distance(target.transform.position, point);
            float betweenFurthest = Vector3.Distance(target.transform.position, furthestPointFromTarget);

            if (betweenCurrent > betweenFurthest) furthestPointFromTarget = point;

        }

        agent.SetDestination(furthestPointFromTarget);

    }

    public override void Act(NPCAI npc, Scannable target)
    {
        
    }

    public override void Adjust(NPCAI npc, Scannable target)
    {
        Plan(npc, target);
    }

    public override void Cease(NPCAI npc, Scannable target)
    {
        

    }

}