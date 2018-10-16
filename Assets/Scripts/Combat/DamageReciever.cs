using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageReciever : MonoBehaviour {

    /// <summary>
    /// An abstratc class for reactions to taking damage.
    /// </summary>
    /// <param name="damage">The amount of damage taken.</param>
    /// <param name="fromPosition">Where the damage is coming from in global world space.</param>
    public abstract void ApplyDamage(int damage, Vector3 fromPosition);

}
