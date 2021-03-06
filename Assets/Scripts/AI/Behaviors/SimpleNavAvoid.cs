﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleNavAvoid : MonoBehaviour {

    private NavMeshAgent _agent;

    //thing to run from
    public GameObject scaryThing;

    public float avoidDistance = 5f;



	// Use this for initialization
	void Start () {
        _agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(transform.position, scaryThing.transform.position);

        //if scary thing is within avoid set new path directly away from scary thing
        if (distance < avoidDistance) {
            Vector3 dirToScare = transform.position - scaryThing.transform.position;
            Vector3 newPos = transform.position + dirToScare;
            _agent.SetDestination(newPos);

        }
	}
}
