using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A behaviour in which the npc tries to get as far away from an object as possible, accounting for possible walls.
/// </summary>
[CreateAssetMenu(fileName = "Avoid Behaviour", menuName = "NPC AI/Behaviors/Movement/Avoid", order = 2)]
public class Avoid : NPCBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float turnSpeed;
    [SerializeField] float targetDistance; //The distsnce the npc tries to get from WHERE IT IS STANDING.
    [SerializeField] int adjustmentDirections; //The number of directions the NPC will try to go in unobstructed - evenly distributed around circle.

    Vector3 targetPosition; //The position in which the NPC will head in order to best avoid the target. 

    public override void Plan(NPCAI npc, Scannable target)
    {

        
        //  Find the furtherest point you can get to for adjustmentDirections evenly distributed directions around a circle, if you try to travel
        //target distance in that direction.
        Vector3[] points = new Vector3[adjustmentDirections];
        float angleSteps = 360f / adjustmentDirections;
        for (int i = 0; i < points.Length; i++)
        {

            //Raycast in each direction around the circle.
            Vector3 currentDirection = Quaternion.Euler(0, angleSteps * i, 0) * Vector3.forward;

            Ray ray = new Ray(npc.transform.position, currentDirection);
            RaycastHit[] hits = Physics.RaycastAll(ray, targetDistance);

            //Find closest hit for each direction.
            if(hits.Length <= 0)
            {
                //If there were no hits, the NPC can move target distance in the current direction.
                points[i] = ray.GetPoint(targetDistance);
                continue;
            }
            else
            {

                //If there were hits, find the closest.
                Vector3 closestHitPoint = hits[0].point;
                for(int j = 1; j < hits.Length; j++)
                {

                    float distanceToClosestPoint = Vector3.Distance(closestHitPoint, npc.transform.position);
                    float distanceToCurrentPoint = Vector3.Distance(hits[j].point, npc.transform.position);

                    if (distanceToCurrentPoint < distanceToClosestPoint)
                        closestHitPoint = hits[j].point;

                }

                points[i] = closestHitPoint;
                    
            }

        }

        //Find furthest point from target - that is the target point.
        Vector3 furtherestPointFromTarget = points[0];
        for(int i = 1; i < points.Length; i++)
        {

            float distanceBetweenFurthestPointAndTarget = Vector3.Distance(furtherestPointFromTarget, target.transform.position);
            float distanceBetweenCurrentPointAndTarget = Vector3.Distance(points[i], target.transform.position);

            if (distanceBetweenCurrentPointAndTarget > distanceBetweenFurthestPointAndTarget)
                furtherestPointFromTarget = points[i];

        }

        targetPosition = furtherestPointFromTarget;

    }

    public override void Act(NPCAI npc, Scannable target)
    {

        MoveTowards.MoveNPCTowardsPosition(npc, targetPosition, movementSpeed, turnSpeed);

    }
    
}
