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
        //Debug.Log("In Radius: " + collidersInRadius.Length);


        //Find all objects within the scan angle, relative to the position the origin and the direction being faced.
        List<E> targetsInArc = new List<E>();
        foreach (Collider target in collidersInRadius) {

            //Check whether the object has the desired component, skip if otherwise.
            E[] es = target.GetComponents<E>();
            //Debug.Log("Components on " + target.gameObject.name + " :" + es.Length);
            if (es == null) continue;

            //Observe each one of the found components and add them to targets if they are reachable.
            foreach(E e in es)
            {


                
                //  Find the direction to the target, and skip if it is the zero vector (i.e. target is in exactly the same place as origin, which means it
                // can be assumed it is the object at the origin).
                Vector3 directionToTarget = (target.transform.position - origin).normalized;
                if (directionToTarget.Equals(Vector3.zero)) continue;

                

                //  Find the angle to each target in radius, and consider it within FOV if the angle to it from the direction being faced
                // is less half the given scan angle. Skip if otherwise.
                float angleFromTarget = Mathf.Abs(Vector3.SignedAngle(directionFacing, directionToTarget, Vector3.up));
                if (angleFromTarget > scanAngle / 2f) continue;

                //TODO: Add code that checks whether there is something blocking the FOV between origin and target.

                targetsInArc.Add(e);

            }

        }
        //Debug.Log(targetsInArc.ToArray().ToString());
        return targetsInArc.ToArray();

    }

}
