using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An item that fires an object to a position in a calculated arc.
/// </summary>
[CreateAssetMenu(fileName = "Launcher", menuName = "Equipable Item/Launcher", order = 3)]
public class Launcher : AimableItem
{

    private GameObject aimCursor; //Used to visualise where in the world the item fired will end up.

    [SerializeField] Rigidbody item; //The item being launched.
    [SerializeField] float instantiationDistanceFromPlayer;

    [Header("Visualisation")]
    [SerializeField] GameObject cursor;
    [SerializeField] int arcVisualisationResolution;
    [SerializeField] PathVisualiser arcVisuliser;

    private void OnEnable()
    {
        aimCursor = Instantiate(cursor);
        aimCursor.SetActive(false);
    }

    public override void Fire(Transform userTransform, Vector3 endpoint)
    {

        //Find the point the given distance infront of the player and intantiate the item there.
        Vector3 instantationPoint = ItemThrower.CalculateInstantiationPoint(userTransform, instantiationDistanceFromPlayer);
        Rigidbody instance = Instantiate(item, instantationPoint, userTransform.rotation);

        //Apply the required velocity to the instance so that it lands on the end point.
        instance.velocity = Calculations.DetermineRequiredLaunchToReachPoint(instantationPoint, endpoint, 1).launchVelocity;

        aimCursor.SetActive(false);
        arcVisuliser.HidePath();

    }

    public override void VisualiseAim(Transform userTransform, Vector3 endPoint)
    {

        //Turn user to face target.
        Vector3 dir = endPoint - userTransform.position;
        Vector3 rotation = Vector3.RotateTowards(userTransform.transform.forward, dir, 360, 0f);
        userTransform.transform.rotation = Quaternion.LookRotation(rotation);

        aimCursor.SetActive(true);
        aimCursor.transform.position = endPoint;

        //Determine how long the launch would take.
        Vector3 instantationPoint = ItemThrower.CalculateInstantiationPoint(userTransform, instantiationDistanceFromPlayer);
        Calculations.LaunchData launch = Calculations.DetermineRequiredLaunchToReachPoint(instantationPoint, endPoint, 1);

        //Determine points along path and drawn them.
        Vector3[] arc = new Vector3[arcVisualisationResolution];
        for (int i = 0; i < arcVisualisationResolution; i++)
            arc[i] = instantationPoint + Calculations.DetermineDisplacementAlongLaunchArc(launch.launchVelocity, launch.travelTime / (arcVisualisationResolution * 1f));
        arcVisuliser.VisualisePath(arc);

    }
}
