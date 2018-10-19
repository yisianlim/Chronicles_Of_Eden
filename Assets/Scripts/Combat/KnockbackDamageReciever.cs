using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Causes the reciever to be knocked back when damage is dealt to them.
/// </summary>
public class KnockbackDamageReciever : DamageReciever
{

    [SerializeField] float force;

    public override void ApplyDamage(int damage, Vector3 fromPosition)
    {
        KnockBack(GetComponent<Rigidbody>(), transform.position, fromPosition, force);   
    }

    
    public virtual void KnockBack(Rigidbody rigidbody, Vector3 recieverPosition, Vector3 fromPosition, float force)
    {

        //Determine which direction the reciever will be sent in, based on source position.
        Vector3 direction = (recieverPosition - fromPosition).normalized;

        rigidbody.AddForce(direction * force, ForceMode.Impulse);

    }

}
