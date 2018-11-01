using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An object that is intantly destroyed weh damage is applied to it.
/// </summary>
public class InstantDestroyDamageReciever : DamageReciever
{
    public override void ApplyDamage(int damage, Vector3 fromPosition)
    {
        Destroy(gameObject);
    }
}
