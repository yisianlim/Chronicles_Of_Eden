using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An abstract class for a Component that allows an object to identify the types of other nearby objects.
/// </summary>
public abstract class Scanner : ScriptableObject {

    /// <summary>
    /// Identify scannable object.
    /// </summary>
    /// <returns>A collect list of all scannable objects</returns>
    protected abstract ICollection<Scannable> Scan(Transform originTranform);

    public List<Scannable> ScanFor(string type, Transform originTransform)
    {

        ICollection<Scannable> scannedObjects = Scan(originTransform);

        //Group identified objects by type.
        Dictionary<string, List<Scannable>> groupedScannedObjects = new Dictionary<string, List<Scannable>>();
        foreach(Scannable obj in scannedObjects)
        {
            
           if(!groupedScannedObjects.ContainsKey(obj.Type))
                groupedScannedObjects.Add(obj.Type, new List<Scannable>());

            groupedScannedObjects[obj.Type].Add(obj); 

        }

        if (groupedScannedObjects.ContainsKey(type))
            return groupedScannedObjects[type];
        else return new List<Scannable>();

    }

}
