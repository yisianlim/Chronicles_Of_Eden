using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Damages anything with a DamageReciever that gets close enough.
/// </summary>
[RequireComponent(typeof(Collider))]
public class DamagingWeapon : MonoBehaviour {

    public bool Active { get; set; } //Whether the weapon is able to deal damage at a particular point in time.
    public GameObject myParent;

    [SerializeField] int strength; //How much damage the attack deals.

    public void OnTriggerEnter(Collider other)
    {

        Debug.Log("Is active: " + Active);

        if (!Active) return; //Do not do anything more is the weapon is not supposed to be able to deal damage.

        Debug.Log("Applying Damage.");

        //Deal damage to what ever was detected within the collider.
        DamageReciever[] damageRecievers = other.GetComponents<DamageReciever>();
        new List<DamageReciever>(damageRecievers).ForEach(reciever => {
            //ParentCheck(reciever.transform);
            reciever.ApplyDamage(strength, myParent.transform.position);
            Debug.Log(reciever);
        });

    }

    public void ParentCheck(Transform trn) {
        Transform parent = trn.parent;
        int i = 1;
        while (parent != null) {
            Debug.Log("Reached parent " + i + ": " + parent.name);
            parent.SendMessage("example");

            parent = parent.parent;
            ++i;
        }
        Debug.Log("No more parents");
    }


}
