using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BombThrower", menuName = "Equipable Item/Untitled Item Thower", order = 1)]
public class ItemThrower : EquipableItem
{

    [SerializeField] Rigidbody item; //The type of item that is able to be thrown.
    [SerializeField] Vector2 throwForce;
    [SerializeField] float instantiationDistanceFromPlayer;

    public override void Use(Transform userTranform)
    {

        float instantiationX = userTranform.position.x + instantiationDistanceFromPlayer * Mathf.Sin(Mathf.Deg2Rad * userTranform.eulerAngles.y);
        float instantiationZ = userTranform.position.z + instantiationDistanceFromPlayer * Mathf.Cos(Mathf.Deg2Rad * userTranform.eulerAngles.y);

        float forceX = throwForce.x * Mathf.Sin(Mathf.Deg2Rad * userTranform.eulerAngles.y);
        float forceZ = throwForce.x * Mathf.Cos(Mathf.Deg2Rad * userTranform.eulerAngles.y);

        Rigidbody instance = Instantiate(item, new Vector3(instantiationX, userTranform.position.y, instantiationZ), userTranform.rotation);
        instance.AddForce(forceX, throwForce.y, forceZ, ForceMode.Impulse);
    }
}
