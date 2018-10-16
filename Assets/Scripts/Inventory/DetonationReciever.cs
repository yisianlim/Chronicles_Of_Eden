using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A abstract compoenent that can somehow be effected by an explosion.
/// </summary>
public abstract class DetonationReciever : MonoBehaviour {

    public abstract void ApplyDetonation();

}
