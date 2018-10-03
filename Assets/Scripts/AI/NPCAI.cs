using System;
using System;
using System.Collections.Generic;
using UnityEngine;

public class NPCAI : Agent {

    [SerializeField] Reaction[] reactions; //The reactions of the NPC to differen object types, in order of priority.

    Reaction currentReaction;
    private Scannable currentTarget;
    private Vector3 nearestScannablePosition = Vector3.positiveInfinity; //The position of the current closest scanable.
    internal EnemyAnimator enemyAnimator;

    private Boolean stone = false;

    private void Awake()
    {
        enemyAnimator = GetComponent<EnemyAnimator>();
    }

    private void Update()
    {

        if (stone) { return; }

        foreach(Reaction reaction in reactions)
        {

            //Use the reaction's scanner to search for objects of the relevant type, and skip reaction if none are found.
            List<Scannable> detectedObjects = reaction.scanner.ScanFor(reaction.objectType, transform);
            if (detectedObjects.Count <= 0) continue;

            Scannable targetScannable = getNearestScannable(detectedObjects);

            //If the type of the target has changed, initialise a new behavior.
            if (!ReferenceEquals(currentReaction, reaction))
            {

                //Cease performing current behaviour, if one was being performed.
                if(currentReaction != null) currentReaction.reaction.Cease(this, targetScannable);

                //Start new one.
                reaction.reaction.Plan(this, targetScannable);
                currentReaction = reaction;

            }

            //Otherwise, if information about the target has changed, adjust plan for new information.
            else if (!nearestScannablePosition.Equals(targetScannable.transform.position))
            {
                reaction.reaction.Adjust(this, targetScannable);
                currentTarget = targetScannable;
                nearestScannablePosition = targetScannable.transform.position;
            }

            reaction.reaction.Act(this, targetScannable);
            SetIsMoving(reaction.reaction.IsMoving);

            return; //Only react to highest priority scannable.

        }

        //Cease performing current behaviour, if one was being performed, and the behavior is to be ceased when there are no targets.
        if (currentReaction != null && currentReaction.reaction.CeaseWhenNoTargets)
        {
            currentReaction.reaction.Cease(this, currentTarget);
            SetIsMoving(false);
        }

        currentReaction = null; //There are no applicable reactions.

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

    public void Petrify() {
        this.stone = true;
    }

    [Serializable]
    private class Reaction
    {
        public string objectType;
        public Scanner scanner; //The scanner used to search for the objects to react to.
        public NPCBehaviour reaction;
    }

}
