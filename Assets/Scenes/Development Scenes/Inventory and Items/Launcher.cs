using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An item that fires an object to a position in a calculated arc.
/// </summary>
public class Launcher : AimableItem
{

    [SerializeField] Rigidbody item; //The item being launched.
    [SerializeField] float instantiationDistanceFromPlayer;

    public override void Fire(Transform origin, Vector3 endpoint)
    {

        //Find the point the given distance infront of the player and intantiate the item there.
        Vector3 instantationPoint = ItemThrower.CalculateInstantiationPoint(origin, instantiationDistanceFromPlayer);
        Rigidbody instance = Instantiate(item, instantationPoint, origin.rotation);

        //Apply the required velocity to the instance so that it lands on the end point.
        instance.velocity = Calculations.determineRequiredLaunchVelocityToReachPoint(instantationPoint, endpoint, 1);

    }

    public override void VisualiseAim(Vector3 origin, Vector3 endPoint)
    {
        //Implement later.
    }
}
