using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An item which can be used to combine two other inventory items into a new item.
/// </summary>
public class ItemCombiner : EquipableItem, ItemQuerySender {

    private EquipableItem item1; //The first of the two items to be combined.
    

    public override void Use(Transform userTranform, Inventory inventory)
    {
        throw new System.InvalidOperationException("An item combiner has not been implemented to be used like a typical Equippable item, " +
                                                   "it must be activated from a special slot in a combinable inventory.");
    }

    public void StartCombination(EquipableItem item1, CombinableInventory inventory)
    {

        this.item1 = item1;
        inventory.QueryForItem(this); //Query inventory for second item to used in combination.

    }

    public void ResolveQuery(EquipableItem item)
    {
        

    }
}
