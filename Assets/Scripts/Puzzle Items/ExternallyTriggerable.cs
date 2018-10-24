using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A component that allows a component to be triggered by a trigger not attactched to it.
/// </summary>
public abstract class ExternallyTriggerable : MonoBehaviour {

    public abstract void TriggerEntered(Collider other);

    public abstract void TriggerExited(Collider other);

}
