using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculations{

    /// <summary>
    /// Finds the velocity required to launch an object between the start point and end point.
    /// </summary>
    /// <param name="startPos">The start position of the object.</param>
    /// <param name="endPos">The end position of the object after launch.</param>
    /// <param name="arcHeightDifferece">How much higher than the max hieght of the two positions the top of the objects arc will be.</param>
    /// <returns></returns>
    public static Vector3 determineRequiredLaunchVelocityToReachPoint(Vector3 startPos, Vector3 endPos, float arcHeightDifference)
    {

        Vector3 displacement = endPos - startPos; //The distance traveled along each of the axes.
        float arcMaxHeight = Mathf.Abs(displacement.y) + arcHeightDifference;

        Debug.Log(displacement.y + " + " + arcHeightDifference + " = " + arcMaxHeight);

        //Calcutale each of the velocities using Kinematics.
        float xVelocity = displacement.x / (Mathf.Sqrt(-2 * arcMaxHeight / Physics.gravity.y) + Mathf.Sqrt(2 * (displacement.y - arcMaxHeight) / Physics.gravity.y));
        float yVelocity = Mathf.Sqrt(-2 * Physics.gravity.y * arcMaxHeight);
        float zVelocity = displacement.z / (Mathf.Sqrt(-2 * arcMaxHeight / Physics.gravity.y) + Mathf.Sqrt(2 * (displacement.y - arcMaxHeight) / Physics.gravity.y));

        return new Vector3(xVelocity, yVelocity, zVelocity);

    }

}
