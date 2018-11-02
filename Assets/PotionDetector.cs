using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionDetector : MonoBehaviour {

    [SerializeField] ParticleSystem particle;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Petrify Potion"))  {
            if (particle != null) {
                particle.Play();
            }
            this.gameObject.GetComponent<NPCAI>().Petrify();
            this.gameObject.GetComponent<Animator>().speed = 0;
            this.gameObject.AddComponent(new  Rigidbody().GetType());
            this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            this.gameObject.GetComponent<Agent>().enabled = false;
            Destroy(other.gameObject);
        }
    }
}
