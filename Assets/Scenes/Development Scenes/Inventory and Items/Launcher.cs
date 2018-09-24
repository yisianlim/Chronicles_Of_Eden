using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An item that fires an object to a position in a calculated arc.
/// </summary>
[CreateAssetMenu(fileName = "Launcher", menuName = "Equipable Item/Launcher", order = 3)]
public class Launcher : AimableItem
{

    [SerializeField] Rigidbody item; //The item being launched.
    [SerializeField] float instantiationDistanceFromPlayer;

    public override void Fire(Transform userTransform, Vector3 endpoint)
    {

        //Find the point the given distance infront of the player and intantiate the item there.
        Vector3 instantationPoint = ItemThrower.CalculateInstantiationPoint(userTransform, instantiationDistanceFromPlayer);
        Rigidbody instance = Instantiate(item, instantationPoint, userTransform.rotation);

        //Apply the required velocity to the instance so that it lands on the end point.
        instance.velocity = Calculations.determineRequiredLaunchVelocityToReachPoint(instantationPoint, endpoint, 1);

    }

    public override void VisualiseAim(Transform userTransform, Vector3 endPoint)
    {

        //Turn user to face target.
        Vector3 dir = endPoint - userTransform.position;
        Vector3 rotation = Vector3.RotateTowards(userTransform.transform.forward, dir, 360, 0f);
        userTransform.transform.rotation = Quaternion.LookRotation(rotation);

    }
}
