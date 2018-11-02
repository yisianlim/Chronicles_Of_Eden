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

    private void OnCollisionEnter(Collision collision) {
        Debug.Log("Collision: " + collision.collider.tag);
        if (collision.collider != null && collision.collider.CompareTag("LargeEnemy")) {
            collision.gameObject.GetComponent<NPCAI>().Petrify();
            collision.gameObject.GetComponent<Animator>().speed = 0;
            collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            //collision.gameObject.GetComponent<Animator>().avatar
            Destroy(this.gameObject);
            
        }
        
    }

}
