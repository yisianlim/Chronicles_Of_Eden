using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantDestroyDetonationReceiver : DetonationReciever
{
    public override void ApplyDetonation()
    {
        gameObject.SetActive(false);
    }
}
