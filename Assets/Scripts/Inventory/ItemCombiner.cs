using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An item which can be used to combine two other inventory items into a new item.
/// </summary>
public class ItemCombiner : EquipableItem, ItemQuerySender {

    [SerializeField] CombinationScheme scheme;

    private EquipableItem item1; //The first of the two items to be combined.
    

    public override void Use(Transform userTranform, Inventory inventory)
    {
        throw new System.InvalidOperationException("An item combiner has not been implemented to be used like a typical Equippable item, " +
                                                   "it must be activated from a special slot in a combinable inventory.");
    }

    /// <summary>
    /// Specify the first item and query an inventory for the second.
    /// </summary>
    /// <param name="item1"></param>
    /// <param name="inventory"></param>
    public void StartCombination(EquipableItem item1, QueriableInventory inventory)
    {

        if (!scheme.HasCombination(item1)) throw new InvalidCombinationInitialisationException("The given item has no combinations.");

        //Find all the slots in the inventory with eligible items.
        List<int> eligibleSlots = new List<int>();
        EquipableItem[] eligibleItems = scheme.eligibleItemsToCombineWith(item1);
        foreach(EquipableItem eligibleItem in eligibleItems)
        {
            int slot = inventory.getPositionOfItem(eligibleItem);
            if (slot > -1) eligibleSlots.Add(slot);
        }

        this.item1 = item1;
        inventory.QueryForItem(this, eligibleSlots); //Query inventory for second item to used in combination.

    }

    public EquipableItem ResolveQuery(EquipableItem item2)
    {
        return scheme.combineItems(item1, item2);
    }

    public class InvalidCombinationInitialisationException : System.Exception
    {
        public InvalidCombinationInitialisationException(string msg) : base(msg)
        {

        }
    }

}
