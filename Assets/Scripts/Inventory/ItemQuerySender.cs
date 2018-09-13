using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An interface for a an object that can ask an Inventory for an equippable item, and return an item when the query is resolved.
/// </summary>
public interface ItemQuerySender {

    EquipableItem ResolveQuery(EquipableItem item);

}
