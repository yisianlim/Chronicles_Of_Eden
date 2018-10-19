using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Damages anything with a DamageReciever that gets close enough.
/// </summary>
[RequireComponent(typeof(Collider))]
public class DamagingWeapon : MonoBehaviour {

    [SerializeField] int strength; //How much damage the attack deals.

    public void OnTriggerEnter(Collider other)
    {

        DamageReciever[] damageRecievers = other.GetComponents<DamageReciever>();
        new List<DamageReciever>(damageRecievers).ForEach(reciever => reciever.ApplyDamage(strength, transform.position));

    }

}
