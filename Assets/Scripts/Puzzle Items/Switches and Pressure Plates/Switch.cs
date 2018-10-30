using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    private Animator anim;
    public ToggleBehaviour behaviour;
    public bool once, many;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("On", false);
    }

    private void OnTriggerEnter(Collider other) {
        if (once || many) {
            if (!other.CompareTag("Item")) {
                anim.SetBool("On", true);
                behaviour.Toggle();
                Debug.Log("Solved!");
            }
            Debug.Log("Stepped On");
            once = false;
        }
        
    }
}
