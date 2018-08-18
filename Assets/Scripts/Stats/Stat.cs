using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Stat : MonoBehaviour {

    public abstract void TakeDamage(int damage, Vector3 damageSourceDirection);

}
