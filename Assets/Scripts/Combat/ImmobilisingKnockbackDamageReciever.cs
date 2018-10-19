using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// A KnockbackDamageReciever that disables a NavMeshAgent and NPCAI for a certain duration to avoid conflict between the NavMesh and Rigidbody.
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(NPCAI))]
[RequireComponent(typeof(Rigidbody))]
public class ImmobilisingKnockbackDamageReciever : KnockbackDamageReciever {

    [SerializeField] float immobilisationDuration; //How long after the enemy has been hit that they remain unable to move (i.e. how long the NavMeshAgent is disabled for).

    public override void KnockBack(Rigidbody rigidbody, Vector3 recieverPosition, Vector3 fromPosition, float force)
    {

        StartCoroutine(Immobilise());

        base.KnockBack(rigidbody, recieverPosition, fromPosition, force);

    }

    //Briefly disable the NavmeshAgent and make RigidBody not Kinematic so force is able to be applied.
    public IEnumerator Immobilise()
    {

        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<NPCAI>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = false;

        yield return new WaitForSeconds(immobilisationDuration);

        GetComponent<NavMeshAgent>().enabled = true;
        GetComponent<NPCAI>().enabled = true;
        GetComponent<Rigidbody>().isKinematic = true;

    }

}
