using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAI : MonoBehaviour {

    [SerializeField] Scanner scanner; //The object used to detemine other nearby objects.
    [SerializeField] Reaction[] reactions; //The reactions of the NPC to differen object types, in order of priority.

    private void OnEnable()
    {
        scanner.ObjectsScanned += ObjectsDetected;
    }

    private void OnDisable()
    {
        scanner.ObjectsScanned -= ObjectsDetected;
    }


    private void ObjectsDetected(Dictionary<string, List<Scannable>> detectedObjects)
    {

        foreach(Reaction reaction in reactions)
        {

            if (!detectedObjects.ContainsKey(reaction.objectType)) continue;

            Scannable targetScannable = getNearestScannable(detectedObjects[reaction.objectType]);
            reaction.reaction.Act(this, targetScannable);

            return; //Only react to highest priority scannable.

        }

    }

    /// <summary>
    /// Find the closest scanable to the current scanable from the given list of scannables.
    /// </summary>
    /// <param name="scannables"></param>
    /// <returns></returns>
    private Scannable getNearestScannable(List<Scannable> scannables)
    {
        Scannable nearestScannable = scannables[0];
        for(int i = 0; i < scannables.Count; i++) {

            float distanceToCurrent = Vector3.Distance(transform.position, scannables[i].transform.position);
            float distanceToNearest = Vector3.Distance(transform.position, nearestScannable.transform.position);

            if (distanceToCurrent < distanceToNearest)
                nearestScannable = scannables[i];

        }

        return nearestScannable;

    }

    [SerializeField]
    private class Reaction
    {
        public string objectType;
        public NPCBehaviour reaction;
    }

}
