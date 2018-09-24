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
    public static LaunchData DetermineRequiredLaunchToReachPoint(Vector3 startPos, Vector3 endPos, float arcHeightDifference)
    {

        Vector3 displacement = endPos - startPos; //The distance traveled along each of the axes.
        float arcMaxHeight = Mathf.Abs(displacement.y) + arcHeightDifference;

        float travelTime = DetermineArcTravelTime(displacement.y, arcMaxHeight);

        //Calcutale each of the velocities using Kinematics.
        float xVelocity = displacement.x / travelTime;
        float yVelocity = Mathf.Sqrt(-2 * Physics.gravity.y * arcMaxHeight);
        float zVelocity = displacement.z / travelTime;

        return new LaunchData(new Vector3(xVelocity, yVelocity, zVelocity), travelTime);

    }

    /// <summary>
    /// Calculates the time it would take an object to travel in an arc, defined by the vertical displacement between the start and the mx height of the arc.
    /// </summary>
    /// <param name="yDisplacement"></param>
    /// <param name="arcMaxHeight"></param>
    /// <returns></returns>
    public static float DetermineArcTravelTime(float yDisplacement, float arcMaxHeight)
    {
        return Mathf.Sqrt(-2 * arcMaxHeight / Physics.gravity.y) + Mathf.Sqrt(2 * (yDisplacement - arcMaxHeight) / Physics.gravity.y);
    }

    /// <summary>
    /// Calculate the displacement along a given launch of initial velocity, at the given time.
    /// </summary>
    /// <param name="launchVelocity"></param>
    /// <param name="time"></param>
    /// <returns></returns>
    public static Vector3 DetermineDisplacementAlongLaunchArc(Vector3 launchVelocity, float time)
    {
        return launchVelocity * time + Physics.gravity * time * time / 2;
    }

    /// <summary>
    /// Represents the data for a launch.
    /// </summary>
    public struct LaunchData
    {

        public readonly Vector3 launchVelocity;
        public readonly float travelTime;

        public LaunchData(Vector3 launchVelocity, float travelTime)
        {
            this.launchVelocity = launchVelocity;
            this.travelTime = travelTime;
        }

    }

}
