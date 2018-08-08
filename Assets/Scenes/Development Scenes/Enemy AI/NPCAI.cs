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
        }

    }

    private Scannable getNearestScannable(List<Scannable>)
    {
        return null;
    }

    [SerializeField]
    private class Reaction
    {
        public string objectType;
        public NPCBehaviour reaction;
    }

}
