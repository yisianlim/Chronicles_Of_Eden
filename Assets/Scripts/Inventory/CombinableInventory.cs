using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An extension of the inventory that has a special slot for the item combiner, and resulting combined item.
/// </summary>
public class CombinableInventory : Inventory {

    private ItemCombiner combiner;

    public override void AddItem(EquipableItem item)
    {
        //Check whether the item being equpped is an item combiner, as we deal with that as a special case.
        if ((item as ItemCombiner) != null)
        {
            combiner = item as ItemCombiner;
        }
        else base.AddItem(item); //Otherwise, treat it as a regular item.

    }


}
