using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundDamageReciever : DamageReciever
{
    [SerializeField] AudioClip clip;

    public override void ApplyDamage(int damage, Vector3 fromPosition)
    {
        GetComponent<AudioSource>().PlayOneShot(clip);
    }
}
