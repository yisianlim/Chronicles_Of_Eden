using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A scanner that looks for scannable objects in a radius around the object.
/// </summary>
public class RadiusScanner : Scanner
{

    [SerializeField] float scanRadius;

    protected override ICollection<Scannable> Scan(Transform originTransform)
    {

        //Find all colliderable objects nearby.
        Collider[] objsNearby = Physics.OverlapSphere(originTransform.position, scanRadius);

        //Filter out the scannable objects and return them.
        List<Scannable> scannables = new List<Scannable>();
        new List<Collider>(objsNearby).ForEach(obj =>
        {
            Scannable scannable = obj.GetComponent<Scannable>();
            if (scannable != null) scannables.Add(scannable);
        });

        if (scannables.Count <= 0) return null;
        return new List<Scannable>(scannables);

    }
}
