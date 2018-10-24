using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatFoodScript : MonoBehaviour {

    [SerializeField] string[] Tags; //The tags of objects that can eat food.

    public double countDownTime;
    public double timerConst;
    public double foodDecayConst;

    private int enemyNumber;

    private void Start() {
        enemyNumber = 0;
    }

    private void FixedUpdate() {
        if (this.countDownTime <= 0)
        {
            Destroy(this.gameObject);
        }
        else if (this.enemyNumber == 0) {
            this.countDownTime -= foodDecayConst;
        }
        else {
            this.countDownTime -= (enemyNumber * timerConst);
        }
    }

    private void OnTriggerEnter(Collider other) {

        foreach (string tag in Tags) {
            if (other.CompareTag(tag)) {
                enemyNumber += 1;
                return;
            }
        }
    }

}
