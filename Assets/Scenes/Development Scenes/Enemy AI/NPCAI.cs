﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class NPCAI : MonoBehaviour {

    [SerializeField] Scanner scanner; //The object used to detemine other nearby objects.
    [SerializeField] Reaction[] reactions; //The reactions of the NPC to differen object types, in order of priority.

    private string targetScannableType = ""; //The type of the scannable currently being reacted to.
    private Vector3 nearestScannablePosition = Vector3.positiveInfinity; //The position of the current closest scanable.


    private void Update()
    {

        foreach(Reaction reaction in reactions)
        {

            //Use the reaction's scanner to search for objects of the relevant type, and skip reaction if none are found.
            List<Scannable> detectedObjects = reaction.scanner.ScanFor(reaction.objectType, transform);
            if (detectedObjects.Count <= 0) continue;

            Scannable targetScannable = getNearestScannable(detectedObjects);

            //If there is new information, plan for it, and update the new information.
            if(!nearestScannablePosition.Equals(targetScannable.transform.position) || !targetScannableType.Equals(targetScannable.Type))
            {
                reaction.reaction.Plan(this, targetScannable);
                targetScannableType = targetScannable.Type;
                nearestScannablePosition = targetScannable.transform.position;
            }

            reaction.reaction.Act(this, targetScannable);

            return; //Only react to highest priority scannable.

        }

        targetScannableType = ""; //No scanables on any type were detected.

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

    [Serializable]
    private class Reaction
    {
        public string objectType;
        public Scanner scanner; //The scanner used to search for the objects to react to.
        public NPCBehaviour reaction;
    }

}
