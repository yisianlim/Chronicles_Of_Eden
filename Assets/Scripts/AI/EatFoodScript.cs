using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatFoodScript : MonoBehaviour {

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
       if (other.CompareTag("Enemy") || other.CompareTag("LargeEnemy") || other.CompareTag("ArmouredEnemy")) {
            enemyNumber += 1;
        } 
    }

}
