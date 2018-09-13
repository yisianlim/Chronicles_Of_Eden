using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An interface for a an object that can ask an Inventory for an equippable item.
/// </summary>
public interface ItemQuerySender {

    void ResolveQuery(EquipableItem item);

}
