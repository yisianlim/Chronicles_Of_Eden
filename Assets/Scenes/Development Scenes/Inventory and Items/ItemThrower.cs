using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BombThrower", menuName = "Equipable Item/Untitled Item Thower", order = 1)]
public class ItemThrower : EquipableItem
{

    Rigidbody item; //The type of item that is able to be thrown.

    public override void Use(Transform userTranform)
    {
        
    }
}
