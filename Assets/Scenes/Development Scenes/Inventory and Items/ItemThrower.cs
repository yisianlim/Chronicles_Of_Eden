using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BombThrower", menuName = "Equipable Item/Untitled Item Thower", order = 1)]
public class ItemThrower : EquipableItem
{

    [SerializeField] Rigidbody item; //The type of item that is able to be thrown.
    [SerializeField] Vector3 throwForce;

    public override void Use(Transform userTranform)
    {

        Rigidbody itemInstance = Instantiate(item, Vector3.zero, Quaternion.identity, userTranform);
        itemInstance.AddForce(throwForce, ForceMode.Impulse);

    }
}
