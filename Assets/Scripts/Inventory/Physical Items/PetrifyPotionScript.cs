using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetrifyPotionScript : MonoBehaviour {

    public Texture stoneTexture;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Petrify(Collision collision) {
        Debug.Log("Collision: " + collision.collider.tag);
        if (collision.collider != null && collision.collider.CompareTag("LargeEnemy")) {
            
        }
        
    }

}
