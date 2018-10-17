using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains events triggered by attack animations.
/// </summary>
public class AttackAnimationEventHandler : MonoBehaviour {

    [HideInInspector] public GameObject target;

    /// <summary>
    /// Have an attack deal damage.
    /// </summary>
    /// <param name="attackStrength"></param>
    public void AttackImpact(int attackStrength)
    {

        if (target == null) return;

        DamageReciever[] damageRecievers = target.GetComponents<DamageReciever>();
        if (damageRecievers.Length == 0)
            throw new System.Exception("Attack animation event handler had been given an object, " + target.name + ", that does not have a damage reciver attatched.");

        new List<DamageReciever>(damageRecievers).ForEach(r => r.ApplyDamage(attackStrength, transform.position));

    }

}
