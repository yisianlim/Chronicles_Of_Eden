using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An extension of the inventory that has a special slot for the item combiner, and resulting combined item.
/// </summary>
public class CombinableInventory : QueriableInventory {

    private ItemCombiner combiner; //The combiner that will be used to combine the items.
    private EquipableItem equipedCombination; //The currently equiped combination.

    private void Update()
    {

        if (Input.GetAxis("Inventory Special") == 0 || combiner == null) return;

        //Submit the first item to be used in the combination.
        combiner.StartCombination(EquippedItem, this);

    }

    

    public override void AddItem(EquipableItem item)
    {
        //Check whether the item being equpped is an item combiner, as we deal with that as a special case.
        if ((item as ItemCombiner) != null)
        {
            combiner = item as ItemCombiner;
        }
        else base.AddItem(item); //Otherwise, treat it as a regular item.

    }

    protected override void QueryResolved(EquipableItem result)
    {
        throw new System.NotImplementedException();
    }

}
