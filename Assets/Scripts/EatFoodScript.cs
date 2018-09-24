using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatFoodScript : MonoBehaviour {

    public int amount;

    private void FixedUpdate() {
        if (this.amount <=0) {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
       if (other.CompareTag("Enemy")) {
            amount -= 1;
        } 
    }

    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("Enemy")) {
            amount -= 1;
        }
    }
}
