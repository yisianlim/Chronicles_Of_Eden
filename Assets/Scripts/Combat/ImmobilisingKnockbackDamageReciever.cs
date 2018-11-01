using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// A KnockbackDamageReciever that disables a NavMeshAgent and NPCAI for a certain duration to avoid conflict between the NavMesh and Rigidbody.
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(NPCAI))]
public class ImmobilisingKnockbackDamageReciever : KnockbackDamageReciever {

    [SerializeField] float immobilisationDuration; //How long after the enemy has been hit that they remain unable to move (i.e. how long the NavMeshAgent is disabled for).

    public override void KnockBack(Rigidbody rigidbody, Vector3 recieverPosition, Vector3 fromPosition, float force)
    {

        StartCoroutine(ImmobiliseAndKnockBack(rigidbody, recieverPosition, fromPosition, force));

    }

    //Briefly disable the NavmeshAgent and make RigidBody not Kinematic so force is able to be applied.
    public IEnumerator ImmobiliseAndKnockBack(Rigidbody rigidbody, Vector3 recieverPosition, Vector3 fromPosition, float force)
    {

        GetComponent<NPCAI>().enabled = false;

        Vector3 direction = (recieverPosition - fromPosition).normalized;

        NavMeshAgent agent = GetComponent<NavMeshAgent>();

        float defaultSpeed = agent.speed;
        float defaultAcceleration = agent.acceleration;
        float defaultAngularSpeed = agent.angularSpeed;

        agent.speed = defaultSpeed * force;
        agent.acceleration = defaultAcceleration + 1000;
        agent.angularSpeed = 0;
        agent.SetDestination(transform.position + direction * force);

        yield return new WaitForSeconds(immobilisationDuration);

        agent.speed = defaultSpeed;
        agent.acceleration = defaultAcceleration;
        agent.angularSpeed = defaultAngularSpeed;

        GetComponent<NPCAI>().enabled = true;

    }

}
