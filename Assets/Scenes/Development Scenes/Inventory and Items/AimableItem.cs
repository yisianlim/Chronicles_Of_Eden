using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AimableItem : EquipableItem
{
    /// <summary>
    /// Ensure user has a RangedItemComponent attatched to them, and then use it to aim the given item.
    /// </summary>
    /// <param name="userTranform"></param>
    /// <param name="inventory"></param>
    public override void Use(Transform userTranform, Inventory inventory)
    {

        RangedItemAimer aimer = userTranform.GetComponent<RangedItemAimer>();
        if (aimer == null)
            throw new System.Exception("The player needs to have a ranged item aimer attatched to it in order to use a" + name);

        aimer.AimItem(this);

    }

    /// <summary>
    /// Visualise where the item is going to go.
    /// </summary>
    /// <param name="origin">The point from where the item is being aimed from.</param>
    /// <param name="endPoint">The point where the item is being aimed to.</param>
    public abstract void VisualiseAim(Vector3 origin, Vector3 endPoint);

    /// <summary>
    /// Fire the item from the origin to the end point.
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="endpoint"></param>
    public abstract void Fire(Transform origin, Vector3 endpoint);

}
