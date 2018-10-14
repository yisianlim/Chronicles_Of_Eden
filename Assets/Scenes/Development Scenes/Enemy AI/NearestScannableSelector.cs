using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Selects the closest valid target to the NPC.
/// </summary>
[CreateAssetMenu(fileName = "Nearest Target Selector", menuName = "NPC AI/Target/Selectors/Nearest Target", order = 1)]
public class NearestScannableSelector : TargetSelector
{
    public override Scannable SelectTarget(ICollection<Scannable> targets, NPCAI npc)
    {
        Scannable nearestScannable = null;
        foreach (Scannable target in targets)
        {

            //To begin with, set the nearest scannable to the first item in scannables.
            if(nearestScannable == null)
            {
                nearestScannable = target;
                continue;
            }

            float distanceToCurrent = Vector3.Distance(npc.transform.position, target.transform.position);
            float distanceToNearest = Vector3.Distance(npc.transform.position, nearestScannable.transform.position);

            if (distanceToCurrent < distanceToNearest)
                nearestScannable = target;
        }

        return nearestScannable;
    }
}
