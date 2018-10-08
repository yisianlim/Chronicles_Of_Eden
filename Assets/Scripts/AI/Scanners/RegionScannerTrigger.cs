using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class RegionScannerTrigger : MonoBehaviour {

    List<Scannable> scannablesInRegion;

    /// <summary>
    /// Returns the scanables detected in the region of the given type.
    /// </summary>
    /// <param name="scannableType"></param>
    /// <returns></returns>
    public ICollection<Scannable> Query()
    {
        return new List<Scannable>(scannablesInRegion);
    }

    private void OnTriggerEnter(Collider other)
    {
        Scannable scannable = other.GetComponent<Scannable>();
        if (scannable != null) scannablesInRegion.Add(scannable);
    }

    private void OnTriggerExit(Collider other)
    {
        Scannable scannable = other.GetComponent<Scannable>();
        if (scannable != null) scannablesInRegion.Remove(scannable);
    }

}
