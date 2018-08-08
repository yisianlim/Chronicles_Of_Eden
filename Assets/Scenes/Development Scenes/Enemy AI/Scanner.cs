using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An abstract class for a Component that allows an object to identify the types of other nearby objects.
/// </summary>
public abstract class Scanner : MonoBehaviour {

    /// <summary>
    /// A delegate to be called when scannable objects have been identified.
    /// </summary>
    /// <param name="scannedObjects"></param>
    public delegate void ScanResult(Scannable[] scannedObjects);
    public ScanResult ObjectsScanned;

    /// <summary>
    /// Identify scannable object.
    /// </summary>
    /// <returns>A list of all the scannable objects nearby, null if there are none.</returns>
    protected abstract Scannable[] Scan();

    private void Update()
    {
        Scannable[] scannedObjects = Scan();
        if (scannedObjects != null)
            ObjectsScanned(scannedObjects);
    }

}
