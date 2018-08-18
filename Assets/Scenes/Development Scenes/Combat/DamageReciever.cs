using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageReciever : MonoBehaviour {

    /// <summary>
    /// Apply the given amount of damage to the target.
    /// </summary>
    /// <param name="damage"></param>
    public abstract void ApplyDamage(int damage);

}
