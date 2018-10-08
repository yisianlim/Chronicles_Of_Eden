using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A scanner that looks for scannables within a specific region of the map.
/// </summary>
[CreateAssetMenu(fileName = "Region Scanner", menuName = "NPC AI/Scanners/Region Scanner", order = 2)]
public class RegionScanner : Scanner
{

    [SerializeField] RegionScannerTrigger region;

    protected override ICollection<Scannable> Scan(Transform originTranform)
    {
        return region.Query();
    }
}
