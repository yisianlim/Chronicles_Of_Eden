using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines the criteria that an NPCAI can uses to select a single target from multiple.
/// </summary>
public abstract class TargetSelector : ScriptableObject {

    [SerializeField] TargetFilter[] filters; //Filter criteria, all of which must be met for a target to be considered valid.

    /// <summary>
    /// Filter out any invalid targets, and then, if there are any valid targets, return one based on the selection criteria.
    /// </summary>
    /// <param name="targets"></param>
    /// <returns></returns>
	public Scannable FilterAndSelect(ICollection<Scannable> targets, NPCAI npc)
    {

        //Filter targets based on given filter.
        List<Scannable> validTargets = new List<Scannable>();
        foreach(Scannable target in targets)
        {

            //The target must pass all filters to be considered valid.
            bool targetValid = true;
            foreach(TargetFilter filter in filters)
            {
                if (!filter.IsValidTarget(target, npc))
                {
                    //As soon as a target fails a filter, there is no point in continuing.
                    targetValid = false;
                    break;
                }
            }

            if (targetValid) validTargets.Add(target);

        }


        if (validTargets.Count == 0) return null;
        else return SelectTarget(validTargets, npc);

    }

    /// <summary>
    /// Selects a valid target based on the criteria.
    /// </summary>
    /// <param name="targets"></param>
    /// <returns></returns>
    public abstract Scannable SelectTarget(ICollection<Scannable> targets, NPCAI npc);

}
