using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Dropper", menuName = "Equipable Item/Item Dropper", order = 4)]
public class ItemDropper : EquipableItem
{
    [SerializeField] Rigidbody droppedItem;
    [SerializeField] float instantiationDistanceFromPlayer;
    [SerializeField] float dropFromHeight;

    public override void Use(Transform userTranform, Inventory inventory)
    {
        Vector3 instantationPoint = ItemThrower.CalculateInstantiationPoint(userTranform, instantiationDistanceFromPlayer);
        Instantiate(droppedItem, new Vector3(instantationPoint.x, userTranform.position.y + dropFromHeight, instantationPoint.z), userTranform.rotation);
    }

}
