using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Detonatable : MonoBehaviour {

    [SerializeField] ParticleSystem explosionEffect; 
    [SerializeField] float cookTime; //The time taken from detonation before it explodes.
    [SerializeField] float delayBeforeDamage; //The time from when the explosion starts to when neaby items recieve damage.
    [SerializeField] float exposionRadius;

    /// <summary>
    /// Will start a detonation with the set delay.
    /// </summary>
    public void Detonate()
    {
        StartCoroutine(waitAndDetonate(cookTime));
    }

    /// <summary>
    /// A coroutine for starting exploding after a given delay.
    /// </summary>
    /// <param name="delay"></param>
    /// <returns></returns>
    protected IEnumerator waitAndDetonate(float delay)
    {

        yield return new WaitForSeconds(delay);

        ParticleSystem explosionInstance = Instantiate(explosionEffect, transform.position, transform.rotation);
        explosionInstance.gameObject.SetActive(true);

        yield return new WaitForSeconds(delayBeforeDamage);

        //Find all item that respond to an exposion and effect them.
        new List<Collider>(Physics.OverlapSphere(transform.position, exposionRadius)).ForEach((item) =>
        {
            DetonationReciever reciever = item.GetComponent<DetonationReciever>();
            if (reciever != null) reciever.ApplyDetonation();
        });

        gameObject.GetComponent<Renderer>().enabled = false;

        yield return new WaitForSeconds(explosionEffect.main.duration / 2 - delayBeforeDamage - 0.5f);

        Destroy(explosionInstance.gameObject);
        Destroy(gameObject); //Remove from scene once done.
    }



}
