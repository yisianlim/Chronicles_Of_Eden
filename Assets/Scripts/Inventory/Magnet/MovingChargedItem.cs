using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingChargedItem : ChargedItem {
    public float mass = 1;
    public Rigidbody rb;

    void Start()
    {
        rb = gameObject.AddComponent<Rigidbody>();
        rb.mass = mass;
    }
}
