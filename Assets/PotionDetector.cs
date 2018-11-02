using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionDetector : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Petrify Potion"))  {
            this.gameObject.GetComponent<NPCAI>().Petrify();
            this.gameObject.GetComponent<Animator>().speed = 0;
            this.gameObject.AddComponent(new  Rigidbody().GetType());
            this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            Destroy(other.gameObject);
        }
    }
}
