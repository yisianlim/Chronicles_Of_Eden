using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A scanner that looks for scannables within a specific region of the map.
/// </summary>
[CreateAssetMenu(fileName = "Region Scanner", menuName = "NPC AI/Scanners/Region Scanner", order = 2)]
public class RegionScanner : Scanner
{

    [SerializeField] Vector3 regionCentre;
    [SerializeField] Vector3 regionSize;

    private List<Scannable> scannables = new List<Scannable>();

    protected override ICollection<Scannable> Scan(Transform originTranform)
    {

        List<Scannable> scannables = new List<Scannable>();

        Collider[] colliders = Physics.OverlapBox(regionCentre, regionSize / 2);
        foreach(Collider c in colliders)
        {
            Scannable s = c.GetComponent<Scannable>();
            if (s != null) scannables.Add(s);
        }

        return scannables;

    }

}
