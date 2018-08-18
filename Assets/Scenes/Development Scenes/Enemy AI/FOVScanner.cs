using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVScanner : Scanner
{
    protected override ICollection<Scannable> Scan(Transform originTranform)
    {
        throw new System.NotImplementedException();
    }

    public static E[] FOVScanForObjectsOfType<E>(Vector3 origin, Vector3 directionFacing, float scanRadius, float scanAngle)
    {

        //Find all collidable objects within a given radius of the origin.
        Collider[] collidersInRadius = Physics.OverlapSphere(origin, scanRadius);

        //Find all objects within the scan angle, relative to the position the origin and the direction being faced.
        List<E> targetsInArc = new List<E>();
        foreach (Collider target in collidersInRadius) {

            //Check whether the object has the desired component, skip if otherwise.
            E e = target.GetComponent<E>();
            if (e == null) continue;

            //  Find the angle to each target in radius, and consider it within FOV if the angle to it from the direction being faced
            // is less half the given scan angle. Skip if otherwise.
            Vector3 directionToTarget = (target.transform.position - origin).normalized;
            float angleFromTarget = Mathf.Abs(Vector3.Angle(directionFacing, directionToTarget));
            if (angleFromTarget > scanAngle / 2f) continue;

            //Check that there is nothing inbewtween the target and the origin. Skip if otherwise.
            float distanceToTarget = Vector3.Distance(origin, target.transform.position);
            if (Physics.Raycast(origin, directionToTarget)) continue;

            targetsInArc.Add(e);

        }

        return targetsInArc.ToArray();

    }

}
