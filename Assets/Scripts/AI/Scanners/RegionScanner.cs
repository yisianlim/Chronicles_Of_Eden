using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionScanner : Scanner
{

    [SerializeField] RegionScannerTrigger region;

    protected override ICollection<Scannable> Scan(Transform originTranform)
    {
        return region.Query();
    }
}
