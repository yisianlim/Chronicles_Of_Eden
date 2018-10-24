using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExternalTrigger : MonoBehaviour {

    [SerializeField] ExternallyTriggerable triggerable;

    private void OnTriggerEnter(Collider other)
    {
        triggerable.TriggerEntered(other);
    }

    private void OnTriggerExit(Collider other)
    {
        triggerable.TriggerExited(other);
    }

}
