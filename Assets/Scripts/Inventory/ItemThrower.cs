using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BombThrower", menuName = "Equipable Item/Untitled Item Thower", order = 1)]
public class ItemThrower : EquipableItem
{

    [SerializeField] Rigidbody item; //The type of item that is able to be thrown.
    [SerializeField] Vector2 throwForce;
    [SerializeField] float instantiationDistanceFromPlayer;

    public override void Use(Transform userTranform, Inventory inventory)
    {

        Debug.Log("Item Thrower Used");

        Vector3 instantationPoint = CalculateInstantiationPoint(userTranform, instantiationDistanceFromPlayer);

        float forceX = throwForce.x * Mathf.Sin(Mathf.Deg2Rad * userTranform.eulerAngles.y);
        float forceZ = throwForce.x * Mathf.Cos(Mathf.Deg2Rad * userTranform.eulerAngles.y);

        Rigidbody instance = Instantiate(item, new Vector3(instantationPoint.x, userTranform.position.y, instantationPoint.z), userTranform.rotation);
        instance.AddForce(forceX, throwForce.y, forceZ, ForceMode.Impulse);

    }

    /// <summary>
    /// Find point the given radius from the position of the given origin transform that is directly infront of the player.
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="instantiationRadius"></param>
    /// <returns></returns>
    public static Vector3 CalculateInstantiationPoint(Transform origin, float instantiationRadius)
    {

        float instantiationX = origin.position.x + instantiationRadius * Mathf.Sin(Mathf.Deg2Rad * origin.eulerAngles.y);
        float instantiationZ = origin.position.z + instantiationRadius * Mathf.Cos(Mathf.Deg2Rad * origin.eulerAngles.y);

        return new Vector3(instantiationX, origin.position.y, instantiationZ);

    }

}
