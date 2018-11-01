using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectorScript : MonoBehaviour {

    [SerializeField] ToggleBehaviour open;

    Bounds areaBounds;
    bool areaTriggered;

	// Use this for initialization
	void Start () {
        areaBounds = GetComponent<Collider>().bounds;
	}
	
	// Update is called once per frame
	void Update () {

        if (!areaTriggered && Physics.OverlapBox(areaBounds.center, areaBounds.extents * 2, Quaternion.identity, GameUtils.GenerateLayerMask(new int[]{ 15 })).Length <= 0){

            //Debug.Log(Physics.OverlapBox(areaBounds.center, areaBounds.extents * 2, Quaternion.identity, GameUtils.GenerateLayerMask(new int[] { 15 })).Length);

            open.Toggle();
            areaTriggered = true;
        }

	}

    //private void OnTriggerExit(Collider other) {
    //    if (other.CompareTag("Player")) { return; }
    //    if (other.gameObject.layer.Equals("Enemy")) {
    //        counter = counter - 1;
    //        Debug.Log("No. Enemies: " + counter);
    //        if (counter <= 0) {
    //            open.Toggle();
    //        }
    //    }
    //}
}
