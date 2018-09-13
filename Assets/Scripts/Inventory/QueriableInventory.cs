using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An inventory to which a query for an item can be sent.
/// </summary>
public abstract class QueriableInventory : Inventory {

    private ItemQuerySender querySender; //The item making a query to the inventory.
    private List<int> eligibleSlots;

    /// <summary>
    /// Recieve an object awaiting an item from any slot in the inventory.
    /// </summary>
    /// <param name="querySender"></param>
    public void QueryForItem(ItemQuerySender querySender)
    {

        //Do not handle another query if there is one that has not yet been resolved.
        if (this.querySender != null) throw new InventoryBusyException();
        this.querySender = querySender;
        eligibleSlots = null;

    }

    /// <summary>
    /// Recieve an object awaiting an item only from the given slots in the inventory.
    /// </summary>
    /// <param name="querySender"></param>
    /// <param name="eligiblePositions"></param>
    public void QueryForItem(ItemQuerySender querySender, List<int> eligiblePositions)
    {
        QueryForItem(querySender);
        eligibleSlots = new List<int>(eligiblePositions);
    }

    protected override void SlotSelected(int num)
    {

        //If eligible slots are specified, make sure that the selected slot is one of those slota
        if (eligibleSlots != null && !eligibleSlots.Contains(num)) return;

        //If there is no query to be resolved, just equip an item as per usual.
        if (querySender == null)
        {
            base.SlotSelected(num);
            return;
        }

        querySender.ResolveQuery(GetItemAt(num));
        querySender = null;

    }

    /// <summary>
    /// An exception to be thrown when the inventory is already busy with another query.
    /// </summary>
    public class InventoryBusyException : System.Exception
    {

        public InventoryBusyException() : base("This inventory is already handling another query.")
        {

        }

    }

}
