using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// An item that can be pickedup and used from the inventory.
/// </summary>
public abstract class EquipableItem : ScriptableObject {

    [SerializeField] string InGameName;
    [SerializeField] Sprite _Image;
    [SerializeField] float cooldown; //How long after the item has been used the item is able to be used again.

    public float Cooldown { get { return cooldown; } }

    /// <summary>
    /// Activate the item.
    /// </summary>
    /// <param name="userTranform"> The transform of the character using the item. </param>
    /// <param name="inventory"> The inventory from which the item was used. </param>
    public abstract void Use(Transform userTranform, Inventory inventory);

    public Sprite Image {
        get {
            return _Image;
        }
    }

}
