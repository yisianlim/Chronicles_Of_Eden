using System;
using System;
using System.Collections.Generic;
using UnityEngine;

public class NPCAI : Agent {

    [SerializeField] Reaction[] reactions; //The reactions of the NPC to differen object types, in order of priority.
    protected virtual Reaction[] CurrentReactions { get { return reactions; } }

    Reaction currentReaction;
    private Scannable currentTarget;
    private Vector3 nearestScannablePosition = Vector3.positiveInfinity; //The position of the current closest scanable.
    internal NPCAnimator npcAnimator;

    private Boolean stone = false;

    private void Awake()
    {
        npcAnimator = GetComponent<NPCAnimator>();
    }

    private void Update()
    {

        if (stone) { return; }

        foreach(Reaction reaction in CurrentReactions)
        {

            //Use the reaction's scanner to search for objects of the relevant type, and skip reaction if none are found.
            List<Scannable> detectedObjects = reaction.scanner.ScanFor(reaction.objectType, transform);
            if (detectedObjects.Count <= 0) continue;

            Scannable targetScannable = reaction.targetSelectionCritera.FilterAndSelect(detectedObjects, this);

            //If the type of the target has changed, initialise a new behavior.
            if (!ReferenceEquals(currentReaction, reaction))
            {

                //Cease performing current behaviour, if one was being performed.
                if(currentReaction != null) currentReaction.reaction.Cease(this, targetScannable);

                //Start new one.
                reaction.reaction.Plan(this, targetScannable);
                currentReaction = reaction;

                //Change the animation.
                if(npcAnimator != null) npcAnimator.Animation = reaction.animation;

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

        //If the stopping condition for the behavior has been met, stop the behavior.
        if(currentReaction != null && currentReaction.reaction.ExtraStoppingCondition)
        {
            currentReaction.reaction.Cease(this, currentTarget);
            SetIsMoving(false);
            if (npcAnimator != null) npcAnimator.Animation = "Idle";
            currentReaction = null;
        }

    }

    public void Petrify() {
        this.stone = true;
    }

    [Serializable]
    protected class Reaction
    {
        public string objectType;
        public Scanner scanner; //The scanner used to search for the objects to react to.
        public NPCBehaviour reaction;
        public TargetSelector targetSelectionCritera;
        public string animation;

    }

}
