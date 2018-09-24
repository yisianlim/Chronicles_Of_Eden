using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Dropper", menuName = "Equipable Item/Item Dropper", order = 4)]
public class ItemDropper : EquipableItem
{
    Rigidbody droppedItem;
    float instantiationDistanceFromPlayer;

    public override void Use(Transform userTranform, Inventory inventory)
    {
        Vector3 instantationPoint = ItemThrower.CalculateInstantiationPoint(userTranform, instantiationDistanceFromPlayer);
        Instantiate(droppedItem, instantationPoint, userTranform.rotation);
    }
}
