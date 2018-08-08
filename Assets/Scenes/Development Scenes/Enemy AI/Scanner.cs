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
    public delegate void ScanResult(Dictionary<string, List<Scannable>> scannedObjects);
    public ScanResult ObjectsScanned;

    /// <summary>
    /// Identify scannable object.
    /// </summary>
    /// <returns>A collect list of all scannable objects</returns>
    protected abstract List<Scannable> Scan();

    private void Update()
    {
        List<Scannable> scannedObjects = Scan();
        if (scannedObjects != null) return;

        //Group identified objects by type.
        Dictionary<string, List<Scannable>> groupedScannedObjects = new Dictionary<string, List<Scannable>>();
        foreach(Scannable obj in scannedObjects)
        {
            
           if(!groupedScannedObjects.ContainsKey(obj.Type))
                groupedScannedObjects.Add(obj.Type, new List<Scannable>());

            groupedScannedObjects[obj.Type].Add(obj); 

        }

        ObjectsScanned(groupedScannedObjects);
    }

}
