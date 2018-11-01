using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A damage reciever that changes the value of a Stat component.
/// </summary>
public class ChangeStatDamageReciever : DamageReciever
{

    [SerializeField] Stat stat;

    public override void ApplyDamage(int damage, Vector3 fromPosition)
    {
        //Debug.Log("Stat: " + stat);
        stat.TakeDamage(damage, fromPosition);
    }
}
