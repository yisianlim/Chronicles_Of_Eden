using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Damages anything with a DamageReciever that gets close enough.
/// </summary>
[RequireComponent(typeof(Collider))]
public class DamagingWeapon : MonoBehaviour {

    public bool Active { get; set; } //Whether the weapon is able to deal damage at a particular point in time.

    [SerializeField] int strength; //How much damage the attack deals.

    public void OnTriggerExit(Collider other)
    {

        if (!Active) return; //Do not do anything more is the weapon is not supposed to be able to deal damage.

        //Deal damage to what ever was detected within the collider.
        DamageReciever[] damageRecievers = other.GetComponents<DamageReciever>();
        new List<DamageReciever>(damageRecievers).ForEach(reciever => {
            reciever.ApplyDamage(strength, transform.position);
            Debug.Log(reciever);
        });

    }

}
